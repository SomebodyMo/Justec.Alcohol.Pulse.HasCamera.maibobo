using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Justec.Alcohol.Pulse.Utils
{
    public class FormAutoSize
    {
        public FormAutoSize(string formName)
        {
            FormName = formName;
            if (formName == "AlcoholData")
            {
                UpdateControl.Add("酒测容器", "gbData");
                UpdateControl.Add("酒测上容器", "topPanel");
                UpdateControl.Add("酒测右容器", "rightPanel");
                UpdateControl.Add("酒测表格", "dgvAlcohol");
                UpdateControl.Add("分页", "dataGridPager1");
                //UpdateControl.Add("分页左部", "pageLeft");
                //UpdateControl.Add("分页右部", "pageRight");
            }
            if(FormName== "UserManage")
            {
                UpdateControl.Add("右侧容器", "rightContainer");

                UpdateControl.Add("数据容器", "dataBox");
                UpdateControl.Add("信息容器", "rightPanel");
                UpdateControl.Add("消息提示", "TxtMsg");
                UpdateControl.Add("分页", "dataGridPager1");
                UpdateControl.Add("用户表格", "DGV1");
                UpdateControl.Add("左侧树", "deptTree");
            }
            if (FormName == "TransSet")
            {
                UpdateControl.Add("顶层容器", "topPanel");
                UpdateControl.Add("数据表格", "trainDGV");
            }
            if (formName == "Main")
            {
                UpdateControl.Add("顶层容器", "topPanel");
                UpdateControl.Add("测酒容器", "checkDataBox");
                UpdateControl.Add("底层容器", "bottomStrip");
            }

        }
        // 定义一个控件编号，初始化变量为0，表示窗体本身；后续的为各个控件的编号。
        int CtrNo = 0;

        public String FormName = "";

        /// <summary>
        /// 变化的控件名称
        /// </summary>
        public Dictionary<string, string> UpdateControl = new Dictionary<string, string>();

        /// <summary>
        /// 原始控件字典集合
        /// </summary>
        public Dictionary<string, ControlProperty> OriginalControl = new Dictionary<string, ControlProperty>();

        /// <summary>
        /// 原始控件基本属性        
        /// </summary>

        public struct ControlProperty
        {
            public int Left;
            public int Top;
            public int Width;
            public int Height;
            public float FontSize;
        }
        //收集控件的属性到集合中
        public void AddControlToList(Control control)
        {
            ControlProperty Ctp = new ControlProperty();    //新建一个控件属性结构体的实例
            //遍历当前引入的控件集
            foreach (Control c in control.Controls)
            {
                //判断是否更新
                if (UpdateControl.ContainsValue(c.Name))
                {
                    Ctp.Left = c.Left;
                    Ctp.Top = c.Top;
                    Ctp.Width = c.Width;
                    Ctp.Height = c.Height;
                    Ctp.FontSize = c.Font.Size;
                    OriginalControl.Add(c.Name, Ctp);
                }
                if (c.Controls.Count > 0)
                {
                    AddControlToList(c); //递归
                }
            }
        }
        // 窗体自适应分辨率
        public void ControlAutoSize(Control MainForm)
        {

            if (CtrNo == 0)
            {
                ControlProperty Ctp = new ControlProperty();
                Ctp.Left = MainForm.Left;
                Ctp.Top = MainForm.Top;
                Ctp.Height = MainForm.Height;
                Ctp.Width = MainForm.Width;
                //Ctp.FontSize = MainForm.Font.Size;
                //先把主窗体的属性加入到集合
                OriginalControl.Add("OriginalForm", Ctp);
                //添加辅窗体控件属性到集合
                AddControlToList(MainForm);
            }
            //求取分辨率的缩放比例
            float WidthScale = (float)MainForm.Width / (float)OriginalControl["OriginalForm"].Width;
            float HightScale = (float)MainForm.Height / (float)OriginalControl["OriginalForm"].Height;
            CtrNo = 1; ;//第0个为窗体本身,窗体内的控件,从序号1开始
            AutoScaleControl(MainForm, WidthScale, HightScale);//窗体内其余控件还可能嵌套控件(比如panel),要单独抽出,因为要递归调用
        }

        private void AutoScaleControl(Control mForm, float wScale, float hScale)
        {
            foreach (Control c in mForm.Controls)
            {
                CtrNo++;//累加序号
                //酒测数据界面FrmAlcoholData
                if(FormName == "AlcoholData")
                {
                    if (c.Name == UpdateControl["酒测上容器"])
                    {
                        c.Left = (mForm.Width - OriginalControl["topPanel"].Width - OriginalControl["rightPanel"].Width - 30) / 2;
                    }
                    else if (c.Name == UpdateControl["酒测容器"])
                    {
                        c.Width = mForm.Width - 17;
                        c.Height = mForm.Height - OriginalControl["gbData"].Top - 41;
                    }
                    else if (c.Name == UpdateControl["酒测表格"])
                    {
                        c.Width = mForm.Width - OriginalControl["rightPanel"].Width - 20;
                        c.Height = mForm.Height - OriginalControl["dataGridPager1"].Height - 15;
                    }
                    else if (c.Name == UpdateControl["分页"])
                    {
                        c.Top = mForm.Height - OriginalControl["dataGridPager1"].Height - 2;
                        c.Width = mForm.Width - 6;
                    }
                    //else if (c.Name == UpdateControl["分页右部"])
                    //{
                    //    c.Left = mForm.Width - OriginalControl["pageRight"].Width - OriginalControl["rightPanel"].Width;
                    //}
                    else if (c.Name == UpdateControl["酒测右容器"])
                    {
                        c.Left = mForm.Width - OriginalControl["rightPanel"].Width - 5;
                    }                  
                }
                //人员数据
                else if (FormName == "UserManage")
                {
                    if(c.Name == UpdateControl["右侧容器"])
                    {
                        c.Width = mForm.Width - OriginalControl["deptTree"].Width - 25;
                        c.Height = mForm.Height - 44;
                    }
                    else if (c.Name == UpdateControl["数据容器"])
                    {
                        c.Width= mForm.Width;
                        c.Height = mForm.Height - OriginalControl["dataBox"].Top;
                    }
                    else if (c.Name == UpdateControl["信息容器"])
                    {
                        c.Left= mForm.Width - OriginalControl["rightPanel"].Width - 6;
                        c.Height = mForm.Height - OriginalControl["rightPanel"].Top - OriginalControl["dataGridPager1"].Height - 4;
                    }
                    else if (c.Name == UpdateControl["消息提示"])
                    {
                        c.Height = mForm.Height - OriginalControl["TxtMsg"].Top - 3;
                    }
                    else if (c.Name == UpdateControl["用户表格"])
                    {
                        c.Width = mForm.Width - OriginalControl["rightPanel"].Width - 16;
                        c.Height = mForm.Height - OriginalControl["dataGridPager1"].Height - 17;
                    }
                    else if (c.Name == UpdateControl["左侧树"])
                    {
                        c.Height = mForm.Height - 44;
                    }
                    else if (c.Name == UpdateControl["分页"])
                    {
                        c.Top = mForm.Height - OriginalControl["dataGridPager1"].Height - 2;
                        c.Width = mForm.Width - 5;
                    }
                }
                //出乘配置
                else if(FormName== "TransSet")
                {
                    if (c.Name == UpdateControl["顶层容器"])
                    {
                        c.Left = (mForm.Width - c.Width - 19) / 2;
                    }
                    else if (c.Name == UpdateControl["数据表格"])
                    {
                        c.Width = mForm.Width - 22;
                        c.Height = mForm.Height - 95;
                    }
                }
                //首界面
                else if (FormName == "Main")
                {
                    if (c.Name == UpdateControl["顶层容器"])
                    {
                        c.Width = mForm.Width - 2;
                    }
                    else if (c.Name == UpdateControl["测酒容器"])
                    {
                        c.Left = (mForm.Width - OriginalControl["checkDataBox"].Width) / 2 - 8;
                        c.Top = (mForm.Height - 498) / 2 + 40;
                    }
                    else if (c.Name == UpdateControl["底层容器"])
                    {
                        c.Width = mForm.Width - 8;
                    }
                }
                //**放在这里，是先缩放控件本身，后缩放控件的子控件，重点是前后要一致（与保存时）
                if (c.Controls.Count > 0)
                    AutoScaleControl(c, wScale, hScale);//窗体内其余控件还可能嵌套控件(比如panel),要单独抽出,因为要递归调用
            }
        }
    }
}
