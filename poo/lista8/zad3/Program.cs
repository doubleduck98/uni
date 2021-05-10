using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace zad3
{
    public interface IDataAccessHandler
    {
        void Connect();
        void GetData();
        void ProcessData();
        void Close();
    }

    public class DataAccessHandler
    {
        private IDataAccessHandler _strategy;

        public DataAccessHandler(IDataAccessHandler strategy)
        {
            _strategy = strategy;
        }

        public void HandleData()
        {
            _strategy.Connect();
            _strategy.GetData();
            _strategy.ProcessData();
            _strategy.Close();
        }
    }

    public class DbAccessHandler : IDataAccessHandler
    {
        private string cs = @"server=.\sqlexpress;database=example;integrated security=true";
        private SqlConnection _db;
        private int _data;

        public void Connect()
        {
            _db = new SqlConnection(cs);
            _db.Open();
        }

        public void GetData()
        {
            var command = _db.CreateCommand();
            command.CommandText = "SELECT COUNT(id) FROM Student";
            command.CommandTimeout = 10;
            command.CommandType = CommandType.Text;
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    _data = (int) reader[0];
                }
            }
        }

        public void ProcessData()
        {
            Console.WriteLine($"db: {_data}");
        }

        public void Close()
        {
            _db.Close();
        }
    }

    public class XmlAccessHandler : IDataAccessHandler
    {
        private XmlTextReader _reader;
        private string _fileName = "xmlfile.xml";
        private string _data = "";

        public void Connect()
        {
            _reader = new XmlTextReader(_fileName);
        }

        public void GetData()
        {
            while (_reader.Read())
            {
                if (_reader.NodeType == XmlNodeType.Element)
                {
                    if (_data.Length < _reader.Name.Length)
                    {
                        _data = _reader.Name;
                    }
                }
            }
        }

        public void ProcessData()
        {
            Console.WriteLine($"xml: {_data} {_data.Length}");
        }

        public void Close()
        {
            _reader.Close();
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            var db = new DataAccessHandler(new DbAccessHandler());
            db.HandleData();

            var xml = new DataAccessHandler(new XmlAccessHandler());
            xml.HandleData();
        }
    }
}