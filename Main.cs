using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Net.NetworkInformation;

using Lz77Warpper;
using NewLife.Cryptography;

public class LogFile
{
    public static FileStream fs;

    public static Mutex mtx = new Mutex();

    public static string GetTimeStamp()
    {
        TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        return Convert.ToInt64(ts.TotalMilliseconds).ToString();
    }

    public LogFile()
    {
        string fileName = "./";
        fileName += GetTimeStamp();
        fileName += ".txt";
        fs = new FileStream(fileName, FileMode.CreateNew);
    }
    public void writeLog(string log)
    {
        mtx.WaitOne();
        fs.Write(Encoding.Default.GetBytes(log), 0, log.Length);
        fs.WriteByte(0x0A);
        fs.Flush();
        mtx.ReleaseMutex();
    }
    ~LogFile()
    {
        fs.Close();
    }
}

namespace CypherGate
{
    public class CypherGate
    {
        static public LogFile log = new LogFile();

        static public bool SafeSend(Socket S, byte[] buff)
        {
            int pos = 0;
            int sendLength = buff.Length;

            int sended = S.Send(buff, pos, sendLength, SocketFlags.None);
            if (sended <= 0)
                return false;

            pos += sended;
            sendLength -= sended;

            while (pos != buff.Length)
            {
                sended = S.Send(buff, pos, sendLength, SocketFlags.None);
                if (sended <= 0)
                    return false;

                pos += sended;
                sendLength -= sended;
            }
            return true;
        }

        static public bool rawPaser(string str, int type = 0)
        {
            switch (type)
            {
                case 0:
                    {
                        break;
                    }
                case 1:
                    {
                        break;
                    }
                case 2:
                    {
                        break;
                    }
                case 3:
                    {
                        break;
                    }
                default:
                    break;
            }

            return true;
        }

