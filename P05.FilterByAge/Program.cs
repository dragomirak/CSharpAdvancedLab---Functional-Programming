namespace P05.FilterByAge
{
    public class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Person person = new Person(data[0], int.Parse(data[1]));
                people.Add(person);
            }

            string filter = Console.ReadLine();
            int filterAge = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Person, bool> predicate = GetAgeCondition(filter, filterAge);
            Func<Person, string> formatter = GetFormatter(format);

            PrintPeople(people, predicate, formatter);

            static void PrintPeople(List<Person> people, Func<Person, bool> predicate, Func<Person, string> formatter)
            {
                foreach (Person person in people)
                {
                    if (predicate(person))
                    {
                        Console.WriteLine(formatter(person));
                    }
                }
            }

            static Func<Person, bool> GetAgeCondition(string filter, int filterAge)
            {
                if (filter == "younger")
                {
                    return p => p.Age < filterAge;
                }
                else if (filter == "older")
                {
                    return p => p.Age >= filterAge;
                }
                return null;
            }

            static Func<Person, string> GetFormatter(string format)
            {
                if (format == "name")
                {
                    return p => $"{p.Name}";
                }
                else if (format == "age")
                {
                    return p => $"{p.Age}";
                }
                else if (format == "name age")
                {
                    return p => $"{p.Name} - {p.Age}";
                }
                return null;
            }
        }
    }
}