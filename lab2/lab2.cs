using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            int nn = 0, nk = 0;
            string nnStr, nkStr;
            bool isDataValid = false;

            while(!isDataValid)
            {
                Console.Write("Введіть нижню межу обчислення:");
                nnStr = Console.ReadLine();

                Console.Write("Введіть верхню межу обчислення:");
                nkStr = Console.ReadLine();

                isDataValid =   int.TryParse(nnStr, out nn) && 
                                int.TryParse(nkStr, out nk) && 
                                nk >= nn;
                
                if(!isDataValid)
                    Console.WriteLine("Невірний формат даних, спробйте ще раз");
            }

            Func<int, double> a_k = k => (double)
                (Math.Pow(k, 2) + Math.Pow(-1, k) * Math.Pow(k, 3)) / (Math.Pow(k, 2) + k + 1);

            double sum = Enumerable .Range(nn, nk - nn + 1)
                                    .Select(k => a_k(k))
                                    .Sum();
                                    
            Console.WriteLine($"Сума членів ряду з {nn} до {nk} = {sum}");
        }
    }
}