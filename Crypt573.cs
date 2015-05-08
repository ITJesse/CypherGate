using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Net;
using System.Collections;
using System.Text.RegularExpressions;

public class i_Comparer : IComparer
{
    public int Compare(object x, object y)
    {
        int num2;
        int num3;
        byte[] bytes = Encoding.ASCII.GetBytes((string)x);
        byte[] buffer = Encoding.ASCII.GetBytes((string)y);
        int length = buffer.Length;
        int num4 = bytes.Length;
        if (num4 < length)
        {
            num3 = num4;
        }
        else
        {
            num3 = length;
        }
        int index = 0;
        if (0 < num3)
        {
            do
            {
                byte num7 = bytes[index];
                byte num6 = buffer[index];
                if (num7 < num6)
                {
                    num2 = -1;
                    goto Label_0067;
                }
                if (num7 > num6)
                {
                    num2 = 1;
                    goto Label_0067;
                }
                index++;
            }
            while (index < num3);
        }
        goto Label_006B;
    Label_0067:
        if (index < num3)
        {
            return num2;
        }
    Label_006B:
        if (num4 < length)
        {
            return -1;
        }
        return (num4 > length) ? 1 : 0;
    }
}


namespace CypherGate
{
    class Crypt573
    {
        public static string localEncoding = "UTF-8";

        public class workNode
        {
            public XmlNode m_node;
            public XmlNode m_nodeorg;
            public string m_xpath;

            public workNode(XmlNode node, string xpath)
            {
                m_nodeorg = node;
                m_node = node.SelectSingleNode(xpath);
                m_xpath = xpath;
            }

            public void buildnode()
            {
                char[] separator = new char[] { '/' };
                string[] strArray = m_xpath.Split(separator);
                if (strArray[0] == "")
                {
                    m_node = m_nodeorg.OwnerDocument;
                }
                else
                {
                    m_node = m_nodeorg;
                }
                int index = 0;
                if (0 < strArray.Length)
                {
                    do
                    {
                        string name = strArray[index];
                        if (name != "")
                        {
                            if (name.IndexOf("@") >= 0)
                            {
                                string str2 = name.Replace("@", "");
                                if (m_node.Attributes[str2] == null)
                                {
                                    m_node.Attributes.Append(m_node.OwnerDocument.CreateAttribute(str2));
                                }
                                m_node = m_node.Attributes[str2];
                            }
                            else
                            {
                                if (m_node[name] == null)
                                {
                                    m_node.AppendChild(m_node.OwnerDocument.CreateElement(name));
                                }
                                m_node = m_node[name];
                            }
                        }
                        index++;
                    }
                    while (index < strArray.Length);
                }
            }

            public XmlNode Build
            {
                get
                {
                    if (m_node == null)
                    {
                        buildnode();
                    }
                    XmlNode node = m_node;
                    if (node != null)
                    {
                        return node;
                    }
                    return null;
                }
            }

            public string InnerText
            {
                get
                {
                    XmlNode node = m_node;
                    if (node != null)
                    {
                        return node.InnerText;
                    }
                    return null;
                }
                set
                {
                    if (m_node == null)
                    {
                        buildnode();
                    }
                    m_node.InnerText = value;
                }
            }

            public string InnerXml
            {
                get
                {
                    XmlNode node = m_node;
                    if (node != null)
                    {
                        return node.InnerXml;
                    }
                    return null;
                }
                set
                {
                    if (m_node == null)
                    {
                        buildnode();
                    }
                    m_node.InnerXml = value;
                }
            }

            public XmlNode Item
            {
                get
                {
                    XmlNode node = m_node;
                    if (node != null)
                    {
                        return node;
                    }
                    return null;
                }
                set
                {
                    if (m_node == null)
                    {
                        buildnode();
                    }
                    m_node = value;
                }
            }

            public string Value
            {
                get
                {
                    XmlNode node = m_node;
                    if (node != null)
                    {
                        return node.Value;
                    }
                    return null;
                }
                set
                {
                    if (m_node == null)
                    {
                        buildnode();
                    }
                    m_node.Value = value;
                }
            }
        }

        public static workNode node(XmlNode node, string xpath)
        {
            return new workNode(node, xpath);
        }

