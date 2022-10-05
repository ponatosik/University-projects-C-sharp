using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\nПерше завдання:");
            PrintReversed(123456);

            Console.Write("\nДруге завдання:");
            PrintReversed("АБВ");

            Console.Write("\nТретє завдання:");
            PrintReversed((decimal)123.456);

            Console.Write("\nЧетверте завдання:");
            PrintReversed("АБВ,ГДЕ",',');

            Console.WriteLine("\nП'яте завдання");
            int[] arr = {1,2,3,4,5,6,7};
            foreach(int num in arr)
                Console.Write($"{num} ");
            Console.WriteLine();
            Reverse(ref arr);
            foreach(int num in arr)
                Console.Write($"{num} ");

            Console.ReadKey();
        }
        
        static void PrintReversed(int number)
        {
            if(number >= 10)
            {
                Console.Write(number % 10);
                PrintReversed(number / 10);
            }
            else
            {
                Console.Write(number);
            }
        }

        static void PrintReversed(string str)
        {
            if(str.Length == 0) return;
            
            PrintReversed(str.Substring(1));
            Console.Write(str[0]);
        }

        static void PrintReversed(decimal number)
        {
            if(number == 0) return;

            int numberAbs = (int)number;
            if(number - numberAbs > 0 && numberAbs != 0)
            {
                PrintReversed((decimal)numberAbs);
                Console.Write('.');
                number = number - numberAbs;
            } 
            if(number >= 10)
            {
                Console.Write(numberAbs % 10);
                PrintReversed(numberAbs / 10);
            }
            else if(number >= 1)
            {
                Console.Write(number);
            }
            else
            {
                PrintReversed(number * 10 - (int)(number * 10));
                Console.Write((int)(number * 10));
            }
        }

        static void PrintReversed(string str, char stopSign)
        {
            if(str.Length == 0) return;

            static int recursiveSearch(string str, char stopSign)
            {
                if(str.Length == 0) return -1;
                if(str[0] == stopSign) return 0;
                int searchRes = recursiveSearch(str.Substring(1), stopSign);
                if(searchRes != -1) return searchRes + 1;
                return -1;
            }

            int stopSignIndex = recursiveSearch(str, stopSign);
            for (int i = 0; i < str.Length; i++)
                if(str[i] == stopSign)
                {
                    stopSignIndex = i;
                    break;
                }
            
            if(stopSignIndex == -1)
            {
                PrintReversed(str.Substring(1));
                Console.Write(str[0]);
            }
            else
            {
                PrintReversed(str.Substring(0,stopSignIndex), stopSign);
                Console.Write(stopSign);
                PrintReversed(str.Substring(stopSignIndex + 1), stopSign);
            }
        }

        static void Reverse(ref int[]arr)
        {
            for(int i = 0; i < arr.Length / 2; i++)
                Swap(ref arr[i], ref arr[arr.Length - 1 - i]);
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}