using AForge.Video.DirectShow;
using Justec.Alcohol.Pulse.BLL;
using Justec.Alcohol.Pulse.Classes;
using Justec.Alcohol.Pulse.Model;
using libzkfpcsharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace Justec.Alcohol.Pulse
{
    public partial class FrmAddUser : Form
    {
        #region 公共属性
        string[] faceIdx = null; //存放摄像头
        private FilterInfoCollection videoDevices;
        UserInfo userInfos;

        //指纹
        IntPtr mDevHandle = IntPtr.Zero;
        IntPtr mDBHandle = IntPtr.Zero;
        IntPtr FormHandle = IntPtr.Zero;
        bool bIsTimeToDie = false;
        bool IsRegister = false;
        bool bIdentify = true;
        byte[] FPBuffer;
        int RegisterCount = 0;
        const int REGISTER_FINGER_COUNT = 3;

        byte[][] RegTmps = new byte[3][];
        byte[] RegTmp = new byte[2048];
        byte[] CapTmp = new byte[2048];
        int cbCapTmp = 2048;
        int cbRegTmp = 0;
        int iFid = 1;
        Thread captureThread = null;

        private int mfpWidth = 0;
        private int mfpHeight = 0;

        const int MESSAGE_CAPTURED_OK = 0x0400 + 6;

        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
        string[] fingerdata = null;
        #endregion
        public FrmAddUser(UserInfo userInfo)
        {
            InitializeComponent();
            userInfos = userInfo;
        }

        private void FrmAddUser_Load(object sender, EventArgs e)
        {
            //部门赋值
            DataTable dataTable = new DataTable();
            dataTable = new DeptManage().GetDeptData();
            dataTable.Rows.RemoveAt(0);
            cxType.DataSource = dataTable;
            cxType.DisplayMember = "DEPTNAME";
            cxType.ValueMember = "DEPTID";
            cxType.SelectedIndex = 0;

            #region 摄像头
            GetCamera();//获取摄像头
            OpenCamera();//打开摄像头
            #endregion

            #region 指纹
            FormHandle = this.Handle;
            FingerInit();//指纹初始化
            OpenFinger();//打开指纹器
            FingerEnroll();//开始注册
            #endregion
        }

        #region 关闭界面
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAddUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseCamera();//关闭摄像头
            FingerClosed();//关闭指纹
            FingerFree();//指纹断开连接
        }
        #endregion

        #region 摄像头
        /// <summary>
        /// 获取摄像头
        /// </summary>
        private void GetCamera()
        {
            try
            {
                // 枚举所有视频输入设备
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (videoDevices.Count == 0)
                    throw new ApplicationException();

                //faceIdx
                faceIdx = new string[videoDevices.Count];
                for (int i = 0; i < videoDevices.Count; i++)
                {
                    faceIdx[i] = videoDevices[i].Name;
                }
            }
            catch (ApplicationException)
            {
                faceIdx = new string[1] { "未发现摄像头" };
                videoDevices = null;
            }
        }

        /// <summary>
        /// 打开摄像头
        /// </summary>

        private void OpenCamera()
        {
            if (faceIdx[0].ToString() == "未发现摄像头")
            {
                System.Windows.Forms.MessageBox.Show("未发现摄像头", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSourcePlayer1.VideoSource = videoSource;
            videoSourcePlayer1.Start();
        }

        /// <summary>
        /// 关闭摄像头
        /// </summary>
        private void CloseCamera()
        {
            if (videoSourcePlayer1 != null && videoSourcePlayer1.IsRunning)
            {
                videoSourcePlayer1.SignalToStop();
                videoSourcePlayer1.WaitForStop();
            }
        }
        #endregion


        #region
        /// <summary>
        /// 关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClosed_Click(object sender, EventArgs e)
        {
            CloseCamera();//关闭摄像头
            FingerClosed();//关闭指纹
            FingerFree();//指纹断开连接
            this.Close();
        }

        /// <summary>
        /// 添加/修改按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(this.txtJobNumber.Text))
            {
                System.Windows.Forms.MessageBox.Show("工号不能为空", "添加提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(this.textUserName.Text))
            {
                System.Windows.Forms.MessageBox.Show("用户名不能为空", "添加提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (userInfos.GID== null)
            {
                try
                {
                    //添加用户
                    userInfos.JobNumber = this.txtJobNumber.Text;//工号
                    userInfos.UserName = this.textUserName.Text;//用户名
                    DataRowView dv = cxType.Items[cxType.SelectedIndex] as DataRowView;
                    userInfos.DeptId = dv.Row["DEPTID"].ToString();//部门ID
                    //保存图片
                    string str = SaveImage(this.txtJobNumber.Text);
                    userInfos.FaceFeature = str;
                    if(str == "")
                    {
                        userInfos.HasFaceFeature = "N";
                    }
                    else
                    {
                        userInfos.HasFaceFeature = "Y";
                    }
                    //指纹
                    Byte[] bytes = new byte[2048];
                    bytes = RegTmp;
                    string s = byteToHexStr(bytes);
                    userInfos.HasFingerFeature = "Y";
                    userInfos.FingerFeature = s;
                    new UserManage().InsertUserInfo(userInfos);
                    CloseCamera();//关闭摄像头
                    FingerClosed();//关闭指纹
                    FingerFree();//指纹断开连接
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch(Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message, "添加提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //修改用户
            }
        }

        /// <summary>
        /// 字节数组转为字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2") + " ";
                }
            }
            return returnStr;
        }
        #endregion

        #region 保存图片并解析
        public string SaveImage(string jobNumber)
        {
            //Bitmap bitmap = videoSourcePlayer1.GetCurrentVideoFrame();
            //string fileName = GetImagePath() + "\\" + jobNumber + DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpg";
            //bitmap.Save(fileName, ImageFormat.Jpeg);
            //bitmap.Dispose();
            //return fileName;

            BitmapSource bitmapSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                                    videoSourcePlayer1.GetCurrentVideoFrame().GetHbitmap(),
                                    IntPtr.Zero,
                                     Int32Rect.Empty,
                                    BitmapSizeOptions.FromEmptyOptions());
            PngBitmapEncoder pE = new PngBitmapEncoder();
            pE.Frames.Add(BitmapFrame.Create(bitmapSource));
            string picName = GetImagePath() + "\\" + jobNumber + DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpg";
            if (File.Exists(picName))
            {
                File.Delete(picName);
            }
            using (Stream stream = File.Create(picName))
            {
                pE.Save(stream);
            }
            return picName;
        }

        private string GetImagePath()
        {
            string personImgPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)
                         + Path.DirectorySeparatorChar.ToString() + "PersonImg";
            if (!Directory.Exists(personImgPath))
            {
                Directory.CreateDirectory(personImgPath);
            }

            return personImgPath;
        }
        private string ImageToByte(string iamgepath)
        {
            using (Image image = Image.FromFile(iamgepath))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }
        #endregion

        #region 指纹
        /// <summary>
        /// 指纹初始化
        /// </summary>
        private void FingerInit()
        {
            fingerdata = null;
            int ret = zkfperrdef.ZKFP_ERR_OK;
            if ((ret = zkfp2.Init()) == zkfperrdef.ZKFP_ERR_OK)
            {
                int nCount = zkfp2.GetDeviceCount();
                fingerdata = new string[nCount];
                if (nCount > 0)
                {
                    for (int i = 0; i < nCount; i++)
                    {
                        fingerdata[i] = i.ToString();
                    }
                }
                else
                {
                    zkfp2.Terminate();
                    this.textRes.Text = "No device connected!";
                }
            }
            else
            {
                this.textRes.Text = "Initialize fail, ret=" + ret + " !";
            }
        }

        /// <summary>
        /// 打开指纹器
        /// </summary>
        private void OpenFinger()
        {
            int ret = zkfp.ZKFP_ERR_OK;
            if (IntPtr.Zero == (mDevHandle = zkfp2.OpenDevice(Convert.ToInt32(fingerdata[0]))))
            {
                textRes.Text = "OpenDevice fail";
                return;
            }
            if (IntPtr.Zero == (mDBHandle = zkfp2.DBInit()))
            {
                textRes.Text = "Init DB fail";
                zkfp2.CloseDevice(mDevHandle);
                mDevHandle = IntPtr.Zero;
                return;
            }
            RegisterCount = 0;
            cbRegTmp = 0;
            iFid = 1;
            for (int i = 0; i < 3; i++)
            {
                RegTmps[i] = new byte[2048];
            }
            byte[] paramValue = new byte[4];
            int size = 4;
            zkfp2.GetParameters(mDevHandle, 1, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpWidth);

            size = 4;
            zkfp2.GetParameters(mDevHandle, 2, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpHeight);

            FPBuffer = new byte[mfpWidth * mfpHeight];

            captureThread = new Thread(new ThreadStart(DoCapture));
            captureThread.IsBackground = true;
            captureThread.Start();
            bIsTimeToDie = false;
            textRes.Text = "Open succ";
        }

        private void DoCapture()
        {
            while (!bIsTimeToDie)
            {
                cbCapTmp = 2048;
                int ret = zkfp2.AcquireFingerprint(mDevHandle, FPBuffer, CapTmp, ref cbCapTmp);
                if (ret == zkfp.ZKFP_ERR_OK)
                {
                    SendMessage(FormHandle, MESSAGE_CAPTURED_OK, IntPtr.Zero, IntPtr.Zero);
                }
                Thread.Sleep(200);
            }
        }

        /// <summary>
        /// 开始注册
        /// </summary>
        private void FingerEnroll()
        {
            if (!IsRegister)
            {
                IsRegister = true;
                RegisterCount = 0;
                cbRegTmp = 0;
                textRes.Text = "Please press your finger 3 times!";
            }
        }

        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case MESSAGE_CAPTURED_OK:
                    {
                        MemoryStream ms = new MemoryStream();
                        BitmapFormat.GetBitmap(FPBuffer, mfpWidth, mfpHeight, ref ms);
                        Bitmap bmp = new Bitmap(ms);
                        this.picFPImg.Image = bmp;
                        if (IsRegister)
                        {
                            int ret = zkfp.ZKFP_ERR_OK;
                            int fid = 0, score = 0;
                            ret = zkfp2.DBIdentify(mDBHandle, CapTmp, ref fid, ref score);
                            if (zkfp.ZKFP_ERR_OK == ret)
                            {
                                textRes.Text = "This finger was already register by " + fid + "!";
                                return;
                            }
                            if (RegisterCount > 0 && zkfp2.DBMatch(mDBHandle, CapTmp, RegTmps[RegisterCount - 1]) <= 0)
                            {
                                textRes.Text = "Please press the same finger 3 times for the enrollment";
                                return;
                            }
                            Array.Copy(CapTmp, RegTmps[RegisterCount], cbCapTmp);
                            String strBase64 = zkfp2.BlobToBase64(CapTmp, cbCapTmp);
                            byte[] blob = zkfp2.Base64ToBlob(strBase64);
                            RegisterCount++;
                            if (RegisterCount >= REGISTER_FINGER_COUNT)
                            {
                                RegTmp = new byte[2048];
                                RegisterCount = 0;
                                if (zkfp.ZKFP_ERR_OK == (ret = zkfp2.DBMerge(mDBHandle, RegTmps[0], RegTmps[1], RegTmps[2], RegTmp, ref cbRegTmp)))
                                {
                                    iFid++;
                                    textRes.Text = "enroll succ";
                                }
                                else
                                {
                                    textRes.Text = "enroll fail, error code=" + ret;
                                }
                                IsRegister = false;
                                return;
                            }
                            else
                            {
                                textRes.Text = "You need to press the " + (REGISTER_FINGER_COUNT - RegisterCount) + " times fingerprint";
                            }       
                        }
                    }
                    break;

                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        private void FingerClosed()
        {
            CloseDevice();
            RegisterCount = 0;
            Thread.Sleep(1000);
        }

        private void CloseDevice()
        {
            if (IntPtr.Zero != mDevHandle)
            {
                bIsTimeToDie = true;
                Thread.Sleep(1000);
                captureThread.Join();
                zkfp2.CloseDevice(mDevHandle);
                mDevHandle = IntPtr.Zero;
            }
        }

        /// <summary>
        /// 指纹断开连接
        /// </summary>
        private void FingerFree()
        {
            zkfp2.Terminate();
            cbRegTmp = 0;
        }
        #endregion
    }
}
