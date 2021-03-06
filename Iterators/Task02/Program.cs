using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
В основной программе объявите и инициализируйте одномерный строковый массив 
и выполните циклический перебор его элементов с разных «начальных точек», 
разделяя элементы одним пробелом.

Тестирование приложения выполняется путем запуска разных наборов тестов.
На вход в первой строке поступает число - номер элемента, начиная с которого 
пойдет циклический перебор.
В следующей строке указаны элементы последовательности, разделенные одним или 
несколькими пробелами.
3
1 2 3 4 5
Программа должна вывести на экран:
3 4 5 1 2

В случае ввода некорректных данных выбрасывайте ArgumentException.

Никаких дополнительных символов выводиться не должно.

Код метода Main можно подвергнуть изменениям, но вывод меняться не должен.

 */
namespace Task02
{
    class IteratorSample : IEnumerable<string> // НЕ МЕНЯТЬ
    {
        string[] values;
        int start;

        public IteratorSample(string[] values, int start)
        {
            this.values = values;
            this.start = start;
        }

        public IEnumerator GetEnumerator()
        {
            for (int index = 0; index < values.Length; index++)
                yield return values[(index + start - 1) % values.Length];
        }

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            return (IEnumerator<string>)GetEnumerator();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int startingIndex) || startingIndex - 1 < 0)
                    throw new ArgumentException();
                input = Console.ReadLine();
                for (int i = 0; i < input.Length - 1; i++)
                {
                    if (input[i] == ' ' && input[i + 1] == ' ')
                    {
                        input = input.Remove(i, 1);
                        i--;
                    }
                }
                string[] values = input.Split();

                if (startingIndex > values.Length)
                    throw new ArgumentException();
                foreach (string ob in new IteratorSample(values, startingIndex))
                    Console.Write(ob + " ");
                Console.WriteLine();
            }
            catch (ArgumentException)
            {
                Console.WriteLine("error");
            }
            catch (Exception)
            {
                Console.WriteLine("problem");
            }
            Console.ReadLine();
        }
    }
}
