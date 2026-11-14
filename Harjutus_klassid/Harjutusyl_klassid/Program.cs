using System;

namespace Harjutosyl_klassid
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public void Rename(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void CelebrateBirthday()
        {
            Age++;
            Console.WriteLine($"{FirstName} {LastName} sai aasta vanemaks! Uus vanus on {Age}.");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var person = new Person("Jaan", "Jalgaratas", 25);

            Console.WriteLine($"{person.FirstName} {person.LastName}, vanus: {person.Age}");

            person.Rename("Juhan", "Juurikas");

            Console.WriteLine($"{person.FirstName} {person.LastName}, vanus: {person.Age}");

            person.CelebrateBirthday();

            Console.WriteLine();
            Console.WriteLine("Vajuta programmi sulgemiseks ükskõik millist klahvi...");
            Console.ReadKey();
        }
    }
}