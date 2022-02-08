using Dapper;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;

namespace zad5.DataLayer
{
    [Table("lista7.PERSON")]
    public class Person
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
    }
    public interface IDapperRepo<T>
    {
        IEnumerable<T> GetTwentyOne();
        T Get(int id);
    }

    public class DapperRepo<T> : IDapperRepo<T>, IDisposable
    {
        private readonly IConfiguration _configuration;
        private readonly SqlConnection _connection;

        public DapperRepo(IConfiguration configuration)
        {
            _configuration = configuration;
            var cs = _configuration["ConnectionStrings:db"];
            _connection = new SqlConnection(cs);
        }

        public void Dispose()
        {
            _connection.Dispose();
        }

        public T Get(int id)
        {
            return _connection.Query<T>("select id,name,surname from lista7.PERSON where id = @id;", new { id = id }).Single();
        }

        public IEnumerable<T> GetTwentyOne()
        {
            return _connection.Query<T>("select top 21 * from lista7.PERSON;").ToList();
        }
    }
}
