using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Hosting;

namespace GGF.Common
{
    public static class CommonCode
    {
        public static byte[] GetSaltKey()
        {
            byte[] saltKey = { 26, 136, 215, 210, 15, 205, 185, 42, 161, 239, 171, 16, 85, 196, 133, 133, 17, 197, 71, 177, 109, 124, 220, 35, 54, 52, 145, 196, 131, 17, 88, 197 };
            return saltKey;
        }
        public static string HashPassword(string password, byte[] saltKey = null)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            byte[] dst = new byte[0x31];

            if (saltKey == null)
            {
                using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
                {
                    salt = bytes.Salt;
                    buffer2 = bytes.GetBytes(0x20);
                }
                Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
                Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            }
            //DGG20200131
            else
            {
                using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, saltKey, 0x3e8))
                {
                    salt = bytes.Salt;
                    buffer2 = bytes.GetBytes(0x31);
                }
                //Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
                Buffer.BlockCopy(buffer2, 0, dst, 0, 0x31);
            }
            return Convert.ToBase64String(dst);
        }
        public static string NewToken()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray()) i *= ((int)b + 1);
            return MD5(string.Format("{0:x}", i - DateTime.Now.Ticks));
        }
        public static string MD5(string word)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(word));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
        public static void Log(Exception ex, string extra = null)
        {
            string path = HostingEnvironment.MapPath("~");
            string sLogFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";
            string sYear = DateTime.Now.Year.ToString();
            string sMonth = DateTime.Now.Month.ToString();
            string sDay = DateTime.Now.Day.ToString();
            string sErrorTime = sYear + sMonth + sDay;
            string xpath = path + "/Logs/";
            if (!Directory.Exists(xpath))
            {
                Directory.CreateDirectory(xpath);
            }
            StreamWriter sw = new StreamWriter(path + "/Logs/Log_" + sErrorTime + ".txt", true);
            sw.WriteLine(sLogFormat);
            sw.WriteLine(ex.Message);
            if (ex.InnerException != null)
            {
                sw.WriteLine(ex.InnerException.Message);
            }
            sw.WriteLine(ex.StackTrace);

            if (extra != null)
                sw.WriteLine(extra);
            sw.Flush();
            sw.Close();
        }
    }
}