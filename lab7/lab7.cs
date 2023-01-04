using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> myCharList = new List<char>();
            myCharList = ReadCharList();
            
            char seekedValue;
            Console.Write("Ведіть перевірочне значення: ");
            seekedValue = Console.ReadKey().KeyChar;

            Console.Write($"\nІндекси елементів, що дорівноють \'{seekedValue}\' :"); 
            int i = 0;
            foreach(var value in myCharList)
            {
                if (value == seekedValue) 
                {
                    Console.Write($"{i} ");
                }
                i++;
            }

            char[] myCharArray = myCharList.ToArray();
            Console.ReadKey();
        }

        static List<char> ReadCharList()
        {
            List<char> charList = new List<char>();
            Console.WriteLine("Ведіть набір символів (ведіть * щоби завершити введення)");
            while (true)
            {
                char input = Console.ReadKey().KeyChar;
                Console.Write(' ');
                if (input == '*')
                {
                    Console.WriteLine();
                    return charList;
                }
                charList.Add(input);
            }
        }
    }
}