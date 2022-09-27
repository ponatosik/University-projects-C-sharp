using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = ReadNumbers();

            if(numbers.Length == 0)
            {
                Console.WriteLine("Ви не ввели жодного числа");
                return;
            }            

            int firstNum = numbers[0];
            int lastNum = numbers[numbers.Length -1];
            int searchIndex = 0;

            for(int i = 1; i < numbers.Length; i++)
                if(firstNum < numbers[i] && numbers[i] < lastNum)
                    searchIndex = i;
            
            Console.WriteLine($"Результат пошуку елемента що задовільняє нервіності {firstNum} < A[i] < {lastNum}: i = {searchIndex}");
        }

        static int[] ReadNumbers()
        {
            Console.WriteLine("Ведіть масив цілих чисел");
            string arrayStr = Console.ReadLine();
            
            int[] numbers = new Regex(@"-?\d+")
                    .Matches(arrayStr)
                    .Select(s => int.Parse(s.ToString()))
                    .ToArray();

            Console.Write("Ви ввели числа:");
            foreach(int number in numbers)
                Console.Write(" " + number);
            Console.Write('\n');

            return numbers;
        }
    }
}