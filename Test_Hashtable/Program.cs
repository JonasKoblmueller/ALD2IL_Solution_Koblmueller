using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SingelLinkedList; 
using ArrayList;
using Hashtable;
using System.Collections;
using System.Diagnostics;
using System.IO;



namespace Test_Hashtable
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable<Person,int> hashtable = new Hashtable<Person, int>(100);

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



            //Vergleich SingyLinkedList und ArrayList und Hashtable

            string filePath = "C:\\Users\\jonas\\OneDrive - FH OOe\\FH_Master\\2_Semester\\Algorithmen_und_Datenstrukturen\\ALD2IL_Solution\\Rechtschreibpruefung\\german.dic";
            string[] words = File.ReadAllLines(filePath);

            SinglyLinkedList<string> sll = new SinglyLinkedList<string>();
            ArrayList<string> arrayList = new ArrayList<string>(words.Length);
            Hashtable<string, bool> hashtable1 = new Hashtable<string, bool>(10);

            Stopwatch sw = new Stopwatch();

            //Befüllen
            sw.Restart();
            foreach (var word in words)
                sll.Add(word);
            sw.Stop();
            Console.WriteLine($"LinkedList Befüllen: {sw.ElapsedMilliseconds} ms");


            sw.Restart();
            foreach (var word in words)
                arrayList.Add(word);
            sw.Stop();
            Console.WriteLine($"ArrayList Befüllen: {sw.ElapsedMilliseconds} ms");


            sw.Start();
            foreach (var word in words)
                hashtable1.put(word, true);
            sw.Stop();
            Console.WriteLine($"Hashtable Befüllen: {sw.ElapsedMilliseconds} ms");



            // Zufällige Wörter für die Suche
            Random rnd = new Random();
            var testWords = words.OrderBy(x => rnd.Next()).Take(100).ToArray();


            sw.Restart();
            foreach (var word in testWords)
                hashtable1.ContainsKey(word);
            sw.Stop();
            Console.WriteLine($"Hashtable Suchen: {sw.ElapsedMilliseconds} ms");


            sw.Restart();
            foreach (var word in testWords)
                sll.Contains(word);
            sw.Stop();
            Console.WriteLine($"LinkedList Suchen: {sw.ElapsedMilliseconds} ms");

     
            sw.Restart();
            foreach (var word in testWords)
                arrayList.Remove(word); 
            sw.Stop();
            Console.WriteLine($"ArrayList Suchen: {sw.ElapsedMilliseconds} ms");

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
