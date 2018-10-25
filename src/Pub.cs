using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DefaultNamespace
{
    class Pub
    {
        //16*5���ַ�
        private static String CODE = "lfG:,3CaAb0FBcDHh4^&7]Iig2M5.TkLvW!@6mKNJ8Pjnp9[OuZosy$tUYQq{};dE#1eV%wXx*()RrSz";
        private static String hText = "0123456789ABCDEF";
        private static String[] Bins = { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111" };
        /// <summary>
        /// �ַ�������
        /// </summary>
        /// <param name="source">ԭʼ����</param>
        /// <returns>�����ַ���</returns>
        public static String Encode(String source)
        {
            if(source == null || source == "")
                return "";
            
            Random rd = new Random();
            StringBuilder stb = new StringBuilder();
            int head = CODE.Length / 16 + (int)(rd.NextDouble() * CODE.Length / 16);
            int foot = CODE.Length / 16 + (int)(rd.NextDouble() * CODE.Length / 16);

            for(int i = 0; i < head; i++)
                stb.Append(CODE[(int)(rd.NextDouble() * 16) + 16 * (int)(rd.NextDouble() * CODE.Length / 16)]);

            for (int i = 0; i < source.Length; i++)
                stb.Append(CODE[source[i] / 16 + 16 * (int)(rd.NextDouble() * CODE.Length / 16)]).Append(CODE[source[i] % 16 + 16 * (int)(rd.NextDouble() * CODE.Length / 16)]);

            for(int i = 0; i < foot; i++)
                stb.Append(CODE[(int)(rd.NextDouble() * 16) + 16 * (int)(rd.NextDouble() * CODE.Length / 16)]);

            stb.Append(CODE[head]).Append(CODE[foot]);

            return stb.ToString();
        }
        /// <summary>
        /// �ַ�������
        /// </summary>
        /// <param name="source">�����ַ���</param>
        /// <returns>ԭʼ����</returns>
        public static String Decode(String source)
        {
            if(source == null || source == "")
                return "";
            String ret = "";
            StringBuilder stb = new StringBuilder();
            int head = CODE.IndexOf(source[source.Length - 2]) % 16;
            int foot = CODE.IndexOf(source[source.Length - 1]) % 16;
            source = source.Substring(head);
            source = source.Substring(0, source.Length - 2 - foot);

            for (int i = 0; i < source.Length; i += 2)
            {
                stb.Append((char)(CODE.IndexOf(source[i]) % 16 * 16 + CODE.IndexOf(source[i + 1]) % 16));
            }
            return stb.ToString();
        }
        /// <summary>
        /// ʮ���� ת���� ʮ������, ʮ�������ַ���д
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static String DecToHex(int num)
        {
            String hex = "";
            do
            {
                hex = hText[num % 16 + 1].ToString() + hex;
                num /= 16;
            }
            while(num > 16);
            return hex;
        }
        /// <summary>
        /// ʮ���� ת���� ʮ������,���ض����ַ�,ʮ�������ַ���д
        /// </summary>
        /// <param name="num"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static String DecToHexFix(int num, int len)
        {
            String hex = DecToHex(num);
            if(hex.Length > len)
                hex = hex.Substring(hex.Length - len, len);
            else
            {
                while(hex.Length < len)
                    hex = "0" + hex;
            }
            return hex;
        }
        /// <summary>
        /// ʮ������ ת���� ʮ����,ʮ�������ַ���д
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static int HexToDec(String hex)
        {
            int num = 0;
            for(int i = 1; i <= hex.Length; i++)
            {
                char ch = hex[hex.Length - i];
                int indent = hText.IndexOf(ch);
                for(int j = 1; j < i; j++)
                    indent *= 16;
                num += indent;
            }
            return num;
        }
        /// <summary>
        /// ʮ������ ת���� ������ ʮ�������ַ���д
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static String HexToBin(String hex)
        {
            StringBuilder stb = new StringBuilder();
            for(int i = 0; i < hex.Length; i++)
                stb.Append(Bins[hText.IndexOf(hex[i])]);
            return stb.ToString();
        }
        /// <summary>
        /// ��ʮ���� ת�� �ٽ���, 30 = 0.5
        /// </summary>
        /// <param name="sixty"></param>
        /// <returns></returns>
        public static double SixtyToHundred(double sixty)
        {
            return sixty / 60;
        }
        /// <summary>
        /// ����/Сʱ ת�� ��
        /// </summary>
        /// <param name="kms"></param>
        /// <returns></returns>
        public static int KmsToKts(int kms)
        {
            return (int)(kms / 1.852);
        }
        /// <summary>
        /// �� ת���� ����/Сʱ
        /// </summary>
        /// <param name="kts"></param>
        /// <returns></returns>
        public static int KtsToKms(int kts)
        {
            return (int)(kts * 1.852);
        }
        /// <summary>
        /// ʵʮ������ ת���� ʮ�������ַ����� ÿ���ֽ���λ
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static String RealHexToHex(String str)
        {
            StringBuilder bin = new StringBuilder();
            for(int i = 0; i < str.Length; i++ )
            {
                bin.Append(hText[str[i] / 16]).Append(hText[str[i] % 16]);
            }
            return bin.ToString();
        }
        /// <summary>
        /// ʵʮ������ ת���� ʮ�������ַ����� ÿ���ֽ���λ
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static String RealHexToStr(String str)
        {
            StringBuilder bin = new StringBuilder();
            for(int i = 0; i < str.Length; i++)
            {
                bin.Append(hText[str[i] / 16]).Append(hText[str[i] % 16]).Append(' ');
            }
            return bin.ToString();
        }
        /// <summary>
        /// ʵʮ������ ת���� ʮ����
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static long RealHexToDec(String hex)
        {
            long ret = 0;
            while(hex.Length > 0)
            {
                ret = ret * 16 + hex[1];
                hex.Remove(1, 1);
            }
            return ret;
        }
        /// <summary>
        /// ʵʮ������ ת���� �������ַ���
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static String RealHexToBin(String hex)
        {
            String[] bins = { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111" };
            StringBuilder bin = new StringBuilder();
            for(int i = 0; i < hex.Length; i++)
                bin.Append(bins[hex[i] / 16]).Append(bins[hex[i] % 16]);
            return bin.ToString();
        }
        /// <summary>
        /// ʱ���
        /// </summary>
        /// <param name="dt1">ʱ��1</param>
        /// <param name="dt2">ʱ��2</param>
        /// <returns>��������</returns>
        public static long DateDiff(DateTime dt1, DateTime dt2)
        {
            if(dt2.CompareTo(dt1) < 0)
                return -1;
            else
            {
                TimeSpan ts = dt2 - dt1;
                long n = ts.Days * 24 * 3600;
                n += ts.Hours * 3600;
                n += ts.Minutes * 60;
                n += ts.Seconds;
                return n;
            }
        }

        //����ʱ���
        public static string datetimeDiff(DateTime tS, DateTime tE)
        {
            string dateDiff = null;
            TimeSpan ts1 = new TimeSpan(tS.Ticks);

            TimeSpan ts2 = new TimeSpan(tE.Ticks);

            TimeSpan ts = ts1.Subtract(ts2).Duration();

            dateDiff = ts.Days.ToString() + "��"
                           + ts.Hours.ToString() + "Сʱ"
                           + ts.Minutes.ToString() + "����"
                           + ts.Seconds.ToString() + "��";
            return dateDiff;
        }
        /// <summary>
        /// ��ǰ����ʱ���ַ���
        /// </summary>
        public static String DateTimeStr
        {
            get
            {
                return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        /// <summary>
        /// ��ǰ�����ַ���
        /// </summary>
        public static String DateStr
        {
            get
            {
                return DateTime.Now.ToString("yyyy-MM-dd");
            }
        }
        /// <summary>
        /// �ַ���BCD����
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int CharToBCD(char c)
        {
            return c / 16 * 10 + c % 16;
        }
        /// <summary>
        /// �ַ�����BCD����
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static long StrToBCD(string s)
        {
            long m = 0;
            int x = 1;
            for(int i = s.Length - 1; i >= 0; i--)
            {
                m = s[i] % 16 * x;
                x *= 10;
                m = s[i] / 16 * x;
                x *= 10;
            }
            return m;
        }
        /// <summary>
        /// BCDת�����ַ���
        /// </summary>
        /// <param name="s">BCD�ַ���</param>
        /// <returns>ת�����ַ���</returns>
        public static String BCDToStr(String s)
        {
            StringBuilder stb = new StringBuilder();
            foreach(char c in s)
                stb.Append((char)(c / 256)).Append((char)(c % 256));
            return stb.ToString();
        }

        //����ն˱��
        public static bool checkMachineNo(string mno)
        {
            Regex reg = new Regex("^[0|1|2|5|6|8][0-9]{8}$");
            if (reg.IsMatch(mno))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //����ն��ͺ�
        public static bool checkMachineType(string mtype)
        {
            //�ն����ͺ�:0:�綯��,1:����,2:Ħ�г�
            if (mtype == "0" ||
                mtype == "1" ||
                mtype == "2" ||
                mtype == "5" ||
                mtype == "6" ||
                mtype == "8")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //����ն�Э��汾��
        public static bool checkMachinePVersion(string mpv)
        {
            //�汾��,WΪ���ʰ汾(ΪUnicode����),NΪ����
            if (mpv == "V1" ||
                mpv == "B1" || 
                mpv == "A1" || 
                mpv.StartsWith("W"))  
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //�������ȼ�(�Ƿ��)
        public static int checkPwdLevel(string pwd)
        {
            int n = 0;
            if (pwd.Length >= 8)
            {
                if ((new Regex("\\d")).IsMatch(pwd)) n++;
                if (pwd == "12345678" || pwd == "87654321") n--;
                if ((new Regex("[a-zA-Z]")).IsMatch(pwd)) n++;
                if ((new Regex("\\W")).IsMatch(pwd)) n++;
            }

            return n;
        }

        //���GPS|GSM|POWER��
        public static bool checkGGP(String sGGP)
        {
            Regex machobj = new Regex("^\\d{3}$");
            if (machobj.IsMatch(sGGP))
            {
                return true;
            }
            return false;
        }
        //����GPS|GSM|POWER��
        public static void parseGGP(String sGGP, ref int gps, ref int gsm, ref int power)
        {
            String value = sGGP.Substring(0, 1);
            gps = Int32.Parse(value);
            value = sGGP.Substring(1, 1);
            gsm = Int32.Parse(value);
            value = sGGP.Substring(2, 1);
            power = Int32.Parse(value);
        }


        /** 16�������е�λ���ֽ����� */
        private static byte[] hex = Encoding.Default.GetBytes("0123456789ABCDEF");

        /**
        * �������ֽ�����ת��
        * 
        * @param n Ҫת��������
        * @return
        */
        public static byte[] int2bytes(int n)
        {
            byte[] ab = new byte[4];
            ab[0] = (byte)(0xff & n);
            ab[1] = (byte)((0xff00 & n) >> 8);
            ab[2] = (byte)((0xff0000 & n) >> 16);
            ab[3] = (byte)((0xff000000 & n) >> 24);
            return ab;
        }

        /**
         * �����͵��ֽ�����ת��
        * @param n ������
        * @return
        */
        public static byte[] short2bytes(short n)
        {
            byte[] b = new byte[2];
            b[0] = (byte)((n & 0xFF00) >> 8);
            b[1] = (byte)(n & 0xFF);
            return b;
        }

        /**
        * �ֽ�����ת���ɶ�����
        * 
        * @param b �ֽ�����
        * @return
        */
        public static short bytes2short(byte[] b)
        {
            short n = (short)(((b[0] < 0 ? b[0] + 256:b[0]) << 8) + (b[1] < 0 ? b[1] + 256:b[1]));
            return n;
        }

        /**
         * �ֽ����鵽������ת��
        * @param b �ֽ�����
        * @return
        */
        public static int bytes2int(byte[] b)
        {
            int s = 0;

            s = ((((b[0] & 0xff) << 8 | (b[1] & 0xff)) << 8) | (b[2] & 0xff)) << 8
                    | (b[3] & 0xff);
            return s;
        }

        /**
        * �ֽ�ת�����ַ�
        * 
        * @param b �ֽ�
        * @return
        */
        public static char byte2char(byte b)
        {
            return (char)b;
        }

        /**
        * 16����charת��������
        * 
        * @param c
        * @return
        */
        public static int parse(char c)
        {
            if (c >= 'a')
                return (c - 'a' + 10) & 0x0f;
            if (c >= 'A')
                return (c - 'A' + 10) & 0x0f;
            return (c - '0') & 0x0f;
        }

        /**
        * �ֽ�����ת����ʮ�������ַ���
        * 
        * @param b
        * @return
        */
        public static String Bytes2HexString(byte[] b)
        {
            int length = b.Length;
            byte[] buff = new byte[2 * length];
            for (int i = 0; i < length; i++)
            {
                buff[2 * i] = hex[(b[i] >> 4) & 0x0f];
                buff[2 * i + 1] = hex[b[i] & 0x0f];
            }
            return Encoding.Default.GetString(buff);
        }

        public static String Bytes2HexString(byte[] b, int count)
        {
            int length = Math.Min(b.Length, count);
            byte[] buff = new byte[2 * length];
            for (int i = 0; i < length; i++)
            {
                buff[2 * i] = hex[(b[i] >> 4) & 0x0f];
                buff[2 * i + 1] = hex[b[i] & 0x0f];
            }
            return Encoding.Default.GetString(buff);
        }

        /**
        * ʮ�������ַ���ת�����ֽ�����
        * 
        * @param hexstr
        * @return
        */
        public static byte[] HexString2Bytes(String hexstr)
        {
            byte[] b = new byte[hexstr.Length / 2];
            int j = 0;
            for (int i = 0; i < b.Length; i++)
            {
                char c0 = hexstr[j++];
                char c1 = hexstr[j++];
                b[i] = (byte)((parse(c0) << 4) | parse(c1));
            }
            return b;
        }
    }
}
