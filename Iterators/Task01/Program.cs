using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Необходимо построить ряд чисел Фибоначчи, ограниченный числом, введенным с клавиатуры.
 * 
 * Пример входных данных:
 * 6
 * Пример выходных данных:
 * 1 1 2 3 5
 * Пояснение:
 * следующее число 3 + 5 = 8 не выводится на экран, так как 8 > 6.
 * 
 * В случае ввода некорректных данных выбрасывайте ArgumentException.
 * 
*/
namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int value) || value < 1)
                    throw new ArgumentException();
                foreach (int el in Fibonacci(value))
                {
                    Console.Write(el + " ");
                }
            }
            catch (ArgumentException)
            {
                Console.Write("error");
            }
        }

        public static IEnumerable<int> Fibonacci(int maxValue)
        {
            int n = 1;
            int m = 1;
            int safe;
            yield return 1;
            yield return 1;
            bool ok = true;
            while (ok==true)
            {
                safe = m;
                m += n;
                if (m <= maxValue)
                {
                    yield return m;
                    n = safe;
                }
                else
                    ok = false;
            }
        }
    }
}
