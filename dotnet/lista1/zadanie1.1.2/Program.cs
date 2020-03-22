// zadanie 1.1.2

using System;

namespace zad2
{
    public class Grid
    {
        private int[,] _grid;
        private int columns;

        public int[] this[int i]
        {
            get
            {
                var res = new int[columns];
                for (var j = 0; j < columns; ++j)
                {
                    res[j] = _grid[i, j];
                }

                return res;
            }
        }

        public int this[int i, int j]
        {
            get => _grid[i, j];
            set => _grid[i, j] = value;
        }


        public Grid(int rows, int columns)
        {
            _grid = new int[rows, columns];
            this.columns = columns;
        }
    }
    
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var g = new Grid(4, 4);
            g[1, 0] = 10;
            g[1, 1] = 11;
            g[1, 2] = 12;
            g[1, 3] = 13;
            Console.WriteLine($"grid[1, 3] -> {g[1, 3]}");
            var p = g[1];
            Console.WriteLine($"p[1] -> {p[1]}");
        }
    }
}