using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SingelLinkedList; 
using ArrayList;
using Hashtable;
using System.Collections;


namespace Test_Hashtable
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable<Person,int> hashtable = new Hashtable<Person, int>(10);

            hashtable.put(new Person("Max", "Mustermann", 25), 1);
            hashtable.put(new Person("Erika", "Musterfrau", 30), 2);
            hashtable.put(new Person("John", "Doe", 35), 3);
            hashtable.put(new Person("Jane", "Doe", 28), 4);
            hashtable.put(new Person("Max", "Mustermann", 25), 5); // Update existing key
            hashtable.put(new Person("Alice", "Wonderland", 22), 6);
            hashtable.put(new Person("Bob", "Builder", 40), 7);
            hashtable.put(new Person("Charlie", "Brown", 20), 8);
            hashtable.put(new Person("David", "Smith", 45), 9);
            hashtable.put(new Person("Eve", "Adams", 50), 10);

            hashtable.get(new Person("Max", "Mustermann", 25), out int value);
            Console.WriteLine($"Value for Max Mustermann: {value}");

            if (hashtable.Remove(new Person("Erika", "Musterfrau", 30)))
            {
                Console.WriteLine("Erika Musterfrau removed from hashtable.");
            }

            hashtable.get(new Person("Erika", "Musterfrau", 30), out int value1);
            Console.WriteLine($"Value for Max Mustermann: {value1}");










        }


        class Person
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

            public override bool Equals(object obj)
            {
                if (obj is Person other)
                {
                    return FirstName == other.FirstName && LastName == other.LastName && Age == other.Age;
                }
                return false;
            }

            public override int GetHashCode()
            {
                return Math.Abs(17 * FirstName.GetHashCode() + 23 * LastName.GetHashCode() + 31 * Age.GetHashCode());
                
            }
        }


}
}
