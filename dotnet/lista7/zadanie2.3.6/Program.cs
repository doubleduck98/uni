using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace zadanie2._3._6
{
    [Serializable()]
    public class Obiekt : ISerializable
    {
        public string Wiadomosc;

        public Obiekt()
        {
            Wiadomosc = string.Empty;
        }

        public Obiekt(string msg)
        {
            Wiadomosc = msg;
        }

        public Obiekt(SerializationInfo info, StreamingContext context)
        {
            Wiadomosc = (string) info.GetValue("Wiadomosc", typeof(string));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Wiadomosc", Wiadomosc);
        }

        public override string ToString()
        {
            return Wiadomosc;
        }
    }

    internal static class Program
    {
        private static void Serwer()
        {
            try
            {
                var server = new TcpListener(IPAddress.Parse("127.0.0.1"), 7171);
                server.Start();
                
                // czekam na tylko jedno połączenie
                var client = server.AcceptTcpClient();
                Console.WriteLine("Nadchodzące połączenie.");

                var bf = new BinaryFormatter();
                var o = (Obiekt) bf.Deserialize(client.GetStream());
                Console.WriteLine("Otrzymałem wiadomość: " + o);

                var fileOut = new FileStream(Path.Combine(Environment.CurrentDirectory, "plik.dat"),
                    FileMode.OpenOrCreate, FileAccess.Write);
                bf.Serialize(fileOut, o);
                Console.WriteLine("Zapisano plik.");

                client.Close();
                server.Stop();
            }
            catch (Exception e)
            {
                Console.WriteLine("coś nie tak: {0}", e);
            }
        }

        private static void Klient()
        {
            var o = new Obiekt("Hejka!");
            var client = new TcpClient("127.0.0.1", 7171);
            var stream = client.GetStream();
            var bf = new BinaryFormatter();
            bf.Serialize(stream, o);
            stream.Close();
            client.Close();
        }

        public static void Main(string[] args)
        {
            var serwer = new Thread(Serwer) {IsBackground = true};
            var klient = new Thread(Klient) {IsBackground = true};
            serwer.Start();
            klient.Start();
            klient.Join();
            serwer.Join();
        }
    }
}