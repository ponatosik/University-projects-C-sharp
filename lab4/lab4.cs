namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = ReadNumbers();

            if (numbers.Length == 0)
            {
                Console.WriteLine("Ви не ввели жодного числа");
                return;
            }

            int firstNum = numbers[0];
            int lastNum = numbers[numbers.Length - 1];

            int searchIndex = 0;

            for (int i = 1; i < numbers.Length; i++)
                if (firstNum < numbers[i] && numbers[i] < lastNum)
                    searchIndex = i;

            Console.WriteLine($"Результат пошуку елемента що задовільняє нервіності {firstNum} < A[i] < {lastNum}: i = {searchIndex}");
        }
        /// <summary>
        /// Метод просить користувача ввести масив цілих чисел
        /// </summary>
        /// <returns>Масив цілих чисел, введених користувачем</returns>
        static int[] ReadNumbers()
        {
            List<int> numbers = new List<int>();

            Console.WriteLine("Ведіть масив цілих чисел (ведіть * щоби завершити введення)");
            while (true)
            {
                string numberStr = Console.ReadLine();
                int number;

                if (numberStr == "*")
                    break;

                if (int.TryParse(numberStr, out number))
                    numbers.Add(number);
                else
                    Console.WriteLine("Невірний формат числа");

            }

            Console.Write("Ви ввели числа:");
            foreach (int number in numbers)
                Console.Write(" " + number);
            Console.Write('\n');

            return numbers.ToArray();
        }
    }
}