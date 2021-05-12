using System;
using System.Collections;
using System.Linq;

/* На вход подается число N.
 * На каждой из следующих N строках записаны ФИО человека, 
 * разделенные одним пробелом. Отчество может отсутствовать.
 * Используя собственноручно написанный итератор, выведите имена людей,
 * отсортированные в лексико-графическом порядке в формате 
 *      <Фамилия_с_большой_буквы> <Заглавная_первая_буква_имени>.
 * Затем выведите имена людей в исходном порядке.
 * 
 * Код, данный в условии, НЕЛЬЗЯ стирать, его можно только дополнять.
 * Не использовать yield.
 * 
 * Пример входных данных:
 * 3
 * Banana Bill Bananovich
 * Apple Alex Applovich
 * Carrot Clark Carrotovich
 * 
 * Пример выходных данных:
 * Apple A.
 * Banana B.
 * Carrot C.
 * 
 * Banana B.
 * Apple A.
 * Carrot C.
 * 
 * В случае ввода некорректных данных выбрасывайте ArgumentException.
*/
namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (!int.TryParse(Console.ReadLine(), out int n) || n < 0)
                    throw new ArgumentException();

                int N = n;
                Person[] people = new Person[N];

                for (int index = 0; index < people.Length; index++)
                {
                    string[] info = Console.ReadLine().Split(' ');

                    if (info.Length < 2)
                        throw new ArgumentException();

                    else people[index] = new Person(info[1], info[0]);
                }


                People peopleList = new People(people);

                foreach (Person p in peopleList)
                    Console.WriteLine(p);

                Console.WriteLine();

                foreach (Person p in peopleList.GetPeople)
                    Console.WriteLine(p);
            }
            catch (ArgumentException)
            {
                Console.Write("error");
            }
        }
    }

    public class Person
    {
        public string firstName;
        public string lastName;

        public Person(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public override string ToString()
        {
            return $"{lastName[0].ToString().ToUpper() + lastName.Substring(1)} {firstName[0].ToString().ToUpper()}.";
        }
    }


    public class People : IEnumerable
    {
        private Person[] _people;
        public Person[] GetPeople
        {
            get
            {
                return _people;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public People(Person[] people)
        {
            _people = people;
        }

        public PeopleEnum GetEnumerator()
        {
            return new PeopleEnum(_people);
        }
    }

    public class PeopleEnum : IEnumerator
    {
        public Person[] _people;
        private int numerator = -1;


        public bool MoveNext()
        {
            return ++numerator < _people.Length;
        }

        public void Reset()
        {
            numerator = -1;
        }


        public Person Current
        {
            get
            {
                return _people[numerator];
            }
        }

        object IEnumerator.Current => Current;

        public PeopleEnum(Person[] people)
        {
            _people = (from human in people orderby human.ToString() select human).ToArray();
        }
    }
}
