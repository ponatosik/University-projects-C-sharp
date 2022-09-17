using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            double U = 0, I = 0, R;
            bool isDataValid = false;
            string UStr, IStr;

            while(!isDataValid)
            {
                Console.Write("Введіть силу струму I:");
                UStr = Console.ReadLine();

                Console.Write("Введіть напругу U:");
                IStr = Console.ReadLine();

                isDataValid =   double.TryParse(UStr, out U) && 
                                double.TryParse(IStr, out I);
                
                if(!isDataValid)
                    Console.WriteLine("Невірний формат даних, спробйте ще раз");
            }

            R = I / U;
            Console.WriteLine($"Опір = {R}");
        }
    }
}