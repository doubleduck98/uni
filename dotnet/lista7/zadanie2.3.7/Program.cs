using System;
using System.IO;
using System.Messaging;
using System.Threading;

namespace zadanie2._3._7
{
    internal class Program
    {
        private static void Reciever()
        {
            var q = new MessageQueue(@".\Private$\Queue") {Formatter = new BinaryMessageFormatter()};

            while (true)
            {
                try
                {
                    var msg = q.Receive();
                    if (msg != null)
                    {
                        var time = (int) msg.Body;
                        Console.WriteLine("Zasypiam na {0}ms", time.ToString());
                        Thread.Sleep(time);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("bład recievera: " + e.Message);
                    Environment.Exit(-1);
                }
            }
        }

        private static void Sender()
        {
            var q = new MessageQueue(@".\Private$\Queue") {Formatter = new BinaryMessageFormatter()};
            var rand = new Random();
            while (true)
            {
                try
                {
                    q.Send(rand.Next(350, 451));
                    Thread.Sleep(400);
                }
                catch (Exception e)
                {
                    Console.WriteLine("błąd sendera: " + e.Message);
                    Environment.Exit(-1);
                }
            }
        }

        public static void Main(string[] args)
        {
            if (!MessageQueue.Exists(@".\Private$\Queue"))
            {
                MessageQueue.Create(@".\Private$\Queue");
            }

            var snd = new Thread(Sender) {IsBackground = true};
            var rcv = new Thread(Reciever) {IsBackground = true};
            snd.Start();
            rcv.Start();
            snd.Join();
            rcv.Join();
        }
    }
}