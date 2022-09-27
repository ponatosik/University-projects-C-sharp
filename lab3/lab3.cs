using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = 0, y = 0;
            string xStr, yStr;
            bool isDataValid = false;

            while(!isDataValid)
            {
                Console.Write("Введіть x: ");
                xStr = Console.ReadLine();

                Console.Write("Введіть y: ");
                yStr = Console.ReadLine();

                isDataValid =   double.TryParse(xStr, out x) && 
                                double.TryParse(yStr, out y);
                
                if(!isDataValid)
                    Console.WriteLine("Невірний формат даних, спробйте ще раз");
            }

            Console.WriteLine($"Чи лежить точка ({x}; {y}) в першому або другому квадранті?");
            Console.WriteLine(x * y > 0);
        }
    }
}