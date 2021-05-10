using System;
using System.Collections.Concurrent;
using System.Threading;

namespace zad1
{
    public class Invoker
    {
        private ConcurrentQueue<ICommand> _commandQueue = new ConcurrentQueue<ICommand>();

        private void AddCommand()
        {
            var rnd = new Random();
            while (true)
            {
                var pick = rnd.Next(1, 5);
                switch (pick)
                {
                    case 1:
                        _commandQueue.Enqueue(new FtpDownload("ftp address"));
                        break;
                    case 2:
                        _commandQueue.Enqueue(new HttpDownload("http address"));
                        break;
                    case 3:
                        _commandQueue.Enqueue(new CreateRadnomFile("file name"));
                        break;
                    case 4:
                        _commandQueue.Enqueue(new CopyFile("file1", "fil2"));
                        break;
                }

                Thread.Sleep(250);
            }
        }

        private void ExecuteCommand()
        {
            var rnd = new Random();
            while (true)
            {
                if (_commandQueue.TryDequeue(out var command))
                {
                    command.Execute();
                }

                Thread.Sleep(rnd.Next(300, 700));
            }
        }

        public void Run()
        {
            var adder = new Thread(AddCommand);
            var executus1 = new Thread(ExecuteCommand);
            var executus2 = new Thread(ExecuteCommand);

            adder.Start();
            executus1.Start();
            executus2.Start();

            adder.Join();
            Thread.Sleep(1000);
            executus1.Join();
            executus2.Join();
        }
    }
}