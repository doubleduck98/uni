using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace zad2
{
    public abstract class DataAccessHandler
    {
        protected abstract void Connect();
        protected abstract void GetData();
        protected abstract void ProcessData();
        protected abstract void Close();

        public void HandleData()
        {
            Connect();
            GetData();
            ProcessData();
            Close();
        }
    }

    public class DbAccessHandlerr : DataAccessHandler
    {
        private string cs = @"server=.\sqlexpress;database=example;integrated security=true";
        private SqlConnection _db;
        private int _data;

        protected override void Connect()
        {
            _db = new SqlConnection(cs);
            _db.Open();
        }

        protected override void GetData()
        {
            var command = _db.CreateCommand();
            command.CommandText = "SELECT COUNT(id) FROM Student";
            command.CommandTimeout = 10;
            command.CommandType = CommandType.Text;
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    _data = (int)reader[0];
                }
            }
        }

        protected override void ProcessData()
        {
            Console.WriteLine($"db: {_data}");
        }

        protected override void Close()
        {
            _db.Close();
        }
    }
    
    public class XmlAccessHandler : DataAccessHandler
    {
        private XmlTextReader _reader;
        private string _fileName = "xmlfile.xml";
        private string _data = "";
        protected override void Connect()
        {
            _reader = new XmlTextReader(_fileName);
        }

        protected override void GetData()
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

        protected override void ProcessData()
        {
            Console.WriteLine($"xml: {_data} {_data.Length}");
        }

        protected override void Close()
        {
            _reader.Close();
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            var db = new DbAccessHandlerr();
            db.HandleData();

            var xml = new XmlAccessHandler();
            xml.HandleData();
        }
    }
}