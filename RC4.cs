﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NewLife.Cryptography
{
    /// <summary>
    /// 加密类基类
    /// </summary>
    public class CryptoBase
    {
        /// <summary>
        /// 编码转换器，用于字节码和字符串之间的转换，默认为本机编码
        /// </summary>
        static public Encoding Encode = Encoding.Default;
        public enum EncoderMode { Base64Encoder, HexEncoder };

        /// <summary>
        /// 带编码模式的字符串加密
        /// </summary>
        /// <param name="data">要加密的数据</param>
        /// <param name="pass">密码</param>
        /// <param name="em">编码模式</param>
        /// <returns>加密后经过编码的字符串</returns>
        public String Encrypt(String data, String pass, CryptoBase.EncoderMode em)
        {
            if (data == null || pass == null) return null;
            if (em == EncoderMode.Base64Encoder)
                return Convert.ToBase64String(EncryptEx(Encode.GetBytes(data), pass));
            else
                return ByteToHex(EncryptEx(Encode.GetBytes(data), pass));
        }

        /// <summary>
        /// 带编码模式的字符串解密
        /// </summary>
        /// <param name="data">要解密的数据</param>
        /// <param name="pass">密码</param>
        /// <param name="em">编码模式</param>
        /// <returns>明文</returns>
        public String Decrypt(String data, String pass, CryptoBase.EncoderMode em)
        {
            if (data == null || pass == null) return null;
            if (em == EncoderMode.Base64Encoder)
                return Encode.GetString(DecryptEx(Convert.FromBase64String(data), pass));
            else
                return Encode.GetString(DecryptEx(HexToByte(data), pass));
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="data">要加密的数据</param>
        /// <param name="pass">密码</param>
        /// <returns>加密后经过默认编码的字符串</returns>
        public String Encrypt(String data, String pass)
        {
            return Encrypt(data, pass, EncoderMode.Base64Encoder);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="data">要解密的经过编码的数据</param>
        /// <param name="pass">密码</param>
        /// <returns>明文</returns>
        public String Decrypt(String data, String pass)
        {
            return Decrypt(data, pass, EncoderMode.Base64Encoder);
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="data">要加密的数据</param>
        /// <param name="pass">密钥</param>
        /// <returns>密文</returns>
        virtual public Byte[] EncryptEx(Byte[] data, String pass) { return null; }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="data">要解密的数据</param>
        /// <param name="pass">密码</param>
        /// <returns>明文</returns>
        virtual public Byte[] DecryptEx(Byte[] data, String pass) { return null; }

        static public Byte[] HexToByte(String szHex)
        {
            // 两个十六进制代表一个字节
            Int32 iLen = szHex.Length;
            if (iLen <= 0 || 0 != iLen % 2)
            {
                return null;
            }
            Int32 dwCount = iLen / 2;
            UInt32 tmp1, tmp2;
            Byte[] pbBuffer = new Byte[dwCount];
            for (Int32 i = 0; i < dwCount; i++)
            {
                tmp1 = (UInt32)szHex[i * 2] - (((UInt32)szHex[i * 2] >= (UInt32)'A') ? (UInt32)'A' - 10 : (UInt32)'0');
                if (tmp1 >= 16) return null;
                tmp2 = (UInt32)szHex[i * 2 + 1] - (((UInt32)szHex[i * 2 + 1] >= (UInt32)'A') ? (UInt32)'A' - 10 : (UInt32)'0');
                if (tmp2 >= 16) return null;
                pbBuffer[i] = (Byte)(tmp1 * 16 + tmp2);
            }
            return pbBuffer;
        }

        static public String ByteToHex(Byte[] vByte)
        {
            if (vByte == null || vByte.Length < 1) return null;
            StringBuilder sb = new StringBuilder(vByte.Length * 2);
            for (int i = 0; i < vByte.Length; i++)
            {
                if ((UInt32)vByte[i] < 0) return null;
                UInt32 k = (UInt32)vByte[i] / 16;
                sb.Append((Char)(k + ((k > 9) ? 'A' - 10 : '0')));
                k = (UInt32)vByte[i] % 16;
                sb.Append((Char)(k + ((k > 9) ? 'A' - 10 : '0')));
            }
            return sb.ToString();
        }
    }

    interface ICrypto
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="data">要加密的数据</param>
        /// <param name="pass">密钥</param>
        /// <returns>密文</returns>
        Byte[] EncryptEx(Byte[] data, String pass);

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="data">要解密的数据</param>
        /// <param name="pass">密码</param>
        /// <returns>明文</returns>
        Byte[] DecryptEx(Byte[] data, String pass);
    }
}


namespace NewLife.Cryptography
{
    public class RC4Crypto : CryptoBase
    {
        static public RC4Crypto RC4 = new RC4Crypto();

        public override Byte[] EncryptEx(Byte[] data, String pass)
        {
            if (data == null || pass == null) return null;
            Byte[] output = new Byte[data.Length];
            Int64 i = 0;
            Int64 j = 0;
            Byte[] mBox = GetKey(Encode.GetBytes(pass), 256);

            // 加密
            for (Int64 offset = 0; offset < data.Length; offset++)
            {
                i = (i + 1) % mBox.Length;
                j = (j + mBox[i]) % mBox.Length;
                Byte temp = mBox[i];
                mBox[i] = mBox[j];
                mBox[j] = temp;
                Byte a = data[offset];
                //Byte b = mBox[(mBox[i] + mBox[j] % mBox.Length) % mBox.Length];
                // mBox[j] 一定比 mBox.Length 小，不需要在取模
                Byte b = mBox[(mBox[i] + mBox[j]) % mBox.Length];
                output[offset] = (Byte)((Int32)a ^ (Int32)b);
            }

            return output;
        }

        public Byte[] EncryptMy(Byte[] data, Byte[] pass)
        {
            if (data == null || pass == null) return null;
            Byte[] output = new Byte[data.Length];
            Int64 i = 0;
            Int64 j = 0;
            Byte[] mBox = GetKey(pass, 256);

            // 加密
            for (Int64 offset = 0; offset < data.Length; offset++)
            {
                i = (i + 1) % mBox.Length;
                j = (j + mBox[i]) % mBox.Length;
                Byte temp = mBox[i];
                mBox[i] = mBox[j];
                mBox[j] = temp;
                Byte a = data[offset];
                //Byte b = mBox[(mBox[i] + mBox[j] % mBox.Length) % mBox.Length];
                // mBox[j] 一定比 mBox.Length 小，不需要在取模
                Byte b = mBox[(mBox[i] + mBox[j]) % mBox.Length];
                output[offset] = (Byte)((Int32)a ^ (Int32)b);
            }

            return output;
        }

        public override Byte[] DecryptEx(Byte[] data, String pass)
        {
            return EncryptEx(data, pass);
        }

        /// <summary>
        /// 打乱密码
        /// </summary>
        /// <param name="pass">密码</param>
        /// <param name="kLen">密码箱长度</param>
        /// <returns>打乱后的密码</returns>
        static private Byte[] GetKey(Byte[] pass, Int32 kLen)
        {
            Byte[] mBox = new Byte[kLen];

            for (Int64 i = 0; i < kLen; i++)
            {
                mBox[i] = (Byte)i;
            }
            Int64 j = 0;
            for (Int64 i = 0; i < kLen; i++)
            {
                j = (j + mBox[i] + pass[i % pass.Length]) % kLen;
                Byte temp = mBox[i];
                mBox[i] = mBox[j];
                mBox[j] = temp;
            }
            return mBox;
        }
    }
}