        static public void lzSocket()
        {
            string[] split = new string[1];
            split[0] = "||";

            byte[] buffer = new byte[1024 * 64];
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint server = new IPEndPoint(IPAddress.Any, 1277);
            client.Bind(server);
            client.Listen(10);

            System.Console.WriteLine("lz77 Server Started：1277");

            while (true)
            {
                Socket ASocket = client.Accept();
                string Buffer = "";

                try
                {
                    int recved = ASocket.Receive(buffer);

                    if (recved <= 0)
                    {
                        System.Console.WriteLine("lz77 Recv Error");
                        ASocket.Close();
                        continue;
                    }

                    string tmpBuffer = Encoding.Default.GetString(buffer, 0, recved);

                    Buffer += tmpBuffer;

                    log.writeLog("lz77 Recv：" + Buffer);

                    string[] strArray = Buffer.Split(split, StringSplitOptions.None);

                    if (strArray.Length == 4)
                    {
                        string XML = null;

                        if (strArray[2] == "DEC")
                        {
                            XML = lzDec(strArray[1]);
                        }
                        else
                        {
                            XML = lzEnc(strArray[1]);
                        }

                        byte[] Sending = Encoding.Default.GetBytes(XML);

                        if (!SafeSend(ASocket, Sending))
                        {
                            System.Console.WriteLine("lz77 Send Error");
                        }
                        else
                        {
                            log.writeLog("lz77 Send：" + XML);
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("lz77 Do you forgot '||' ?");
                    }
                    ASocket.Close();
                }
                catch (Exception ex)
                {
                    log.writeLog("lz77 Error：" + ex.Message);
                    ASocket.Close();
                }
            }
        }
        static public void rcSocket()
        {
            string[] split = new string[1];
            split[0] = "||";

            byte[] buffer = new byte[1024 * 64];
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint server = new IPEndPoint(IPAddress.Any, 1264);
            client.Bind(server);
            client.Listen(10);

            System.Console.WriteLine("rc4  Server Started：1264");

            while (true)
            {
                Socket ASocket = client.Accept();
                string Buffer = "";

                try
                {
                    int recved = ASocket.Receive(buffer);

                    if (recved <= 0)
                    {
                        System.Console.WriteLine("rc4 Recv Error");
                        ASocket.Close();
                        continue;
                    }

                    string tmpBuffer = Encoding.Default.GetString(buffer, 0, recved);

                    Buffer += tmpBuffer;

                    log.writeLog("rc4 Recv：" + Buffer);

                    string[] strArray = Buffer.Split(split,StringSplitOptions.None);

                    if (strArray.Length == 4)
                    {
                        string XML = null;
      
                        if (strArray[2] == "DEC")
                        {
                            XML = rc4Decrypt(strArray[0], strArray[1]);
                        }else
                        {
                            XML = rc4Encrypt(strArray[0], strArray[1]);
                        }

                        byte[] Sending = Encoding.Default.GetBytes(XML);

                        if (!SafeSend(ASocket, Sending))
                        {
                            System.Console.WriteLine("rc4 Send Error");
                        }
                        else
                        {
                            log.writeLog("rc4 Send：" + XML);
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("rc4 Do you forgot '||' ?");
                    }
                    ASocket.Close();
                }
                catch (Exception ex)
                {
                    log.writeLog("rc4 Error：" + ex.Message);
                    ASocket.Close();
                }
            }
        }
        static public void simpleSocket()
        {
            byte[] output = null;

            string[] split = new string[1];
            split[0] = "||";

            byte[] buffer = new byte[1024 * 64];
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint server = new IPEndPoint(IPAddress.Any, 573);
            client.Bind(server);
            client.Listen(10);

            System.Console.WriteLine("573  Server Started：573");

            while (true)
            {
                Socket ASocket = client.Accept();
                string Buffer = "";

                try
                {
                    int recved = ASocket.Receive(buffer);

                    if (recved <= 0)
                    {
                        System.Console.WriteLine("573 Recv Error");
                        ASocket.Close();
                        continue;
                    }

                    string tmpBuffer = Encoding.Default.GetString(buffer, 0, recved);

                    Buffer += tmpBuffer;

                    log.writeLog("573 Recv：" + Buffer);

                    string[] strArray = Buffer.Split(split, StringSplitOptions.None);

                    if (strArray.Length == 4)
                    {
                        bool    sended = false;
                        string  tmp_buffer = null;
                        bool    hex = false;
                        if (strArray[2] == "DEC")
                        {

                            Crypt573.BinaryToXML(HexByteArrayExtensionMethods.StringToByteArray(strArray[1]), ref output);

                            sended = SafeSend(ASocket, output);
                        }
                        else
                        {
                            hex = true;

                            Crypt573.XMLToBinary(HexByteArrayExtensionMethods.StringToByteArray(strArray[1]), ref output);

                            tmp_buffer = HexByteArrayExtensionMethods.ToHexString(output);

                            sended = SafeSend(ASocket, Encoding.Default.GetBytes(tmp_buffer));
                        }

                        if (!sended)
                        {
                            System.Console.WriteLine("573 Send Error");
                        }
                        else
                        {
                            log.writeLog("573 Send：" + (hex ? tmp_buffer : Encoding.Default.GetString(output)));
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("573 Do you forgot '||' ?");
                    }
                    ASocket.Close();
                }
                catch (Exception ex)
                {
                    log.writeLog("573 Error：" + ex.Message);
                    ASocket.Close();
                }
            }
        }
        static public void allSocket()
        {
            string[] split = new string[1];
            split[0] = "||";

            byte[] buffer = new byte[1024 * 64];
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint server = new IPEndPoint(IPAddress.Any, 12764);
            client.Bind(server);
            client.Listen(10);

            System.Console.WriteLine("all  Server Started：12764");

            while (true)
            {
                Socket ASocket = client.Accept();
                string Buffer = "";
                try
                {
                    int recved = ASocket.Receive(buffer);

                    if (recved <= 0)
                    {
                        System.Console.WriteLine("all Recv Error");
                        ASocket.Close();
                        continue;
                    }

                    string tmpBuffer = Encoding.Default.GetString(buffer, 0, recved);

                    Buffer += tmpBuffer;

                    log.writeLog("all Recv：" + Buffer);

                    string[] strArray = Buffer.Split(split, StringSplitOptions.None);

                    if (strArray.Length == 4)
                    {
                        string XML = null;

                        if (strArray[2] == "DEC")
                        {
                            XML = lzDec(rc4Decrypt(strArray[0], strArray[1], false));
                        }
                        else
                        {
                            XML = rc4Encrypt(strArray[0], lzEnc(strArray[1]), false);
                        }

                        byte[] Sending = Encoding.Default.GetBytes(XML);

                        if (!SafeSend(ASocket, Sending))
                        {
                            System.Console.WriteLine("all Send Error");
                        }
                        else
                        {
                            log.writeLog("all Send：" + XML);
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("all Do you forgot '||' ?");
                    }
                    ASocket.Close();
                }
                catch (Exception ex)
                {
                    log.writeLog("All Error：" + ex.Message);
                    ASocket.Close();
                }
            }
        }

        static void Main()
        {
            System.Console.WriteLine("Log version...");

            Thread th1 = new Thread(new ThreadStart(CypherGate.lzSocket));
            th1.Start();

            Thread th2 = new Thread(new ThreadStart(CypherGate.rcSocket));
            th2.Start();

            Thread th3 = new Thread(new ThreadStart(CypherGate.simpleSocket));
            th3.Start();

            Thread th4 = new Thread(new ThreadStart(CypherGate.allSocket));
            th4.Start();

            th1.Join();
            th2.Join();
            th3.Join();
            th4.Join();
        }

        static public string lzDec(string hex_string)
        {
            byte[] input = HexByteArrayExtensionMethods.StringToByteArray(hex_string);
            byte[] output = null;
            byte[] xml = null;

            Lz77Warpper.Lz77Algorithm.LZ77Decompress(input, ref output);

            if ((output.Length >= 4) && (((IPAddress.NetworkToHostOrder(BitConverter.ToInt32(output, 0)) == -1606254465) || (IPAddress.NetworkToHostOrder(BitConverter.ToInt32(output, 0)) == -1606278945)) || (IPAddress.NetworkToHostOrder(BitConverter.ToInt32(output, 0)) == -1606246305)))
            {
                Crypt573.BinaryToXML(output, ref xml);
                return Encoding.Default.GetString(xml);
            }
            else
                return Encoding.Default.GetString(output);

        }

        static public byte[] lzDec(byte[] bin)
        {
            byte[] input = bin;
            byte[] output = null;

            Lz77Warpper.Lz77Algorithm.LZ77Decompress(input, ref output);

            return output;
        }

        static public string lzEnc(string hex_string)
        {
            byte[] input = HexByteArrayExtensionMethods.StringToByteArray(hex_string);
            //byte[] input = System.Text.Encoding.ASCII.GetBytes(hex_string);
            byte[] output = null;
            byte[] ziped = null;

            string str = System.Text.Encoding.Default.GetString(input);

            Crypt573.XMLToBinary(input, ref output);

            Lz77Warpper.Lz77Algorithm.LZ77Compress(output, ref ziped);

            return HexByteArrayExtensionMethods.ToHexString(ziped);
        }

        static public string rc4Decrypt(string info, string hex_string, bool crypt573 = true)
        {
            string innerText = "AAAAAAAAaddGJ9mF7iGHFhVw0I2TsSRVA1tt8NggXfU=";
            byte[] key_k = Convert.FromBase64String(innerText);
            byte[] xml = null;

            char[] separator = new char[] { '-' };
            string[] strArray2 = info.Split(separator);
            int index = 0;
            do
            {
                key_k[index] = Convert.ToByte((strArray2[1] + strArray2[2]).Substring(index << 1, 2), 0x10);
                index++;
            }
            while (index < 6);

            byte[] key_md5 = new MD5CryptoServiceProvider().ComputeHash(key_k);
            RC4Crypto RC4 = new RC4Crypto();
            byte[] rc4 = RC4.EncryptMy(HexByteArrayExtensionMethods.StringToByteArray(hex_string), key_md5);

            if (!crypt573)
                return HexByteArrayExtensionMethods.ToHexString(rc4);

            if ((rc4.Length >= 4) && (((IPAddress.NetworkToHostOrder(BitConverter.ToInt32(rc4, 0)) == -1606254465) || (IPAddress.NetworkToHostOrder(BitConverter.ToInt32(rc4, 0)) == -1606278945)) || (IPAddress.NetworkToHostOrder(BitConverter.ToInt32(rc4, 0)) == -1606246305)))
            {
                Crypt573.BinaryToXML(rc4, ref xml);
                return Encoding.Default.GetString(xml);
            }
            else
                return Encoding.Default.GetString(rc4);
        }

        static public string rc4Encrypt(string info, string hex_string, bool crypt573 = true)
        {
            string innerText = "AAAAAAAAaddGJ9mF7iGHFhVw0I2TsSRVA1tt8NggXfU=";
            byte[] key_k = Convert.FromBase64String(innerText);
            byte[] output = null;
            char[] separator = new char[] { '-' };
            string[] strArray2 = info.Split(separator);
            int index = 0;
            do
            {
                key_k[index] = Convert.ToByte((strArray2[1] + strArray2[2]).Substring(index << 1, 2), 0x10);
                index++;
            }
            while (index < 6);

            //Crypt573.XMLToBinary(System.Text.Encoding.ASCII.GetBytes(hex_string), ref output);
            if (crypt573)
                Crypt573.XMLToBinary(HexByteArrayExtensionMethods.StringToByteArray(hex_string), ref output);
            else
                output = HexByteArrayExtensionMethods.StringToByteArray(hex_string);

            byte[] key_md5 = new MD5CryptoServiceProvider().ComputeHash(key_k);
            RC4Crypto RC4 = new RC4Crypto();
            byte[] rc4 = RC4.EncryptMy(output, key_md5);

            return HexByteArrayExtensionMethods.ToHexString(rc4);
        }

    }
}
