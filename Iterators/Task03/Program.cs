using System;
using System.Collections;
using System.Text;

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

                string input;
                string[] info;

                for (int i = 0; i < N; i++)
                {
                    Console.InputEncoding = Encoding.UTF8;
                    Console.OutputEncoding = Encoding.UTF8;
                    input = Console.ReadLine();
                    info = input.Split();
                    if (info.Length < 2)
                        throw new ArgumentException();
                    people[i] = new Person(info[1], info[0]);
                }
                People peopleList = new People(people);

                foreach (Person p in peopleList)
                    Console.WriteLine(p);

                foreach (Person p in peopleList.GetPeople)
                    Console.WriteLine(p);
            }
            catch (ArgumentException)
            {
                Console.Write("error");
            }
        }
    }

    public class Person : IComparable
    {
        public string firstName;
        public string lastName;

        public Person(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public int CompareTo(object obj)
        {
            Person per = (Person)obj;
            int res = lastName.ToLower().CompareTo(per.lastName.ToLower());
            if (res == 0)
            {
                return firstName.ToLower().CompareTo(per.firstName.ToLower());
            }
            return res;
        }

        public override string ToString()
        {
            return lastName + " " + firstName.Substring(0, 1) + ".";
        }


    }


    public class People : IEnumerable
    {
        private Person[] _people;

        public People(Person[] people)
        {
            _people = new Person[people.Length];
            for (int i = 0; i < people.Length; i++)
            {
                _people[i] = people[i];
            }
        }

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

        public PeopleEnum GetEnumerator()
        {
            return new PeopleEnum(_people);
        }
    }

    public class PeopleEnum : IEnumerator
    {
        public Person[] _people;

        int position = -1;

        public PeopleEnum(Person[] people)
        {
            _people = new Person[people.Length];
            for (int i = 0; i < people.Length; i++)
            {
                _people[i] = people[i];
            }
            Array.Sort(_people);
        }

        public bool MoveNext()
        {
            if (position < _people.Length - 1)
            {
                position++;
                return true;
            }
            else return false;
        }

        public void Reset()
        {
            position = -1;
        }


        public Person Current
        {
            get
            {
                return _people[position];
            }
        }

        object IEnumerator.Current => Current;
    }
}
