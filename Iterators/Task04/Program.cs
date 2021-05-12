using System;
using System.Collections;

/* На вход подается число N.
 * Нужно создать коллекцию из N квадратов последовательного ряда натуральных чисел 
 * и вывести ее на экран дважды. Элементы коллекции разделять пробелом. 
 * Выводы всей коллекции разделять переходом на новую строку.
 * Не хранить всю коллекцию в памяти.
 * 
 * Код, данный в условии, НЕЛЬЗЯ стирать, его можно только дополнять.
 * Не использовать yield и foreach. Не вызывать метод Reset() в классе Program.
 * 
 * Пример входных данных:
 * 3
 * 
 * Пример выходных данных:
 * 1 4 9
 * 1 4 9
 * 
 * В случае ввода некорректных данных выбрасывайте ArgumentException.
*/
namespace Task04
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
                MyInts myInts = new MyInts();
                IEnumerator enumerator = myInts.MyEnumerator(value);

                IterateThroughEnumeratorWithoutUsingForeach(enumerator);
                Console.WriteLine();
                IterateThroughEnumeratorWithoutUsingForeach(enumerator);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("error");
            }

        }

        static void IterateThroughEnumeratorWithoutUsingForeach(IEnumerator enumerator)
        {
            string output = "";
            MyInts Ints = (MyInts)enumerator;
            while (Ints.MoveNext() == true)
            {
                output += Ints.number * Ints.number + " ";
            }
            Console.WriteLine(output.Remove(output.Length - 1));
        }
    }

    class MyInts : IEnumerator // НЕ МЕНЯТЬ ЭТУ СТРОКУ
    {
        public int number = 0;

        private int value;

        public MyInts(int value)
        {
            this.value = value;
        }

        public MyInts()
        {
        }

        public bool MoveNext()
        {
            if (number + 1 <= value)
            {
                number++;
                return true;
            }
            number = 0;
            return false;
        }

        internal IEnumerator MyEnumerator(int value)
        {
            return new MyInts(value);
        }

        public void Reset()
        {
            number = 0;

        }

        public object Current
        {
            get
            {
                return number;
            }
        }

        object IEnumerator.Current => Current;
    }
}