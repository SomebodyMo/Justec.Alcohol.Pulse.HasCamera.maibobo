using AForge.Video.DirectShow;
using CCWin;
using Justec.Alcohol.Pulse.BLL;
using Justec.Alcohol.Pulse.Classes;
using Justec.Alcohol.Pulse.Model;
using Justec.Alcohol.Pulse.Utils;
using libzkfpcsharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Justec.Alcohol.Pulse
{
    public delegate void MethodCaller(UserInfo userinfo);
    public partial class FrmMain : Form
    {
        #region 酒精
        public enum dataFormat
        {
            DATA_HEAD_H = 126,
            DATA_HEAD_L = 1,
            READ_VERSION_CMD = 0x10,
            READ_VERSION_ACK = 18,
            READ_CALIB_PARA_CMD = 0x20,
            READ_CALIB_PARA_ACK = 34,
            SYSTEM_RESET_CMD = 36,
            SYSTEM_RESET_ACK = 38,
            SAMPLE_CMD = 48,
            SAMPLE_ACK = 50,
            SAMPLE_RESULT_ACK = 52,
            COMM_TEST_CMD = 54,
            COMM_TEST_ACK = 56,
            STOP_SAMPLE_CMD = 0x40,
            STOP_SAMPLE_ACK = 66,
            CALIB_CMD = 68,
            CALIB_ACK = 70,
            WRITE_BLOW_TIME_CMD = 80,
            WRITE_BLOW_TIME_ACK = 82,
            READ_TIME_SUM_CMD = 84,
            READ_TIME_SUM_ACK = 86,
            CLEAR_TIME_SUM_CMD = 96,
            CLEAR_TIME_SUM_ACK = 98,
            SAMPLE_ERROR_ACK = 238,
            DEBUG_MSG_ACK = 241,
            UART_MIN_LEN = 8,
            UART_FORMAT_LEN = 6,
            STEP_WAIT = 1,
            STEP_FAIL = 2,
            STEP_BLOW = 3,
            STEP_FINISH = 4,
            STEP_RESULT = 5
        }

        public enum CFG_FORMAT
        {
            FRAME_HEAD_H = 126,
            FRAME_HEAD_L = 1,
            FRAME_FORMAT_LEN = 6,
            FRAME_MIN_LEN = 7,
            FRAME_MAX_LEN = 0xFF,
            UART_BUFF = 0x1000,
            SAMPLE_TIMEOUT = 250,
            CALIB_TIMEOUT = 11000,
            COMM_ERR = 3
        }

        public struct dataBox_t
        {
            public int p;

            public int lp;

            public byte[] databuff;

            public byte[] pack;
        }

        public const int WM_DEVICE_CHANGE = 537;

        public const int DBT_DEVICEARRIVAL = 32768;

        public const int DBT_DEVICE_REMOVE_COMPLETE = 32772;

        public int step = 1;

        public int ackSta = 0;

        public int commErr = 0;

        public byte[] uartSampleWaitAck = new byte[2]
        {
            1,
            0
        };

        public byte[] uartSampleFailAck = new byte[2]
        {
            2,
            0
        };

        public byte[] uartSampleBlowAck = new byte[2]
        {
            3,
            0
        };

        public byte[] uartSampleFinishAck = new byte[2]
        {
            4,
            0
        };

        public byte[] uartErrorAck = new byte[2]
        {
            255,
            0
        };

        public byte[] uartCommTestAck = new byte[2]
        {
            5,
            0
        };

        public byte[] uartStopSampleAck = new byte[2]
        {
            6,
            0
        };

        public byte[] uartReadVersionCmd = new byte[7]
        {
            126,
            1,
            16,
            0,
            1,
            0,
            17
        };

        public byte[] uartReadCalibParaCmd = new byte[7]
        {
            126,
            1,
            32,
            0,
            1,
            0,
            33
        };

        public byte[] uartSystemResetCmd = new byte[7]
        {
            126,
            1,
            36,
            0,
            1,
            0,
            37
        };

        public byte[] uartSampleCmd = new byte[7]
        {
            126,
            1,
            48,
            0,
            1,
            0,
            49
        };

        public byte[] uartCommTesCmd = new byte[7]
        {
            126,
            1,
            54,
            0,
            1,
            1,
            56
        };

        public byte[] uartStopSampleCmd = new byte[7]
        {
            126,
            1,
            64,
            0,
            1,
            0,
            65
        };

        public byte[] uartcalibCmd = new byte[7]
        {
            126,
            1,
            68,
            0,
            1,
            0,
            65
        };

        public byte[] uartSetBlowTimeCmd = new byte[7]
        {
            126,
            1,
            80,
            0,
            1,
            0,
            65
        };

        public byte[] uartRadTimeSumCmd = new byte[7]
        {
            126,
            1,
            84,
            0,
            1,
            0,
            85
        };

        public byte[] uartClearTimeSumCmd = new byte[7]
        {
            126,
            1,
            96,
            0,
            1,
            0,
            97
        };

        #endregion

        #region 指纹
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
        #region 公共属性
        PulseDataManage pulseData = new PulseDataManage();//数据处理
        SerialPort port = new SerialPort();//血压端口声明
        FrmLocalDatas frmLocalDatas;//本地数据界面
        FrmUserManage FrmUserManage;//人员管理
        FrmAbout FrmAbout;//关于
        UserInfo userInfo = new UserInfo();
        private dataBox_t dataBox;
        DataTable userTable = new DataTable();
        int gid = 0; //用户表唯一标示符
        string[] faceIdx = null; //存放摄像头
        private FilterInfoCollection videoDevices;
        AlcPluData alcPluDatas = new AlcPluData();
        //定时器
        System.Timers.Timer timer = new System.Timers.Timer();
        private int count = 0;

        public static System.Windows.Forms.Timer portTimer = new System.Windows.Forms.Timer()
        {
            Interval = 1000
        };
        #endregion

        #region 初始化
        public FrmMain()
        {
            InitializeComponent();
            sysInit();

            //血压串口
            this.cbxPortName.DataSource = System.IO.Ports.SerialPort.GetPortNames();
            //获取血压数据
            port.DataReceived += new SerialDataReceivedEventHandler(InRealTimeDowmload);
            //酒精串口
            portTimer.Tick += new EventHandler(PortInitialize);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //先判断是否有数据库,有就更新，没有创建
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "JustecDB.db"))
            {
                UpdateDataBase();
            }
            else
            {
                SqliteHelper.CreateDBFile();
            }
            portTimer.Start();
            //获取全部用户信息
            userTable = new UserManage().GetAllUserInfo();

            this.labTime.Text = string.Empty;//测试时间

            this.labResultName.Text = string.Empty;//姓名
            this.labResultJobNumber.Text = string.Empty;//工号
            this.labResultIsIdentity.Text = string.Empty;//身份
            this.labResultDeptName.Text = string.Empty;//单位
            this.labResultTime.Text = string.Empty;//测量时间
            this.labResultAlcoholStrength.Text = string.Empty;//酒精浓度
            this.labResultIsNormal.Text = string.Empty;//测量结果
            cbxBaudRate.SelectedIndex = 0;

            #region 摄像头
            GetCamera();//获取摄像头
            OpenCamera();//打开摄像头
            #endregion

            #region 指纹
            FormHandle = this.Handle;
            FingerInit();//指纹初始化
            OpenFinger();//打开指纹器
            IdentifyFinger();//指纹登陆
            #endregion
        }

        /// <summary>
        /// 执行数据库更新脚本
        /// </summary>
        private void UpdateDataBase()
        {
            BeginInvoke(new Action(() =>
            {
                string filePath = AppDomain.CurrentDomain.BaseDirectory + "DBUpdate\\V" + Application.ProductVersion + ".txt";
                if (File.Exists(filePath))
                {
                    StreamReader sr = new StreamReader(filePath, Encoding.UTF8);
                    string txtLine, txtSql = "";
                    while ((txtLine = sr.ReadLine()) != null)
                    {
                        txtSql += txtLine + "\n";
                    }
                    sr.Close();
                    if (txtSql != null && !txtSql.Contains("已执行"))
                    {
                        SqliteHelper.OperationTable(txtSql);
                        using (StreamWriter sw = File.AppendText(filePath))
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("已执行");
                            sw.WriteLine(sb.ToString());
                            sw.Close();
                        }
                    }
                }
            }));
        }
        #endregion
        #region 手动连接串口(血压)
        /// <summary>
        /// 连接串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            SetButton(btnConnect);
            string portName = cbxPortName.Text;
            string baudRate = cbxBaudRate.Text;
            if (string.IsNullOrEmpty(portName))
            {
                MessageBoxEx.Show("端口号不能为空");
                return;
            }
            if (string.IsNullOrEmpty(baudRate))
            {
                MessageBoxEx.Show("波特率不能为空");
                return;
            }
            PortInitialize(portName, Convert.ToInt32(baudRate));
        }

        /// <summary>
        /// 手动连接
        /// </summary>
        /// <param name="portName"></param>
        /// <param name="baudRate"></param>
        private void PortInitialize(string portName, int baudRate)
        {
            try
            {
                //端口初始化
                if (!port.IsOpen)//关闭
                {
                    port.PortName = portName;
                    port.BaudRate = baudRate;

                    if (port.PortName != "COM1")
                    {
                        port.Open();
                        label7.Text = "设备已连接";
                        Assembly assembly = Assembly.GetExecutingAssembly();
                        Stream imgStream = assembly.GetManifestResourceStream("Justec.Alcohol.Pulse.pulseImage.connect.png");
                        picturePulse.Image = Image.FromStream(imgStream);
                        btnConnect.Text = "断开";
                    }
                    else
                    {
                        label7.Text = "请连接设备...";
                        Assembly assembly = Assembly.GetExecutingAssembly();
                        Stream imgStream = assembly.GetManifestResourceStream("Justec.Alcohol.Pulse.pulseImage.notconnect.png");
                        picturePulse.Image = Image.FromStream(imgStream);
                        btnConnect.Text = "连接";
                    }
                }
                else
                {
                    port.Close();
                    label7.Text = "请连接设备...";
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Stream imgStream = assembly.GetManifestResourceStream("Justec.Alcohol.Pulse.pulseImage.notconnect.png");
                    picturePulse.Image = Image.FromStream(imgStream);
                    btnConnect.Text = "连接";
                }
            }
            catch (Exception ex)
            {
                label7.Text = ex.Message;
            }
        }
        #endregion

        #region 接受血压数据并显示到界面
        /// <summary>
        /// 串口数据接收事件方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InRealTimeDowmload(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort myport = port;
                AlcPluData alcPluData = new AlcPluData();

                byte[] startbackCmd = JustecPort.ReceivedPluseData(myport);
                if (startbackCmd != null && startbackCmd.Length != 0)
                {
                    JustecPort.SendCmd("start", myport);
                    alcPluData.SendTime = "20" + Convert.ToString(startbackCmd[7]) + "-";
                    //月
                    if (Convert.ToInt32(startbackCmd[8]) < 10)
                    {
                        alcPluData.SendTime += "0" + Convert.ToString(startbackCmd[8]) + "-";
                    }
                    else
                    {
                        alcPluData.SendTime += Convert.ToString(startbackCmd[8]) + "-";
                    }
                    //日
                    if (Convert.ToInt32(startbackCmd[9]) < 10)
                    {
                        alcPluData.SendTime += "0" + Convert.ToString(startbackCmd[9]) + " ";
                    }
                    else
                    {
                        alcPluData.SendTime += Convert.ToString(startbackCmd[9]) + " ";
                    }
                    //时
                    if (Convert.ToInt32(startbackCmd[10]) < 10)
                    {
                        alcPluData.SendTime += "0" + Convert.ToString(startbackCmd[10]) + ":";
                    }
                    else
                    {
                        alcPluData.SendTime += Convert.ToString(startbackCmd[10]) + ":";
                    }
                    //分
                    if (Convert.ToInt32(startbackCmd[11]) < 10)
                    {
                        alcPluData.SendTime += "0" + Convert.ToString(startbackCmd[11]) + ":" + Convert.ToString(startbackCmd[12]);
                    }
                    else
                    {
                        alcPluData.SendTime += Convert.ToString(startbackCmd[11]) + ":";
                    }
                    alcPluData.SendTime += Convert.ToString(startbackCmd[12]);
                    alcPluData.Sbp = Convert.ToString(startbackCmd[14]);
                    alcPluData.Dbp = Convert.ToString(startbackCmd[16]);
                    alcPluData.Pulsess = Convert.ToString(startbackCmd[18]);
                    this.BeginInvoke((EventHandler)delegate
                    {
                        SetPulseInfo(alcPluData);
                    });
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLog($"实时接收数据错误: 1.错误信息 {ex.Message}\r\n 2.错误详情 { ex.StackTrace}");
            }
            finally
            {              
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

        private void SetPulseInfo(AlcPluData alcPluData)
        {
            this.labTime.Text = alcPluData.SendTime;
            this.labSbp.Text = alcPluData.Sbp;
            this.labDbp.Text = alcPluData.Dbp;
            this.labPulse.Text = alcPluData.Pulsess;
            if (alcPluData.Sbp != "00" && alcPluData.Dbp != "00" && alcPluData.Pulsess != "00")
            {
                alcPluDatas.Sbp = alcPluData.Sbp;
                alcPluDatas.Dbp = alcPluData.Dbp;
                alcPluDatas.Pulsess = alcPluData.Pulsess;
            }
        }
        #endregion

        #region 酒精数据
        /// <summary>
        /// 初始化
        /// </summary>
        private void sysInit()
        {
            dataBox.lp = 0;
            dataBox.p = 0;
            dataBox.databuff = new byte[4096];
        }

        /// <summary>
        /// 酒精串口初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PortInitialize(object sender, EventArgs e)
        {
            try
            {
                if(!JustecPort.Port.IsOpen)
                {
                    JustecPort.Port.PortName = JustecPort.GetPortName();
                    if(JustecPort.Port.PortName != "COM1")
                    {
                        JustecPort.Port.Open();
                        JustecPort.Port.DataReceived += Com_DataReceived;
                        label11.Text = "设备已连接";
                        Assembly assembly = Assembly.GetExecutingAssembly();
                        Stream imgStream = assembly.GetManifestResourceStream("Justec.Alcohol.Pulse.pulseImage.connect.png");
                        pictureAlcohol.Image = Image.FromStream(imgStream);
                        //startSampleCmd();//开始测酒
                    }
                    else
                    {
                        label11.Text = "请连接设备...";
                        Assembly assembly = Assembly.GetExecutingAssembly();
                        Stream imgStream = assembly.GetManifestResourceStream("Justec.Alcohol.Pulse.pulseImage.notconnect.png");
                        pictureAlcohol.Image = Image.FromStream(imgStream);
                    }
                }
            }
            catch(Exception ex)
            {
                label11.Text = ex.Message;
            }
        }

        private void Com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] array = new byte[JustecPort.Port.BytesToRead];
            JustecPort.Port.Read(array, 0, array.Length);
            try
            {
                intoDataBox(array, array.Length);
            }
            catch
            {
                label11.Text = "缓存出错！";
            }
            while (getPack())
            {
                try
                {
                    dataProccess();
                }
                catch
                {
                    label11.Text = "协议解析错误！";
                }
            }
        }

        private void dataProccess()
        {
            checked
            {
                int count = (dataBox.pack[3] << 8) + unchecked((int)dataBox.pack[4]);
                try
                {
                    ackSta = 1;
                    commErr = 0;
                    if (dataBox.pack[2] == 50)
                    {
                        switch (dataBox.pack[5])
                        {
                            case 1:
                                break;
                            case 2:
                                stopSample();
                                break;
                            case 3:
                                if (dataBox.pack[6] == 0)
                                {
                                  
                                }
                                else if (dataBox.pack[6] == 1)
                                {
                                }
                                break;
                            case 4:
                                break;
                            case 15:
                                timeoutTimer.Enabled = false;
                                step = 1;
                                break;
                            default:
                                ackSta = 0;
                                break;
                        }
                    }
                    else if (dataBox.pack[2] == 56)
                    {
                        if (dataBox.pack[5] > 1 && dataBox.pack[5] < 5)
                        {
                            timeoutTimer.Enabled = false;
                            step = 1;
                        }
                        switch (dataBox.pack[5])
                        {
                            case 1:
                                break;
                            case 2:
                                break;
                            case 3:
                                break;
                            case 4:
                                break;
                            case 5:
                                break;
                        }
                        step = 3;
                    }
                    else if (dataBox.pack[2] == 66)
                    {
                        stopSample();
                    }
                    else if (dataBox.pack[2] == 52)
                    {
                        int value = (dataBox.pack[5] << 8) + unchecked((int)dataBox.pack[6]);
                        this.BeginInvoke((EventHandler)delegate
                        {
                            ///保存测酒程序
                            labResultTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            labResultAlcoholStrength.Text = Convert.ToString(value) + " mg/100ml";
                            if(Convert.ToInt32(value) < 20)
                            {
                                labResultIsNormal.Text = "正常";
                            }
                            if(Convert.ToInt32(value) >=20 && Convert.ToInt32(value) < 80)
                            {
                                labResultIsNormal.Text = "饮酒";
                            }
                            if (Convert.ToInt32(value) >= 80)
                            {
                                labResultIsNormal.Text = "酗酒";
                            }
                            alcPluDatas.AlcoholStrength = Convert.ToString(value);
                            alcPluDatas.SendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            //保存图片
                            string str = SaveImage(this.labResultName.Text);
                            alcPluDatas.BlodPhoto = str;
                        });
                        step = 5;
                    }
                    else if (dataBox.pack[2] == 70)
                    {
                        int value2 = (dataBox.pack[5] << 8) + unchecked((int)dataBox.pack[6]);
                        step = 5;
                    }
                    else if (dataBox.pack[2] == 18)
                    {
                        byte[] array = new byte[4];
                        byte[] array2 = new byte[6];
                        Array.Copy(dataBox.pack, 5, array, 0, 4);
                        Array.Copy(dataBox.pack, 9, array2, 0, 6);
                    }
                    else if (dataBox.pack[2] == 34)
                    {
                        int value2 = (dataBox.pack[5] << 8) + unchecked((int)dataBox.pack[6]);
                    }
                    else if (dataBox.pack[2] == 38)
                    {
                    }
                    else if (dataBox.pack[2] == 82)
                    {
                        if (dataBox.pack[5] == 1)
                        {
                        }
                        else
                        {
                        }
                    }
                    else if (dataBox.pack[2] == 86)
                    {
                        uint num = 0u;
                        uint num2 = 0u;
                        for (int i = 0; i < 4; i++)
                        {
                            num += unchecked((uint)checked(dataBox.pack[5 + i] << (3 - i) * 8));
                            num2 += unchecked((uint)checked(dataBox.pack[5 + i + 4] << (3 - i) * 8));
                        }
                    }
                    else if (dataBox.pack[2] == 98)
                    {
                        if (dataBox.pack[5] == 1)
                        {
                            
                        }
                        else
                        {
                            
                        }
                    }
                    else if (dataBox.pack[2] == 238)
                    {
                        byte b = dataBox.pack[5];
                        if (b == byte.MaxValue)
                        {
                           
                        }
                        timeoutTimer.Enabled = false;
                        step = 1;
                    }
                    else if (dataBox.pack[2] == 241)
                    {
                        
                    }
                    else
                    {
                        ackSta = 0;
                    }
                }
                catch
                {
                    label11.Text = "协议解析出错";
                }
            }
        }

        private void stopSample()
        {
            timeoutTimer.Enabled = false;
            step = 1;
        }

        private void intoDataBox(byte[] data, int len)
        {
            checked
            {
                if (dataBox.p + len < 4096)
                {
                    Array.Copy(data, 0, dataBox.databuff, dataBox.p, len);
                    dataBox.p += len;
                    return;
                }
                int num = 4096 - dataBox.p;
                Array.Copy(data, 0, dataBox.databuff, dataBox.p, num);
                Array.Copy(data, num, dataBox.databuff, 0, len - num);
                dataBox.p = len - num;
            }
        }

        private bool getPack()
        {
            bool flag = false;
            checked
            {
                while (true)
                {
                    bool flag2 = true;
                    if (getBuffLen() < 7)
                    {
                        return false;
                    }
                    if (!readBuffData(5))
                    {
                        return false;
                    }
                    if (dataBox.pack[0] == 126 && dataBox.pack[1] == 1)
                    {
                        int num = (dataBox.pack[3] << 8) + unchecked((int)dataBox.pack[4]) + 6;
                        if (num >= 7 && num <= 255)
                        {
                            if (num > getBuffLen())
                            {
                                return false;
                            }
                            if (readBuffData(num))
                            {
                                byte b = checkSum(dataBox.pack, 2, (byte)(num - 3));
                                if (dataBox.pack[num - 1] == b)
                                {
                                    flag = getBuffData(num);
                                }
                            }
                        }
                    }
                    if (flag)
                    {
                        break;
                    }
                    dataBox.lp++;
                    if (dataBox.lp >= 4096)
                    {
                        dataBox.lp = 0;
                    }
                }
                return true;
            }
        }

        private int getBuffLen()
        {
            checked
            {
                if (dataBox.p >= dataBox.lp)
                {
                    return dataBox.p - dataBox.lp;
                }
                return dataBox.p + 4096 - dataBox.lp;
            }
        }

        private bool readBuffData(int len)
        {
            if (len > getBuffLen())
            {
                return false;
            }
            dataBox.pack = new byte[len];
            checked
            {
                if (4096 > dataBox.lp + len)
                {
                    Array.Copy(dataBox.databuff, dataBox.lp, dataBox.pack, 0, len);
                }
                else
                {
                    int num = 4096 - dataBox.lp;
                    Array.Copy(dataBox.databuff, dataBox.lp, dataBox.pack, 0, num);
                    Array.Copy(dataBox.databuff, 0, dataBox.pack, num, len - num);
                }
                return true;
            }
        }

        private byte checkSum(byte[] data, int offset, int len)
        {
            ushort num = 0;
            checked
            {
                for (int i = 0; i < len; i++)
                {
                    num = (ushort)(unchecked((int)num) + unchecked((int)data[checked(i + offset)]));
                    if (num > 255)
                    {
                        num = (ushort)(unchecked((int)num) - 256);
                    }
                }
                return (byte)num;
            }
        }

        private bool getBuffData(int len)
        {
            if (!readBuffData(len))
            {
                return false;
            }
            checked
            {
                if (4096 > dataBox.lp + len)
                {
                    dataBox.lp += len;
                }
                else
                {
                    dataBox.lp = len - (4096 - dataBox.lp);
                }
                return true;
            }
        }

        private void startSampleCmd()
        {
            uartSendCmd(54);
            timeoutTimer.Enabled = true;
        }

        private void uartSendCmd(byte cmd)
        {
            checked
            {
                try
                {
                    ackSta = 0;
                    switch (cmd)
                    {
                        case 48:
                            JustecPort.Port.Write(uartSampleCmd, 0, uartSampleCmd.Length);
                            break;
                        case 54:
                            JustecPort.Port.Write(uartCommTesCmd, 0, uartCommTesCmd.Length);
                            break;
                        case 64:
                            JustecPort.Port.Write(uartStopSampleCmd, 0, uartStopSampleCmd.Length);
                            break;
                        case 16:
                            JustecPort.Port.Write(uartReadVersionCmd, 0, uartReadVersionCmd.Length);
                            break;
                        case 32:
                            JustecPort.Port.Write(uartReadCalibParaCmd, 0, uartReadCalibParaCmd.Length);
                            break;
                        case 36:
                            JustecPort.Port.Write(uartSystemResetCmd, 0, uartSystemResetCmd.Length);
                            break;
                        //case 80:
                        //    uartSetBlowTimeCmd[5] = (byte)Convert.ToInt32(inputBox.Text);
                        //    uartSetBlowTimeCmd[6] = (byte)(unchecked((int)uartSetBlowTimeCmd[5]) + 81);
                        //    JustecPort.Port.Write(uartSetBlowTimeCmd, 0, uartSetBlowTimeCmd.Length);
                        //    break;
                        case 84:
                            JustecPort.Port.Write(uartRadTimeSumCmd, 0, uartRadTimeSumCmd.Length);
                            break;
                        case 96:
                            JustecPort.Port.Write(uartClearTimeSumCmd, 0, uartClearTimeSumCmd.Length);
                            break;
                    }
                }
                catch
                {
                    MessageBox.Show("操作失败！");
                }
            }
        }

        private void timeoutTimer_Tick(object sender, EventArgs e)
        {
            timeoutInterrupt();
        }

        private void timeoutInterrupt()
        {
            checked
            {
                if (ackSta == 0)
                {
                    commErr++;
                    if (commErr > 3)
                    {
                        commErr = 0;
                        this.BeginInvoke((EventHandler)delegate
                        {
                            labResultIsNormal.Text = "通信超时！";

                        });
                        timeoutTimer.Enabled = false;
                        step = 1;
                        return;
                    }
                }
                if (step == 1 || step == 3 || step == 4)
                {
                    uartSendCmd(48);
                }
                if (step == 5)
                {
                    stopSampleCmd();
                }
            }
        }
        private void stopSampleCmd()
        {
            uartSendCmd(64);
        }

        #endregion

        #region 关闭窗口
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (port.IsOpen) port.Close();
            if (JustecPort.Port.IsOpen) JustecPort.Port.Close();
        }
        #endregion

        #region 本地数据
        private void localData_Click(object sender, EventArgs e)
        {

            if (frmLocalDatas == null || frmLocalDatas.IsDisposed)
            {
                frmLocalDatas = new FrmLocalDatas();
                frmLocalDatas.Show();
            }
            else
            {
                frmLocalDatas.StartPosition = FormStartPosition.CenterParent;
                frmLocalDatas.WindowState = FormWindowState.Maximized;
            }
        }

        private void localData_MouseEnter(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream imgStream = assembly.GetManifestResourceStream("Justec.Alcohol.Pulse.pulseImage.backg.jpg");
            this.localData.BackgroundImage = Image.FromStream(imgStream);
        }

        private void localData_MouseLeave(object sender, EventArgs e)
        {
            this.localData.BackgroundImage = null;
        }
        #endregion

        #region 登录
        /// <summary>
        /// 动态获取用户名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtJobNumber_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtJobNumber.Text))
            {
                UserInfo info = new UserManage().GetUserInfoBy(txtJobNumber.Text);
                if (info != null)
                {
                    txtName.Text = info.UserName;
                }
                else
                {
                    txtName.Text = "无效用户";
                }
            }
            else
            {
                txtName.Text = string.Empty;
            }
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            SetButton(btnLogin);
            string message;
            alcPluDatas = new AlcPluData();
            userInfo = new UserInfo();
            if (string.IsNullOrWhiteSpace(txtJobNumber.Text))
            {
                MessageBox.Show("请输入用户名！", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
            else if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("请输入密码！", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
            else if (CheckLogin(txtJobNumber.Text, txtPassword.Text, out message))
            {
                timer.Enabled = true;
                timer.Interval = 1000;//1毫秒
                timer.Start();
                timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer1_Elapsed);

                DialogResult = DialogResult.OK;
                startSampleCmd();//开始测酒
                GlobalData.user.JobNo = txtJobNumber.Text;
                GlobalData.user.Name = txtName.Text;
                userInfo = new UserManage().GetUserInfoBy(txtJobNumber.Text);
                #region 清空
                //血压
                this.labResultName.Text = string.Empty;//姓名
                this.labResultJobNumber.Text = string.Empty;//工号
                this.labResultIsIdentity.Text = string.Empty;//身份
                this.labResultDeptName.Text = string.Empty;//单位
                this.labResultTime.Text = string.Empty;//测量时间
                this.labResultAlcoholStrength.Text = string.Empty;//酒精浓度
                this.labResultIsNormal.Text = string.Empty;//测量结果
                this.pictureBox4.Image = global::Justec.Alcohol.Pulse.Properties.Resources.morentouxiang拷贝1;

                //酒精
                this.labTime.Text = string.Empty;//测试时间
                this.labSbp.Text = "--";//收缩压
                this.labDbp.Text = "--";//舒张压
                this.labPulse.Text = "--";//脉搏

                //登陆
                this.txtJobNumber.Text = string.Empty;
                this.txtName.Text = string.Empty;
                this.txtPassword.Text = string.Empty;
                #endregion

                this.labResultName.Text = userInfo.UserName;//姓名
                this.labResultJobNumber.Text = userInfo.JobNumber;//工号
                this.labResultIsIdentity.Text = "正确";//身份
                this.labResultDeptName.Text = userInfo.DeptName;//单位
                alcPluDatas.UseName = userInfo.UserName;
                alcPluDatas.JobNumber = userInfo.JobNumber;
                alcPluDatas.DeptId = userInfo.DeptId;
                alcPluDatas.Identity = "正确";
                string faceFeature = userInfo.FaceFeature;
                if (faceFeature != "")
                {
                    this.pictureBox4.Image = Image.FromFile(userInfo.FaceFeature);
                }
                else
                {
                    this.pictureBox4.Image = global::Justec.Alcohol.Pulse.Properties.Resources.morentouxiang拷贝1;
                }
            }
            else
            {
                MessageBox.Show(message, "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
        }

        private bool CheckLogin(string JobNo, string pwd, out string message)
        {
            message = "登录成功！";
            UserManage userManage = new UserManage();
            bool ifExist = userManage.UserIsExistOrNo(JobNo);
            if (!ifExist)
            {
                message = "该用户不存在！";
                txtJobNumber.Text = null;
                txtPassword.Text = null;
                txtJobNumber.Focus();
                return false;
            }
            bool check = userManage.CheckUserPwd(JobNo, pwd);
            if (!check)
            {
                message = "密码不正确！";
                txtPassword.Text = null;
                txtPassword.Focus();
                return false;
            }
            return true;
        }

        #endregion

        #region 按钮无焦点
        /// <summary>
        /// 实现按钮无焦点
        /// </summary>
        /// <param name="button"></param>
        private void SetButton(Button button)
        {
            MethodInfo methodinfo = button.GetType().GetMethod("SetStyle", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod);
            methodinfo.Invoke(button, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod, null, new object[] { ControlStyles.Selectable, false }, Application.CurrentCulture);
        }
        #endregion

        #region 人员管理
        private void userManage_Click(object sender, EventArgs e)
        {
            FingerClosed();//关闭指纹
            FingerFree();//指纹断开连接
            CloseCamera();//关闭摄像头
            FrmUserManage = new FrmUserManage();
            FrmUserManage.ShowDialog();

            if (FrmUserManage.DialogResult == DialogResult.OK)
            {
                #region 摄像头
                GetCamera();//获取摄像头
                OpenCamera();//打开摄像头
                #endregion

                #region 指纹
                FormHandle = this.Handle;
                FingerInit();//指纹初始化
                OpenFinger();//打开指纹器
                IdentifyFinger();//指纹登陆
                #endregion
            }
        }

        private void userManage_MouseEnter(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream imgStream = assembly.GetManifestResourceStream("Justec.Alcohol.Pulse.pulseImage.backg.jpg");
            this.userManage.BackgroundImage = Image.FromStream(imgStream);
        }

        private void userManage_MouseLeave(object sender, EventArgs e)
        {
            this.userManage.BackgroundImage = null;
        }
        #endregion

        #region 关于
        private void about_Click(object sender, EventArgs e)
        {
            if (FrmAbout == null || FrmAbout.IsDisposed)
            {
                FrmAbout = new FrmAbout();
                FrmAbout.Show();
            }
            else
            {
                FrmAbout.WindowState = FormWindowState.Normal;
            }
        }

        private void about_MouseEnter(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream imgStream = assembly.GetManifestResourceStream("Justec.Alcohol.Pulse.pulseImage.backg.jpg");
            this.about.BackgroundImage = Image.FromStream(imgStream);
        }

        private void about_MouseLeave(object sender, EventArgs e)
        {
            this.about.BackgroundImage = null;
        }
        #endregion

        /// <summary>
        /// 指纹登陆获取信息
        /// </summary>
        public void getUserinfo()
        {
            userTable = new UserManage().GetAllUserInfo();
            bool isUserExist = false;
            for (int i = 0; i < userTable.Rows.Count; i++)
            {
                string fingerFeature = userTable.Rows[i]["FingerFeature"].ToString();
                Byte[] sss = null;
                sss = GetByteArray(fingerFeature);
                int ret = zkfp2.DBMatch(mDBHandle, CapTmp, sss);
                if (ret > 0)
                {
                    gid = Convert.ToInt32(userTable.Rows[i]["GID"].ToString());
                    isUserExist = true;
                    break;
                }
                else
                {
                    continue;
                }
            }

            if (isUserExist)
            {
                userInfo = new UserManage().GetUserInfoByGid(gid);
                this.txtJobNumber.Text = userInfo.JobNumber;
                this.txtPassword.Text = userInfo.Pwd;
                this.labResultTime.Text = string.Empty;//测量时间
                this.labResultAlcoholStrength.Text = string.Empty;//酒精浓度
                this.labResultIsNormal.Text = string.Empty;//测量结果
                btnLogin_Click(btnLogin, new EventArgs());
            }
            else
            {
                this.labResultName.Text = string.Empty;//姓名
                this.labResultJobNumber.Text = string.Empty;//工号
                this.labResultIsIdentity.Text = string.Empty;//身份
                this.labResultDeptName.Text = string.Empty;//单位
                this.labResultTime.Text = string.Empty;//测量时间
                this.labResultAlcoholStrength.Text = string.Empty;//酒精浓度
                this.labResultIsNormal.Text = string.Empty;//测量结果
                this.pictureBox4.Image = global::Justec.Alcohol.Pulse.Properties.Resources.morentouxiang拷贝1;
                System.Windows.Forms.MessageBox.Show("未找到该用户信息", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

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
                    System.Windows.Forms.MessageBox.Show("No device connected!", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Initialize fail, ret=" + ret + " !", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
                System.Windows.Forms.MessageBox.Show("OpenDevice fail", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (IntPtr.Zero == (mDBHandle = zkfp2.DBInit()))
            {
                System.Windows.Forms.MessageBox.Show("Init DB fail", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// 指纹登陆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IdentifyFinger()
        {
            if (!bIdentify)
            {
                bIdentify = true;
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
                        if (!IsRegister)                     
                        {
                            if (bIdentify)
                            {
                                this.BeginInvoke((EventHandler)delegate
                                {
                                    getUserinfo();
                                });
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

        /// <summary>
        /// string类型数组转为字节数组
        /// </summary>
        /// <returns></returns>
        private static byte[] GetByteArray(string strUserFingerInfo)
        {
            string[] fingerInfo = strUserFingerInfo.Substring(0,strUserFingerInfo.Length-1).Split(' ');
            int i = fingerInfo.Length;
            List<Byte> bytList = new List<byte>();
            foreach(var s in fingerInfo)
            {
                bytList.Add(Convert.ToByte(s,16));
            }
            return bytList.ToArray();
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

        #region 保存图片并解析
        public string SaveImage(string loginName)
        {
            Bitmap bitmap = videoSourcePlayer1.GetCurrentVideoFrame();
            string fileName = GetImagePath() + "\\" + loginName + DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpg";
            bitmap.Save(fileName, ImageFormat.Jpeg);
            bitmap.Dispose();
            return fileName;
        }

        private string GetImagePath()
        {
            string personImgPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)
                         + Path.DirectorySeparatorChar.ToString() + "MeasurementImg";
            if (!Directory.Exists(personImgPath))
            {
                Directory.CreateDirectory(personImgPath);
            }

            return personImgPath;
        }
        #endregion

        #region 保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            count++;

            if(count <= 300)
            {
                if(!string.IsNullOrEmpty(alcPluDatas.JobNumber) && !string.IsNullOrEmpty(alcPluDatas.AlcoholStrength) && !string.IsNullOrEmpty(alcPluDatas.Sbp))
                {
                    this.BeginInvoke((EventHandler)delegate
                    {
                        pulseData.InsertPulseHistory(alcPluDatas);
                        alcPluDatas = new AlcPluData();
                        userInfo = new UserInfo();
                        count = 0;
                        timer.Stop();
                        MessageBox.Show("测试成功,数据已提交", "测试提示", MessageBoxButtons.OK);
                    });                  
                }
            }
            else
            {
                this.BeginInvoke((EventHandler)delegate
                {
                    alcPluDatas = new AlcPluData();
                    userInfo = new UserInfo();
                    //血压
                    this.labResultName.Text = string.Empty;//姓名
                    this.labResultJobNumber.Text = string.Empty;//工号
                    this.labResultIsIdentity.Text = string.Empty;//身份
                    this.labResultDeptName.Text = string.Empty;//单位
                    this.labResultTime.Text = string.Empty;//测量时间
                    this.labResultAlcoholStrength.Text = string.Empty;//酒精浓度
                    this.labResultIsNormal.Text = string.Empty;//测量结果
                    this.pictureBox4.Image = global::Justec.Alcohol.Pulse.Properties.Resources.morentouxiang拷贝1;

                    //酒精
                    this.labTime.Text = string.Empty;//测试时间
                    this.labSbp.Text = "--";//收缩压
                    this.labDbp.Text = "--";//舒张压
                    this.labPulse.Text = "--";//脉搏
                    count = 0;
                    timer.Stop();
                    MessageBox.Show("时间过长,请重新登陆", "测试提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                });             
            }
        }
        #endregion
    }
}
