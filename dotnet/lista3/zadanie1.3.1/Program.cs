using System;
using System.Linq;

namespace zadanie1._3._1
{
    public static class StringPalindrome
    {
        public static bool IsPalindrome(this string s)
        {
            s = s.ToLowerInvariant();
            var chars = s.ToCharArray();
            char[] filter = {' ', '.', ',', ';', ':', '!', '?', '-', '\"', '\'', '(', ')'};
            var filtered = chars.Where(c => !filter.Contains(c));
            return filtered.SequenceEqual(filtered.Reverse());
        }    
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            const string str = "Kobyła!!!   ma MałYbOk.";
            Console.WriteLine(str.IsPalindrome());
        }
    }
}