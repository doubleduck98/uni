using System;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;

namespace zadanie2._3._3
{
    internal class Program
    {
        private static string Haslo()
        {
            Console.WriteLine("podaj 8-znakowe hasło do zaszyfrowania:");
            var passwd = Console.ReadLine();
            if (passwd != null && passwd.Length != 8)
            {
                Console.WriteLine("hasło ma złą długość");
                Environment.Exit(0);
            }

            return passwd;
        }

        public static void Main(string[] args)
        {
            var key = new UnicodeEncoding().GetBytes(Haslo());
            
            // szyfrowanie
            using (var fsIn = new FileStream(Path.Combine(Environment.CurrentDirectory, "plik.txt"), FileMode.Open,
                FileAccess.Read))
            {
                using (var crypt = new CryptoStream(fsIn, new AesManaged().CreateEncryptor(key, key),
                    CryptoStreamMode.Read))
                {
                    using (var compressed = File.Create(fsIn.Name + ".gz"))
                    {
                        using (var gzip = new GZipStream(compressed, CompressionMode.Compress))
                        {
                            crypt.CopyTo(gzip);
                        }
                    }
                }
            }

            // odszyfrowanie
            using (var fsIn = new FileStream(Path.Combine(Environment.CurrentDirectory, "plik.txt.gz"), FileMode.Open,
                FileAccess.Read))
            {
                using (var decrypt = new CryptoStream(Console.OpenStandardOutput(),
                    new AesManaged().CreateDecryptor(key, key),
                    CryptoStreamMode.Write))
                {
                    using (var gzip = new GZipStream(fsIn, CompressionMode.Decompress))
                    {
                        gzip.CopyTo(decrypt);
                    }
                }
            }
        }
    }
}