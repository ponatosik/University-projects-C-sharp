using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix;
            int n = 0, m = 0;
            string nStr, mStr;
            bool isDataValid = false;

            while (!isDataValid)
            {
                Console.Write("Введіть висоту матриці m: ");
                mStr = Console.ReadLine();

                Console.Write("Введіть ширину матриці n: ");
                nStr = Console.ReadLine();

                isDataValid =   int.TryParse(mStr, out m) &&
                                int.TryParse(nStr, out n) &&
                                m > 0 && n > 0;

                if (!isDataValid)
                    Console.WriteLine("Невірний формат даних, спробйте ще раз");
            }

            GenerateRandomMatrix(out matrix, m, n, maxValue: 100);
            PrintMatrix(matrix);

            Console.WriteLine("Мінімальні та максимальні значення в рядках матриці:");
            for (int i = 0; i < m; i++)
            {
                int rowMin = matrix[i, 0];
                int rowMax = matrix[i, 0];

                for (int j = 0; j < n; j++)
                {
                    rowMin = matrix[i, j] < rowMin ? matrix[i, j] : rowMin;
                    rowMax = matrix[i, j] > rowMax ? matrix[i, j] : rowMax;
                }

                Console.WriteLine($"Мінімальне значення в рядку {i + 1} = {rowMin}");
                Console.WriteLine($"Максиамальне значення в рядку {i + 1} = {rowMax}");
            }

            Console.WriteLine("Мінімальні та максимальні значення в стовпцях матриці:");
            for (int j = 0; j < n; j++)
            {
                int colMax = matrix[0, j];
                int colMin = matrix[0, j];

                for (int i = 0; i < m; i++)
                {
                    colMin = matrix[i, j] < colMin ? matrix[i, j] : colMin;
                    colMax = matrix[i, j] > colMax ? matrix[i, j] : colMax;
                }

                Console.WriteLine($"Мінімальне значення в стовпчику {j + 1} = {colMin}");
                Console.WriteLine($"Максиамальне значення в стовпчику {j + 1} = {colMax}");
            }
        }

        /// <summary>
        /// Cтворює матрицію цілих чисел розмірами m * n і заповнює її випадковими числами
        /// </summary>
        /// <param name="matrix">Вихідна матриця</param>
        /// <param name="m">Висота матриці</param>
        /// <param name="n">Ширина матриці</param>
        /// <param name="minValue">Мінімальне значення випадкового числа</param>
        /// <param name="maxValue">Максимальне значення випадкового числа</param>
        static void GenerateRandomMatrix(out int[,] matrix, int m, int n, int minValue = 0, int maxValue = 10)
        {
            Random rand = new Random();
            matrix = new int[m, n];

            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    matrix[i, j] = rand.Next(minValue, maxValue);
        }

        /// <summary>
        /// Виводить матрицю цілих чисел у форматованому вигляді у стандартний потік
        /// </summary>
        static void PrintMatrix(int[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write($"{matrix[i, j]} \t");
                Console.Write('\n');
            }
        }
    }
}