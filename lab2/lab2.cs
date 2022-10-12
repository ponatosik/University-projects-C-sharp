namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            int nn = 0, nk = 0;
            string nnStr, nkStr;
            bool isDataValid = false;

            while (!isDataValid)
            {
                Console.Write("Введіть нижню межу обчислення:");
                nnStr = Console.ReadLine();

                Console.Write("Введіть верхню межу обчислення:");
                nkStr = Console.ReadLine();

                isDataValid = int.TryParse(nnStr, out nn) &&
                                int.TryParse(nkStr, out nk) &&
                                nk >= nn;

                if (!isDataValid)
                    Console.WriteLine("Невірний формат даних, спробйте ще раз");
            }

            Console.WriteLine($"Сума членів ряду з {nn} до {nk} = {SumOfSeries(nn, nk)}");
        }

        /// <summary>
        /// Обчислення суми ряду: (k^2-(-1)^(k+1)k^3)/(k^2+k+1) від nn до nk
        /// </summary>
        /// <param name="nn">Нижня межа обчислення суми ряду</param>
        /// <param name="nk">Верхня  межа обчислення суми ряду</param>
        /// <returns>Сума ряду від nn до nk, якщо nn &lt;= nk; 0, якщо nn &gt; nk </returns>
        public static double SumOfSeries(int nn, int nk)
        {
            double sum = 0;
            for (int i = nn; i <= nk; i++)
                sum += (Math.Pow(i, 2) + Math.Pow(-1, i) * Math.Pow(i, 3)) / (Math.Pow(i, 2) + i + 1);
            return sum;
        }
    }
}