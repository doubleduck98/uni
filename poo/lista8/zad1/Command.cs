using System;

namespace zad1
{
    public interface ICommand
    {
        void Execute();
    }

    public class Receiver
    {
        public void FtpDownload(string address)
        {
            Console.WriteLine($"ftp download {address}");
        }

        public void HttpDownload(string address)
        {
            Console.WriteLine($"http download {address}");
        }

        public void RandomFile(string fileName)
        {
            Console.WriteLine($"random file {fileName} created");
        }

        public void CopyFile(string from, string to)
        {
            Console.WriteLine($"file {from} copied to {to}");
        }
    }

    public class FtpDownload : ICommand
    {
        private Receiver _receiver;
        private string _address;

        public FtpDownload(string address)
        {
            _address = address;
            _receiver = new Receiver();
        }

        public void Execute()
        {
            _receiver.FtpDownload(_address);
        }
    }

    public class HttpDownload : ICommand
    {
        private Receiver _receiver;
        private string _address;

        public HttpDownload(string address)
        {
            _address = address;
            _receiver = new Receiver();
        }

        public void Execute()
        {
            _receiver.HttpDownload(_address);
        }
    }

    public class CreateRadnomFile : ICommand
    {
        private Receiver _receiver;
        private string _fileName;

        public CreateRadnomFile(string fileName)
        {
            _fileName = fileName;
            _receiver = new Receiver();
        }

        public void Execute()
        {
            _receiver.RandomFile(_fileName);
        }
    }

    public class CopyFile : ICommand
    {
        private Receiver _receiver;
        private string _from, _to;

        public CopyFile(string from, string to)
        {
            _from = from;
            _to = to;
            _receiver = new Receiver();
        }

        public void Execute()
        {
            _receiver.CopyFile(_from, _to);
        }
    }
}