        static public void BinaryToXML(byte[] input, ref byte[] output)
        {
            int startIndex = 0;
            int datae = 0;
            XmlDocument node = new XmlDocument();
            XmlDeclaration newChild = node.CreateXmlDeclaration("1.0", localEncoding, null);
            node.InsertBefore(newChild, node.DocumentElement);
            int nodep = 8;
            if (4 <= (input.Length - 4))
            {
                startIndex = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(input, 4)) + 8;
            }
            int datap = startIndex + 4;
            int wordp = datap;
            int bytep = datap;
            if (startIndex <= (input.Length - 4))
            {
                datae = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(input, startIndex)) + datap;
            }
            BinaryToXMLnode(input, ref nodep, ref datap, ref bytep, ref wordp, startIndex, datae, node);
            output = Encoding.GetEncoding(localEncoding).GetBytes(node.OuterXml);
        }

        static public void XMLToBinary(byte[] input, ref byte[] output)
        {
            string[] array = null;
            byte num;
            string[] strArray2 = null;
            int num2;
            byte[] destinationArray = new byte[4];
            byte[] buffer2 = new byte[0x1000];
            byte[] buffer3 = new byte[4];
            byte[] buffer4 = new byte[0x1000];
            string[] strArray3 = new string[] { "s8", "u8", "s16", "u16", "s32", "u32", "s64", "u64", "bin", "str", "ip4", "time", "bool" };
            string[] strArray4 = new string[] { "__type", "__count", "__size" };
            int[] numArray = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 0x34 };
            int newSize = 0;
            int datap = 0;
            int wordp = 0;
            int bytep = 0;
            XmlDocument document = new XmlDocument();
            document.LoadXml(System.Text.Encoding.GetEncoding(localEncoding).GetString(input));

            byte[] bytes = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(-1606254465));
            int num7 = 0;
            XmlNode documentElement = document.DocumentElement;
        Label_0135:
            if (num7 != 0)
            {
                int num8;
                newSize = (newSize + 3) & -4;
                if (buffer2.Length < newSize)
                {
                    Array.Resize<byte>(ref buffer2, newSize);
                }
                if (bytep > wordp)
                {
                    num8 = bytep;
                }
                else
                {
                    num8 = wordp;
                }
                int num9 = (((num8 <= datap) ? datap : num8) + 3) & -4;
                if (buffer4.Length < num9)
                {
                    Array.Resize<byte>(ref buffer4, num9);
                }
                Array.Copy(BitConverter.GetBytes(IPAddress.HostToNetworkOrder(newSize)), 0, destinationArray, 0, 4);
                Array.Copy(BitConverter.GetBytes(IPAddress.HostToNetworkOrder(num9)), 0, buffer3, 0, 4);
                Array.Resize<byte>(ref output, (bytes.Length + ((destinationArray.Length + num9) + buffer3.Length)) + newSize);
                Array.Copy(bytes, 0, output, 0, bytes.Length);
                Array.Copy(destinationArray, 0, output, bytes.Length, destinationArray.Length);
                Array.Copy(buffer2, 0, output, destinationArray.Length + bytes.Length, newSize);
                Array.Copy(buffer3, 0, output, bytes.Length + (newSize + destinationArray.Length), buffer3.Length);
                Array.Copy(buffer4, 0, output, bytes.Length + ((destinationArray.Length + newSize) + buffer3.Length), num9);
                return;
            }
            string str = new workNode(documentElement, "@__type").Value;
            string str2 = new workNode(documentElement, "@__count").Value;
            string str3 = new workNode(documentElement, "@__size").Value;
            string innerText = documentElement.InnerText;
            if (documentElement.HasChildNodes && (documentElement.FirstChild.NodeType != XmlNodeType.Text))
            {
                num2 = 1;
            }
            else
            {
                num2 = 0;
                if ((str != null) || (innerText != ""))
                {
                    int num10 = Array.IndexOf<string>(strArray3, str);
                    if (num10 < 0)
                    {
                        num10 = 9;
                        str = strArray3[9];
                    }
                    num = (byte)numArray[num10];
                    if (((num < 10) || (num == 0x34)) && (str2 != null))
                    {
                        num = (byte)(num | 0x40);
                    }
                    goto Label_02EA;
                }
            }
            num = 1;
        Label_02EA:
            XMLToBinaryNode(num, documentElement.Name, ref buffer2, ref newSize);
            if (num2 == 0)
            {
                if (str2 != null)
                {
                    Convert.ToInt32(str2);
                }
                if (str3 != null)
                {
                    Convert.ToInt32(str3);
                }
                if ((str != null) || (innerText != ""))
                {
                    char[] separator = new char[] { ' ' };
                    string[] strArray5 = innerText.Split(separator);
                    innerText = innerText.Trim();
                    switch (Array.IndexOf<string>(strArray3, str))
                    {
                        case 0:
                            {
                                if (str2 == null)
                                {
                                    XMLToBinarySetBytes((long)Convert.ToSByte(strArray5[0]), ref buffer4, ref datap, ref wordp, ref bytep, 1);
                                    break;
                                }
                                int length = strArray5.Length;
                                byte[] data = new byte[length];
                                int num12 = 0;
                                if (0 < length)
                                {
                                    do
                                    {
                                        data[num12] = (byte)Convert.ToSByte(strArray5[num12]);
                                        num12++;
                                    }
                                    while (num12 < strArray5.Length);
                                }
                                XMLToBinarySetData(ref data, ref buffer4, ref datap);
                                break;
                            }
                        case 1:
                            {
                                if (str2 == null)
                                {
                                    XMLToBinarySetBytes((long)Convert.ToByte(strArray5[0]), ref buffer4, ref datap, ref wordp, ref bytep, 1);
                                    break;
                                }
                                int num13 = strArray5.Length;
                                byte[] buffer7 = new byte[num13];
                                int num14 = 0;
                                if (0 < num13)
                                {
                                    do
                                    {
                                        buffer7[num14] = Convert.ToByte(strArray5[num14]);
                                        num14++;
                                    }
                                    while (num14 < strArray5.Length);
                                }
                                XMLToBinarySetData(ref buffer7, ref buffer4, ref datap);
                                break;
                            }
                        case 2:
                            {
                                if (str2 == null)
                                {
                                    XMLToBinarySetBytes((long)Convert.ToInt16(strArray5[0]), ref buffer4, ref datap, ref wordp, ref bytep, 2);
                                    break;
                                }
                                int num15 = strArray5.Length;
                                byte[] buffer8 = new byte[num15 << 1];
                                int num16 = 0;
                                if (0 < num15)
                                {
                                    do
                                    {
                                        Array.Copy(BitConverter.GetBytes(IPAddress.HostToNetworkOrder(Convert.ToInt16(strArray5[num16]))), 0, buffer8, num16 << 1, 2);
                                        num16++;
                                    }
                                    while (num16 < strArray5.Length);
                                }
                                XMLToBinarySetData(ref buffer8, ref buffer4, ref datap);
                                break;
                            }
                        case 3:
                            {
                                if (str2 == null)
                                {
                                    XMLToBinarySetBytes((long)Convert.ToUInt16(strArray5[0]), ref buffer4, ref datap, ref wordp, ref bytep, 2);
                                    break;
                                }
                                int num17 = strArray5.Length;
                                byte[] buffer9 = new byte[num17 << 1];
                                int num18 = 0;
                                if (0 < num17)
                                {
                                    do
                                    {
                                        Array.Copy(BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)Convert.ToUInt16(strArray5[num18]))), 0, buffer9, num18 << 1, 2);
                                        num18++;
                                    }
                                    while (num18 < strArray5.Length);
                                }
                                XMLToBinarySetData(ref buffer9, ref buffer4, ref datap);
                                break;
                            }
                        case 4:
                            {
                                if (str2 == null)
                                {
                                    XMLToBinarySetBytes((long)Convert.ToInt32(strArray5[0]), ref buffer4, ref datap, ref wordp, ref bytep, 4);
                                    break;
                                }
                                int num19 = strArray5.Length;
                                byte[] buffer10 = new byte[num19 << 2];
                                int num20 = 0;
                                if (0 < num19)
                                {
                                    do
                                    {
                                        Array.Copy(BitConverter.GetBytes(IPAddress.HostToNetworkOrder(Convert.ToInt32(strArray5[num20]))), 0, buffer10, num20 << 2, 4);
                                        num20++;
                                    }
                                    while (num20 < strArray5.Length);
                                }
                                XMLToBinarySetData(ref buffer10, ref buffer4, ref datap);
                                break;
                            }
                        case 5:
                            {
                                if (str2 == null)
                                {
                                    XMLToBinarySetBytes((long)Convert.ToUInt32(strArray5[0]), ref buffer4, ref datap, ref wordp, ref bytep, 4);
                                    break;
                                }
                                int num21 = strArray5.Length;
                                byte[] buffer11 = new byte[num21 << 2];
                                int num22 = 0;
                                if (0 < num21)
                                {
                                    do
                                    {
                                        Array.Copy(BitConverter.GetBytes(IPAddress.HostToNetworkOrder((int)Convert.ToUInt32(strArray5[num22]))), 0, buffer11, num22 << 2, 4);
                                        num22++;
                                    }
                                    while (num22 < strArray5.Length);
                                }
                                XMLToBinarySetData(ref buffer11, ref buffer4, ref datap);
                                break;
                            }
                        case 6:
                            {
                                if (str2 == null)
                                {
                                    XMLToBinarySetBytes(Convert.ToInt64(strArray5[0]), ref buffer4, ref datap, ref wordp, ref bytep, 8);
                                    break;
                                }
                                int num23 = strArray5.Length;
                                byte[] buffer12 = new byte[num23 << 3];
                                int num24 = 0;
                                if (0 < num23)
                                {
                                    do
                                    {
                                        Array.Copy(BitConverter.GetBytes(IPAddress.HostToNetworkOrder(Convert.ToInt64(strArray5[num24]))), 0, buffer12, num24 << 3, 8);
                                        num24++;
                                    }
                                    while (num24 < strArray5.Length);
                                }
                                XMLToBinarySetData(ref buffer12, ref buffer4, ref datap);
                                break;
                            }
                        case 7:
                            {
                                if (str2 == null)
                                {
                                    XMLToBinarySetBytes((long)Convert.ToUInt64(strArray5[0]), ref buffer4, ref datap, ref wordp, ref bytep, 8);
                                    break;
                                }
                                int num25 = strArray5.Length;
                                byte[] buffer13 = new byte[num25 << 3];
                                int num26 = 0;
                                if (0 < num25)
                                {
                                    do
                                    {
                                        Array.Copy(BitConverter.GetBytes(IPAddress.HostToNetworkOrder((long)Convert.ToUInt64(strArray5[num26]))), 0, buffer13, num26 << 3, 8);
                                        num26++;
                                    }
                                    while (num26 < strArray5.Length);
                                }
                                XMLToBinarySetData(ref buffer13, ref buffer4, ref datap);
                                break;
                            }
                        case 8:
                            {
                                byte[] buffer14 = new byte[(innerText.Length + 1) / 2];
                                int num27 = 0;
                                if (0 < buffer14.Length)
                                {
                                    do
                                    {
                                        buffer14[num27] = Convert.ToByte(innerText.Substring(num27 << 1, 2), 0x10);
                                        num27++;
                                    }
                                    while (num27 < buffer14.Length);
                                }
                                XMLToBinarySetData(ref buffer14, ref buffer4, ref datap);
                                break;
                            }
                        case 9:
                            {
                                byte[] buffer15 = Encoding.GetEncoding(localEncoding).GetBytes(innerText + "\0");
                                XMLToBinarySetData(ref buffer15, ref buffer4, ref datap);
                                break;
                            }
                        case 10:
                            {
                                byte[] addressBytes = IPAddress.Parse(innerText).GetAddressBytes();
                                XMLToBinarySetBytes((long)BitConverter.ToUInt32(addressBytes, 0), ref buffer4, ref datap, ref wordp, ref bytep, 4);
                                break;
                            }
                        case 11:
                            XMLToBinarySetBytes((long)Convert.ToUInt32(strArray5[0]), ref buffer4, ref datap, ref wordp, ref bytep, 4);
                            break;

                        case 12:
                            {
                                if (str2 == null)
                                {
                                    XMLToBinarySetBytes((long)Convert.ToByte(strArray5[0]), ref buffer4, ref datap, ref wordp, ref bytep, 1);
                                    break;
                                }
                                int num28 = strArray5.Length;
                                byte[] buffer17 = new byte[num28];
                                int num29 = 0;
                                if (0 < num28)
                                {
                                    do
                                    {
                                        buffer17[num29] = Convert.ToByte(strArray5[num29]);
                                        num29++;
                                    }
                                    while (num29 < strArray5.Length);
                                }
                                XMLToBinarySetData(ref buffer17, ref buffer4, ref datap);
                                break;
                            }
                    }
                }
            }
            array = new string[documentElement.Attributes.Count];
            strArray2 = new string[array.Length];
            int index = 0;
            foreach (XmlAttribute attribute in documentElement.Attributes)
            {
                if (Array.IndexOf<string>(strArray4, attribute.Name) < 0)
                {
                    array[index] = attribute.Name;
                    strArray2[index] = attribute.Value;
                    index++;
                }
            }
            if (array.Length != index)
            {
                Array.Resize<string>(ref array, index);
                Array.Resize<string>(ref strArray2, index);
            }
            IComparer comparer = new i_Comparer();
            Array.Sort(array, strArray2, comparer);
            int num31 = 0;
            if (0 < array.Length)
            {
                do
                {
                    XMLToBinaryNode(0x2e, array[num31], ref buffer2, ref newSize);
                    byte[] buffer18 = Encoding.GetEncoding(localEncoding).GetBytes(strArray2[num31] + "\0");
                    XMLToBinarySetData(ref buffer18, ref buffer4, ref datap);
                    num31++;
                }
                while (num31 < array.Length);
            }
            if (num2 != 0)
            {
                documentElement = documentElement.FirstChild;
                goto Label_0135;
            }
            if (num7 != 0)
            {
                goto Label_0135;
            }
            int num32 = newSize + 1;
        Label_0996:
            if (buffer2.Length < num32)
            {
                Array.Resize<byte>(ref buffer2, num32);
            }
            buffer2[newSize] = 0xfe;
            newSize++;
            num32++;
            XmlNode nextSibling = documentElement.NextSibling;
            if (nextSibling == null)
            {
                if (documentElement.ParentNode.GetType() != typeof(XmlDocument))
                {
                    documentElement = documentElement.ParentNode;
                    goto Label_0996;
                }
                int num33 = newSize + 1;
                if (buffer2.Length < num33)
                {
                    Array.Resize<byte>(ref buffer2, num33);
                }
                buffer2[newSize] = 0xff;
                newSize = num33;
                num7 = 1;
            }
            else
            {
                documentElement = nextSibling;
            }
            goto Label_0135;
        }

        static protected void BinaryToXMLGetBytes(byte[] bin, ref int datap, ref int bytep, ref int wordp, int size, ref byte[] @out)
        {
            int num;
            if ((bytep % 4) == 0)
            {
                bytep = datap;
            }
            if ((wordp % 4) == 0)
            {
                wordp = datap;
            }
            Array.Resize<byte>(ref @out, size);
            if ((size != 4) && (size != 8))
            {
                if (size == 2)
                {
                    Array.Copy(bin, wordp, @out, 0, 2);
                    Array.Reverse(@out);
                    wordp += 2;
                }
                else
                {
                    Array.Copy(bin, bytep, @out, 0, size);
                    Array.Reverse(@out);
                    bytep += size;
                }
            }
            else
            {
                Array.Copy(bin, datap, @out, 0, size);
                Array.Reverse(@out);
                datap += size;
            }
            int num2 = bytep;
            int num3 = wordp;
            if (num2 > num3)
            {
                num = num2;
            }
            else
            {
                num = num3;
            }
            if (datap < num)
            {
                datap = (num + 3) & -4;
            }
        }

        static protected void BinaryToXMLGetData(byte[] bin, ref int datap, ref int bytep, ref int wordp, ref byte[] @out)
        {
            int newSize = 0;
            int startIndex = datap;
            if (startIndex <= (bin.Length - 4))
            {
                newSize = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(bin, startIndex));
            }
            Array.Resize<byte>(ref @out, newSize);
            Array.Copy(bin, datap + 4, @out, 0, newSize);
            datap = ((newSize + datap) + 7) & -4;
        }

        static protected void BinaryToXMLnode(byte[] bin, ref int nodep, ref int datap, ref int bytep, ref int wordp, int nodee, int datae, XmlNode node)
        {
            try
            {
                int length;
                string str = null;
                int num = 0;
                string name = null;
                byte[] @out = new byte[0];
                byte[] buffer2 = new byte[0];
                int num2 = 0;
                if (nodep >= nodee)
                {
                    return;
                }
            Label_0023:
                if (num2 != 0)
                {
                    return;
                }
                if (bin[nodep] == 0)
                {
                    do
                    {
                        int num3 = nodep;
                        if (num3 >= nodee)
                        {
                            break;
                        }
                        nodep = num3 + 1;
                    }
                    while (bin[nodep] == 0);
                }
                int index = nodep;
                byte num5 = bin[index];
                nodep = index + 1;
                switch (num5)
                {
                    case 0xfe:
                    case 0xff:
                        break;

                    default:
                        {
                            byte len = bin[index + 1];
                            nodep = (index + 1) + 1;
                            DecompressBits(bin, ref @out, ref nodep, len, 6);
                            int num7 = 0;
                            int num8 = len;
                            if (0 < num8)
                            {
                                do
                                {
                                    byte num9 = @out[num7];
                                    if (num9 < 11)
                                    {
                                        @out[num7] = (byte)(num9 + 0x30);
                                    }
                                    else if (num9 < 0x25)
                                    {
                                        @out[num7] = (byte)(num9 + 0x36);
                                    }
                                    else
                                    {
                                        int num10 = (num9 < 0x26) ? 0x3a : 0x3b;
                                        @out[num7] = (byte)(num9 + num10);
                                    }
                                    num7++;
                                }
                                while (num7 < num8);
                            }
                            name = Encoding.ASCII.GetString(@out);
                            break;
                        }
                }
                string str3 = "";
                string str4 = str3;
                byte num11 = (byte)(num5 & 0x40);
                switch ((num5 & 0xbf))
                {
                    case 190:
                        if (node.ParentNode != null)
                        {
                            node = node.ParentNode;
                        }
                        goto Label_08DE;

                    case 0xbf:
                        num2 = 1;
                        goto Label_08DE;

                    case 0x34:
                        {
                            str4 = "bool";
                            if (num11 == 0)
                            {
                                goto Label_0897;
                            }
                            BinaryToXMLGetData(bin, ref datap, ref bytep, ref wordp, ref buffer2);
                            str = "";
                            byte[] buffer5 = buffer2;
                            int num24 = 0;
                            if (0 < buffer2.Length)
                            {
                                do
                                {
                                    byte num25 = buffer5[num24];
                                    str = str + Convert.ToString(num25) + " ";
                                    num24++;
                                }
                                while (num24 < buffer5.Length);
                            }
                            char[] trimChars = new char[] { ' ' };
                            str = str.TrimEnd(trimChars);
                            num = buffer2.Length;
                            goto Label_08DE;
                        }
                    case 1:
                        if (!(node.GetType() != typeof(XmlDocument)))
                        {
                            break;
                        }
                        node = node.AppendChild(node.OwnerDocument.CreateElement(name));
                        goto Label_08DE;

                    case 2:
                        str4 = "s8";
                        if (num11 != 0)
                        {
                            BinaryToXMLGetData(bin, ref datap, ref bytep, ref wordp, ref buffer2);
                            str = "";
                            byte[] buffer3 = buffer2;
                            int num12 = 0;
                            if (0 < buffer2.Length)
                            {
                                do
                                {
                                    byte num13 = buffer3[num12];
                                    str = str + Convert.ToString((int)((sbyte)num13)) + " ";
                                    num12++;
                                }
                                while (num12 < buffer3.Length);
                            }
                            char[] chArray = new char[] { ' ' };
                            str = str.TrimEnd(chArray);
                            num = buffer2.Length;
                        }
                        else
                        {
                            BinaryToXMLGetBytes(bin, ref datap, ref bytep, ref wordp, 1, ref buffer2);
                            str = Convert.ToString((int)((sbyte)buffer2[0]));
                        }
                        goto Label_08DE;

                    case 3:
                        str4 = "u8";
                        if (num11 != 0)
                        {
                            BinaryToXMLGetData(bin, ref datap, ref bytep, ref wordp, ref buffer2);
                            str = "";
                            byte[] buffer4 = buffer2;
                            int num14 = 0;
                            if (0 < buffer2.Length)
                            {
                                do
                                {
                                    byte num15 = buffer4[num14];
                                    str = str + Convert.ToString(num15) + " ";
                                    num14++;
                                }
                                while (num14 < buffer4.Length);
                            }
                            char[] chArray2 = new char[] { ' ' };
                            str = str.TrimEnd(chArray2);
                            num = buffer2.Length;
                        }
                        else
                        {
                            BinaryToXMLGetBytes(bin, ref datap, ref bytep, ref wordp, 1, ref buffer2);
                            str = Convert.ToString(buffer2[0]);
                        }
                        goto Label_08DE;

                    case 4:
                        str4 = "s16";
                        if (num11 != 0)
                        {
                            BinaryToXMLGetData(bin, ref datap, ref bytep, ref wordp, ref buffer2);
                            str = "";
                            int startIndex = 0;
                            if (0 < buffer2.Length)
                            {
                                do
                                {
                                    str = str + Convert.ToString(IPAddress.NetworkToHostOrder(BitConverter.ToInt16(buffer2, startIndex))) + " ";
                                    startIndex += 2;
                                }
                                while (startIndex < buffer2.Length);
                            }
                            char[] chArray3 = new char[] { ' ' };
                            str = str.TrimEnd(chArray3);
                            num = buffer2.Length / 2;
                        }
                        else
                        {
                            BinaryToXMLGetBytes(bin, ref datap, ref bytep, ref wordp, 2, ref buffer2);
                            str = Convert.ToString(BitConverter.ToInt16(buffer2, 0));
                        }
                        goto Label_08DE;

                    case 5:
                        str4 = "u16";
                        if (num11 != 0)
                        {
                            BinaryToXMLGetData(bin, ref datap, ref bytep, ref wordp, ref buffer2);
                            str = "";
                            int num17 = 0;
                            if (0 < buffer2.Length)
                            {
                                do
                                {
                                    str = str + Convert.ToString((ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(buffer2, num17))) + " ";
                                    num17 += 2;
                                }
                                while (num17 < buffer2.Length);
                            }
                            char[] chArray4 = new char[] { ' ' };
                            str = str.TrimEnd(chArray4);
                            num = buffer2.Length / 2;
                        }
                        else
                        {
                            BinaryToXMLGetBytes(bin, ref datap, ref bytep, ref wordp, 2, ref buffer2);
                            str = Convert.ToString(BitConverter.ToUInt16(buffer2, 0));
                        }
                        goto Label_08DE;

                    case 6:
                        str4 = "s32";
                        if (num11 != 0)
                        {
                            BinaryToXMLGetData(bin, ref datap, ref bytep, ref wordp, ref buffer2);
                            str = "";
                            int num18 = 0;
                            if (0 < buffer2.Length)
                            {
                                do
                                {
                                    str = str + Convert.ToString(IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer2, num18))) + " ";
                                    num18 += 4;
                                }
                                while (num18 < buffer2.Length);
                            }
                            char[] chArray5 = new char[] { ' ' };
                            str = str.TrimEnd(chArray5);
                            num = buffer2.Length / 4;
                        }
                        else
                        {
                            BinaryToXMLGetBytes(bin, ref datap, ref bytep, ref wordp, 4, ref buffer2);
                            str = Convert.ToString(BitConverter.ToInt32(buffer2, 0));
                        }
                        goto Label_08DE;

                    case 7:
                        str4 = "u32";
                        if (num11 != 0)
                        {
                            BinaryToXMLGetData(bin, ref datap, ref bytep, ref wordp, ref buffer2);
                            str = "";
                            int num19 = 0;
                            if (0 < buffer2.Length)
                            {
                                do
                                {
                                    str = str + Convert.ToString((uint)IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer2, num19))) + " ";
                                    num19 += 4;
                                }
                                while (num19 < buffer2.Length);
                            }
                            char[] chArray6 = new char[] { ' ' };
                            str = str.TrimEnd(chArray6);
                            num = buffer2.Length / 4;
                        }
                        else
                        {
                            BinaryToXMLGetBytes(bin, ref datap, ref bytep, ref wordp, 4, ref buffer2);
                            str = Convert.ToString(BitConverter.ToUInt32(buffer2, 0));
                        }
                        goto Label_08DE;

                    case 8:
                        str4 = "s64";
                        if (num11 != 0)
                        {
                            BinaryToXMLGetData(bin, ref datap, ref bytep, ref wordp, ref buffer2);
                            str = "";
                            int num20 = 0;
                            if (0 < buffer2.Length)
                            {
                                do
                                {
                                    str = str + Convert.ToString(IPAddress.NetworkToHostOrder(BitConverter.ToInt64(buffer2, num20))) + " ";
                                    num20 += 8;
                                }
                                while (num20 < buffer2.Length);
                            }
                            char[] chArray7 = new char[] { ' ' };
                            str = str.TrimEnd(chArray7);
                            num = buffer2.Length / 8;
                        }
                        else
                        {
                            BinaryToXMLGetBytes(bin, ref datap, ref bytep, ref wordp, 8, ref buffer2);
                            str = Convert.ToString(BitConverter.ToInt64(buffer2, 0));
                        }
                        goto Label_08DE;

                    case 9:
                        str4 = "u64";
                        if (num11 != 0)
                        {
                            BinaryToXMLGetData(bin, ref datap, ref bytep, ref wordp, ref buffer2);
                            str = "";
                            int num21 = 0;
                            if (0 < buffer2.Length)
                            {
                                do
                                {
                                    str = str + Convert.ToString((ulong)IPAddress.NetworkToHostOrder(BitConverter.ToInt64(buffer2, num21))) + " ";
                                    num21 += 8;
                                }
                                while (num21 < buffer2.Length);
                            }
                            char[] chArray8 = new char[] { ' ' };
                            str = str.TrimEnd(chArray8);
                            num = buffer2.Length / 8;
                        }
                        else
                        {
                            BinaryToXMLGetBytes(bin, ref datap, ref bytep, ref wordp, 8, ref buffer2);
                            str = Convert.ToString(BitConverter.ToUInt64(buffer2, 0));
                        }
                        goto Label_08DE;

                    case 10:
                        str4 = "bin";
                        BinaryToXMLGetData(bin, ref datap, ref bytep, ref wordp, ref buffer2);
                        str3 = Convert.ToString(buffer2.Length);
                        str = BitConverter.ToString(buffer2).Replace("-", "");
                        goto Label_08DE;

                    case 11:
                        str4 = "str";
                        BinaryToXMLGetData(bin, ref datap, ref bytep, ref wordp, ref buffer2);
                        str3 = Convert.ToString(buffer2.Length);
                        length = buffer2.Length;
                        goto Label_0741;

                    case 12:
                        str4 = "ip4";
                        BinaryToXMLGetBytes(bin, ref datap, ref bytep, ref wordp, 4, ref buffer2);
                        str = new IPAddress(buffer2).ToString();
                        goto Label_08DE;

                    case 13:
                        str4 = "time";
                        BinaryToXMLGetBytes(bin, ref datap, ref bytep, ref wordp, 4, ref buffer2);
                        str = string.Format("{0}", BitConverter.ToUInt32(buffer2, 0));
                        goto Label_08DE;

                    case 0x2e:
                        BinaryToXMLGetData(bin, ref datap, ref bytep, ref wordp, ref buffer2);
                        for (int i = buffer2.Length; i > 0; i = buffer2.Length)
                        {
                            if (buffer2[i - 1] != 0)
                            {
                                break;
                            }
                            Array.Resize<byte>(ref buffer2, i - 1);
                        }
                        str = Encoding.GetEncoding(localEncoding).GetString(buffer2);
                        node.Attributes.Append(node.OwnerDocument.CreateAttribute(name));
                        node.Attributes[name].Value = str;
                        goto Label_08DE;

                    default:
                        goto Label_08DE;
                }
                node = node.AppendChild(((XmlDocument)node).CreateElement(name));
                goto Label_08DE;
            Label_0724:
                if (buffer2[length - 1] != 0)
                {
                    goto Label_08CB;
                }
                Array.Resize<byte>(ref buffer2, length - 1);
                length = buffer2.Length;
            Label_0741:
                if (length > 0)
                {
                    goto Label_0724;
                }
                goto Label_08CB;
            Label_0897:
                BinaryToXMLGetBytes(bin, ref datap, ref bytep, ref wordp, 1, ref buffer2);
                str = Convert.ToString(buffer2[0]);
                goto Label_08DE;
            Label_08CB:
                str = Encoding.GetEncoding(localEncoding).GetString(buffer2);
            Label_08DE:
                if (str4 != "")
                {
                    node = node.AppendChild(node.OwnerDocument.CreateElement(name));
                    node.Attributes.Append(node.OwnerDocument.CreateAttribute("__type"));
                    node.Attributes["__type"].Value = str4;
                    if (str3 != "")
                    {
                        node.Attributes.Append(node.OwnerDocument.CreateAttribute("__size"));
                        node.Attributes["__size"].Value = str3;
                    }
                    if (num11 == 0x40)
                    {
                        node.Attributes.Append(node.OwnerDocument.CreateAttribute("__count"));
                        node.Attributes["__count"].Value = Convert.ToString(num);
                    }
                    node.InnerText = str;
                }
                if (nodep < nodee)
                {
                    goto Label_0023;
                }
            }
            catch (ArgumentException exception)
            {
                System.Console.WriteLine("Exception：" + exception.Message);
            }
        }

        static protected void XMLToBinaryNode(byte kind, string name, ref byte[] @out, ref int pt)
        {
            int newSize = pt + 1;
            if (@out.Length < newSize)
            {
                Array.Resize<byte>(ref @out, newSize);
            }
            @out[pt] = kind;
            pt++;
            CompressBits(name, ref @out, ref pt, 6);
        }

        static protected void XMLToBinarySetBytes(long data, ref byte[] @out, ref int datap, ref int wordp, ref int bytep, int size)
        {
            int num;
            if ((bytep % 4) == 0)
            {
                bytep = datap;
            }
            if ((wordp % 4) == 0)
            {
                wordp = datap;
            }
            switch (size)
            {
                case 1:
                    {
                        int newSize = size + bytep;
                        if (@out.Length < newSize)
                        {
                            Array.Resize<byte>(ref @out, newSize);
                        }
                        @out[bytep] = (byte)((int)data);
                        bytep += size;
                        break;
                    }
                case 2:
                    {
                        int num3 = size + wordp;
                        if (@out.Length < num3)
                        {
                            Array.Resize<byte>(ref @out, num3);
                        }
                        Array.Copy(BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)((int)data))), 0, @out, wordp, size);
                        wordp += size;
                        break;
                    }
                case 4:
                    {
                        int num4 = size + datap;
                        if (@out.Length < num4)
                        {
                            Array.Resize<byte>(ref @out, num4);
                        }
                        Array.Copy(BitConverter.GetBytes(IPAddress.HostToNetworkOrder((int)data)), 0, @out, datap, size);
                        datap += size;
                        break;
                    }
                case 8:
                    {
                        int num5 = size + datap;
                        if (@out.Length < num5)
                        {
                            Array.Resize<byte>(ref @out, num5);
                        }
                        Array.Copy(BitConverter.GetBytes(IPAddress.HostToNetworkOrder(data)), 0, @out, datap, size);
                        datap += size;
                        break;
                    }
            }
            int num6 = bytep;
            int num7 = wordp;
            if (num6 > num7)
            {
                num = num6;
            }
            else
            {
                num = num7;
            }
            if (datap < num)
            {
                datap = (num + 3) & -4;
            }
        }

        static protected void XMLToBinarySetData(ref byte[] data, ref byte[] @out, ref int pt)
        {
            int num = data.Length + 4;
            int newSize = num + pt;
            if (@out.Length < newSize)
            {
                Array.Resize<byte>(ref @out, newSize);
            }
            Array.Copy(BitConverter.GetBytes(IPAddress.HostToNetworkOrder(data.Length)), 0, @out, pt, 4);
            byte[] sourceArray = data;
            Array.Copy(sourceArray, 0, @out, pt + 4, sourceArray.Length);
            pt = ((num + pt) + 3) & -4;
        }

        static protected void DecompressBits(byte[] bin, ref byte[] @out, ref int pt, int len, byte bits)
        {
            int index = 0;
            int num2 = 0;
            Array.Resize<byte>(ref @out, 0);
            if (0 < len)
            {
                int num3 = bits;
                do
                {
                    byte num4 = 0;
                    if (0 < num3)
                    {
                        int num5 = pt;
                        uint num6 = (uint)num3;
                        do
                        {
                            num4 = (byte)(((bin[(num2 / 8) + num5] >> ((byte)(7 - (num2 % 8)))) & 1) | ((byte)(num4 << 1)));
                            num2++;
                            num6--;
                        }
                        while (num6 > 0);
                    }
                    Array.Resize<byte>(ref @out, index + 1);
                    @out[index] = num4;
                    index++;
                }
                while (index < len);
            }
            pt += (num2 + 7) / 8;
        }

        static protected void CompressBits(string str, ref byte[] @out, ref int pt, byte bits)
        {
            int num = 0;
            byte[] bytes = Encoding.ASCII.GetBytes(str);
            int num2 = (((bytes.Length * bits) + 7) / 8) + 1;
            int newSize = num2 + pt;
            if (@out.Length < newSize)
            {
                Array.Resize<byte>(ref @out, newSize);
            }
            @out[pt] = (byte)bytes.Length;
            int index = pt + 1;
            Array.Clear(@out, index, num2 - 1);
            int num5 = 0;
            if (0 < bytes.Length)
            {
                do
                {
                    byte num6 = bytes[num5];
                    if (((byte)(num6 + 0xd0)) <= 10)
                    {
                        num6 = (byte)(num6 - 0x30);
                    }
                    else if (((byte)(num6 + 0xbf)) <= 0x19)
                    {
                        num6 = (byte)(num6 - 0x36);
                    }
                    else if (num6 == 0x5f)
                    {
                        num6 = (byte)(num6 - 0x3a);
                    }
                    else if (((byte)(num6 + 0x9f)) <= 0x19)
                    {
                        num6 = (byte)(num6 - 0x3b);
                    }
                    else
                    {
                        num6 = 0;
                    }
                    int num7 = bits;
                    int num8 = num7;
                    if (0 < num8)
                    {
                        int num9 = num7 - 1;
                        uint num10 = (uint)num8;
                        do
                        {
                            int num11 = index + (num / 8);
                            byte[] buffer2 = @out;
                            buffer2[num11] = (byte)(buffer2[num11] | (((num6 >> (((byte)num9) & 0x1f)) & 1) << (7 - (num % 8))));
                            num++;
                            num9--;
                            num10--;
                        }
                        while (num10 > 0);
                    }
                    num5++;
                }
                while (num5 < bytes.Length);
            }
            pt += num2;
        }

    }
}
