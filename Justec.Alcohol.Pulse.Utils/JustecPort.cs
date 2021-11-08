using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;

namespace Justec.Alcohol.Pulse.Utils
{
    public class JustecPort
    {
        private static SerialPort port = new SerialPort
        {
            BaudRate = 115200,
            ReceivedBytesThreshold = 1,
            ReadBufferSize = 50000,
            WriteBufferSize = 50000,
        };
        public static SerialPort Port
        {
            get
            {
                return port;
            }
            set
            {
                port = value;
            }
        }

        public static object lockObj = new object();


        public static string GetPortName()
        {
            try
            {
                string[] port = GetHardName.GetSerialPort();
                List<string> portLis = new List<string>(port);
                string portName = portLis.Where(p => p.Contains("Silicon Labs CP210x USB to UART Bridge")).FirstOrDefault();
                if (!string.IsNullOrWhiteSpace(portName))
                {
                    portName = portName.Substring(portName.Length - 6, 5);
                }
                else
                {
                    portName = "COM1";
                }
                return portName;
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLog($"GetPortName()读取串口名称出错: 1.错误信息 {ex.Message}\r\n 2.错误详情 { ex.StackTrace}");
                return "COM1";
            }
        }
    
        /// <summary>
        /// 串口接收数据方法2
        /// </summary>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static byte[] ReceivedData(SerialPort port)
        {
            if (port.IsOpen)
            {
                List<byte> byteList = new List<byte>();
                DateTime dateTime = DateTime.Now;
                byte[] readData = new byte[0];
                while (DateTime.Now.Subtract(dateTime).TotalMilliseconds < 10000)
                {
                    Thread.Sleep(50);
                    int length = port.BytesToRead;
                    if (length > 0)
                    {
                        readData = new byte[length];
                        port.Read(readData, 0, length);
                        byteList.AddRange(readData);
                        if (byteList[byteList.Count - 1] == '$' || Encoding.Default.GetString(byteList.ToArray()).Contains("finish")
                    || Encoding.Default.GetString(byteList.ToArray()).Contains("ok") || Encoding.Default.GetString(byteList.ToArray()).Contains("error")
                    || Encoding.Default.GetString(byteList.ToArray()).Contains("exist") || Encoding.Default.GetString(byteList.ToArray()).Contains("busy")
                    || Encoding.Default.GetString(byteList.ToArray()).Contains("start") || byteList[byteList.Count - 1] == 255
                    || Encoding.Default.GetString(byteList.ToArray()).Contains("user") || Encoding.Default.GetString(byteList.ToArray()) == "mode"
                    || Encoding.Default.GetString(byteList.ToArray()) == "timeout")
                            return byteList.ToArray();
                    }
                }
                if (readData.Length == 0)
                {
                    Console.WriteLine("接收串口数据超时!");
                }
            }
            else
            {
                Console.WriteLine("请先打开串口!");
                return null;
            }
            return null;
        }

        /// <summary>
        /// 串口接收血压数据方法
        /// </summary>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static byte[] ReceivedPluseData(SerialPort port)
        {
            if (port.IsOpen)
            {
                List<byte> byteList = new List<byte>();
                DateTime dateTime = DateTime.Now;
                byte[] readData = new byte[0];
                while (DateTime.Now.Subtract(dateTime).TotalMilliseconds < 10000)
                {
                    Thread.Sleep(600);
                    int length = port.BytesToRead;
                    if (length > 0)
                    {
                        readData = new byte[length];
                        port.Read(readData, 0, length);
                        byteList.AddRange(readData);
                        return byteList.ToArray();
                    }
                }
                if (readData.Length == 0)
                {
                    Console.WriteLine("接收串口数据超时!");
                }
            }
            else
            {
                Console.WriteLine("请先打开串口!");
                return null;
            }
            return null;
        }

