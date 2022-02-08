using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace zad1klient
{
    class Person
    {
        public string name { get; set; }
        public string surname { get; set; }
    }
    internal class Program
    {
        static readonly HttpClient client = new HttpClient();

        static async Task Get(int id)
        {
            var uri = "http://localhost:60504/api/persons/" + id;
            var responseString = await client.GetStringAsync(uri);
            Console.WriteLine(responseString);
        }

        static async Task Post(string name, string surname)
        {
            var uri = string.Format("http://localhost:60504/api/persons");
            var person = new Person() { name = name, surname = surname };
            var body = JsonConvert.SerializeObject(person);
            var content = new StringContent(body, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(uri, content);
            var responseString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseString);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("get <id>");
            Console.WriteLine("post <imie> <nazwisko>");
            while (true)
            {
                var input = Console.ReadLine().Split(' ').ToList();
                if (input[0] == "get")
                {
                    if (int.TryParse(input[1], out int id))
                    {
                        Get(id);
                    }
                    else
                    {
                        Console.WriteLine("podaj poprawne id");
                    }
                }
                else if (input[0] == "post")
                {
                    if (input.Count >= 3)
                    {
                        Post(input[1], input[2]);
                    }
                    else
                    {
                        Console.WriteLine("podaj poprawne dane");
                    }
                }
                else
                {
                    Console.WriteLine("zły format");
                }
            }

        }
    }
}
