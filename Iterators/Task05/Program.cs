using System;
using System.Collections;

/* На вход подается число N.
 * Нужно создать коллекцию из N элементов последовательного ряда натуральных чисел, возведенных в 10 степень, 
 * и вывести ее на экран ТРИЖДЫ. Инвертировать порядок элементов при каждом последующем выводе.
 * Элементы коллекции разделять пробелом. 
 * Очередной вывод коллекции разделять переходом на новую строку.
 * Не хранить всю коллекцию в памяти.
 * 
 * Код, данный в условии, НЕЛЬЗЯ стирать, его можно только дополнять.
 * Не использовать yield и foreach. Не вызывать метод Reset() в классе Program.
 * 
 * Пример входных данных:
 * 2
 * 
 * Пример выходных данных:
 * 1 1024
 * 1024 1
 * 1 1024
 * 
 * В случае ввода некорректных данных выбрасывайте ArgumentException.
 * В других ситуациях выбрасывайте 
*/
namespace Task05
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string input = Console.ReadLine();
                if (!int.TryParse(input, out _))
                    throw new ArgumentException();
                int value = int.Parse(input);
                MyDigits myDigits = new MyDigits();
                IEnumerator enumerator = myDigits.MyEnumerator(value);

                IterateThroughEnumeratorWithoutUsingForeach(enumerator);
                Console.WriteLine();
                IterateThroughEnumeratorWithoutUsingForeach(enumerator);
                Console.WriteLine();
                IterateThroughEnumeratorWithoutUsingForeach(enumerator);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("error");
            }
            catch (ArithmeticException)
            {
                Console.WriteLine("ooops");
            }
        }

        static void IterateThroughEnumeratorWithoutUsingForeach(IEnumerator enumerator)
        {
            MyDigits myDigits = (MyDigits)enumerator;
            string output = "";
            while (myDigits.MoveNext() == true)
            {
                output += Math.Pow(myDigits.number, 10) + " ";
            }
            if (MyDigits.turn == true)
            {
                string[] snums = output.Trim().Split();
                output = "";
                long[] nums = new long[snums.Length];
                for (int i = 0; i < nums.Length; i++)
                {
                    nums[i] = long.Parse(snums[nums.Length - 1 - i]);
                    output += nums[i] + " ";
                }
            }
            Console.Write(output.Remove(output.Length - 1));

        }
    }

    class MyDigits : IEnumerator // НЕ МЕНЯТЬ ЭТУ СТРОКУ
    {
        public static bool turn = true;
        public long number = 0;

        private int value;

        public MyDigits()
        {
        }

        public MyDigits(object value)
        {
            this.value = (int)value;
        }

        public object Current
        {
            get
            {
                return number;
            }
        }

        public bool MoveNext()
        {
            if (number + 1 <= value)
            {
                number++;
                return true;
            }
            number = 0;
            if (turn == false)
                turn = true;
            else
                turn = false;
            return false;
        }

        public void Reset()
        {
            number = 0;
        }

        internal IEnumerator MyEnumerator(object value)
        {
            return new MyDigits(value);
        }
    }
}