        /// <summary>
        /// 串口发送指令方法(字符串)2
        /// </summary>
        /// <param name="Cmd"></param>
        public static void SendCmd(string Cmd, SerialPort port)
        {
            lock (lockObj)
            {
                if (port.IsOpen)
                {
                    port.DiscardInBuffer();
                    port.Write(Cmd);
                }
            }
        }
        /// <summary>
        /// 串口发送指令方法(数组)
        /// </summary>
        /// <param name="port"></param>
        public static void SendCmd(byte[] Cmd, SerialPort port)
        {
            lock (lockObj)
            {
                if (port.IsOpen)
                {
                    byte[] packCmd = Cmd;
                    port.DiscardInBuffer();
                    port.DiscardOutBuffer();
                    Console.WriteLine("发送指令: " + ToHexString(packCmd));
                    port.Write(packCmd, 0, packCmd.Length);
                }
            }
        }
        /// <summary>
        /// CRC算法
        /// </summary>
        /// <param name="pchMsg"></param>
        /// <param name="wDataLen"></param>
        /// <returns></returns>
        private static int CheckCRC16(byte[] pchMsg, int wDataLen)
        {
            int[] s_crc16_talble = new int[16] { 0x0000, 0xCC01, 0xD801, 0x1400, 0xF001, 0x3C00, 0x2800, 0xE401, 0xA001, 0x6C00,
                0x7800, 0xB401, 0x5000, 0x9C01, 0x8801, 0x4400, };
            int wCRC = 0xFFFF;
            byte chChar;
            for (int i = 0; i < wDataLen; i++)
            {
                chChar = pchMsg[i];
                wCRC = s_crc16_talble[(chChar ^ wCRC) & 15] ^ (wCRC >> 4);
                wCRC = s_crc16_talble[((chChar >> 4) ^ wCRC) & 15] ^ (wCRC >> 4);
            }
            return wCRC;
        }

        /// <summary>
        /// 计算校验和
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static ushort CheckSum(byte[] buffer)
        {
            ushort checkSum = 0;
            for (int i = 0; i < buffer.Length; i++)
            {
                checkSum += buffer[i];
            }
            return checkSum;
        }

        public static ushort CheckSum(string cmd)
        {
            ushort checkSum = 0;
            for (int i = 0; i < cmd.Length; i++)
            {
                checkSum += cmd[i];
            }
            return checkSum;
        }

        public static string HexCheckSum(string cmd)
        {
            if (string.IsNullOrWhiteSpace(cmd)) return "00";
            int sum = 0;
            int length = cmd.Length;
            int num = 0;
            while (num < length)
            {
                string str = cmd.Substring(num, 2);
                sum += Convert.ToInt32(str, 16);
                num += 2;
            }
            string hex = Convert.ToString(sum, 16);
            return hex.ToUpper();
        }

        /// <summary>
        /// 将byte数组转换为十六进制字符串,用空格隔开(例: 0x1A, 0x2B, 0x3C => "1A 2B 3C")
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static string ToHexString(byte[] buffer)
        {
            string hexString = "";
            for (int i = 0; i < buffer.Length; i++)
            {
                hexString += buffer[i].ToString("X2") + " ";
            }
            return hexString;
        }

        //在串口通讯过程中，经常要用到 16进制与字符串、字节数组之间的转换
        public static byte[] HexStringToBytes(string hs)
        {
            byte[] b = new byte[hs.Length];
            //逐个字符变为16进制字节数据
            for (int i = 0; i < hs.Length; i++)
            {
                b[i] = Convert.ToByte(hs[i]);
            }
            //按照指定编码将字节数组变为字符串
            return b;
        }

        /// <summary>
        /// 将十六进制字符串转换为byte数组(例: "1A2B3C" or "1A 2B 3C" => 0x1A, 0x2B, 0x3C)
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static byte[] ToHexBytes(string hexString)
        {
            try
            {
                if (string.IsNullOrEmpty(hexString)) return null;
                hexString = hexString.Replace(" ", "");
                if (hexString.Length % 2 != 0) hexString = "0" + hexString;
                byte[] bytes = new byte[hexString.Length / 2];
                for (int i = 0; i < hexString.Length; i++)
                {
                    if (i % 2 == 0)
                        bytes[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
                }
                return bytes;
            }
            catch
            {
                throw new Exception("转换失败, 输入字符串错误!");
            }
        }

        public static List<DeviceInfo> GetUSBDevices()
        {
            List<DeviceInfo> devices = new List<DeviceInfo>();

            ManagementObjectCollection collection;
            using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_USBHub"))
            {
                collection = searcher.Get();
            }

            foreach (var device in collection)
            {
                devices.Add(new DeviceInfo
                {
                    DeviceID= (string)device.GetPropertyValue("DeviceID"),
                    PNPDeviceID= (string)device.GetPropertyValue("PNPDeviceID"),
                    Description= (string)device.GetPropertyValue("Description")
                });
            }

            collection.Dispose();
            return devices;
        }
        public class DeviceInfo
        {
            public string DeviceID { get; set; }
            public string PNPDeviceID { get; set; }
            public string Description { get; set; }
        }
    }

}
