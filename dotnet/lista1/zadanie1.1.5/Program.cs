// zadanie 1.1.5

using System;

namespace zad2
{
    /// <summary>
    /// Klasa reprezentująca siatkę.
    /// </summary>
    public class Grid
    {
        /// <summary>
        /// Tablica dwuwymiarowa reprezentująca siatkę.
        /// </summary>
        private int[,] _grid;
        /// <summary>
        /// Zmienna zapamiętująca liczbę kolumn siatki.
        /// </summary>
        private int columns;

        /// <summary>
        /// Indekser do pobierania jednego wiersza tablicy reprezentującej siatkę.
        /// </summary>
        /// <param name="i">i-ty wiersz</param>
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
        
        /// <summary>
        /// Indekser do pobierania kontretnego elementu tablict reprezentującej siatkę.
        /// </summary>
        /// <param name="i">i-ty wiersz</param>
        /// <param name="j">j-ta kolumna</param>
        public int this[int i, int j]
        {
            get => _grid[i, j];
            set => _grid[i, j] = value;
        }

        /// <summary>
        /// Konstruktor klasy.
        /// </summary>
        /// <param name="rows">Liczba wierszy.</param>
        /// <param name="columns">Liczba kolumn.</param>
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