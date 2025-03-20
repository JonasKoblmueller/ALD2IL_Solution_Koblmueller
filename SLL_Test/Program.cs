using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLL_Test
{
    class Program
    {
        private class Student
        {
            private int MatNr;
            private String Name;

            public override bool Equals(object obj)
            {
                Student other = (Student)obj;
                return other.MatNr.Equals(obj);
            }
        }
        static void Main(string[] args)
        {
            //Von der Vorlesung
            SingelLinkedList.SinglyLinkedList<int> sll_VO = new SingelLinkedList.SinglyLinkedList<int>();

            sll_VO.Add(10);
            sll_VO.Add(11);
            sll_VO.Add(12);

            //Erstellt in der Übung
            //Aufgabe A
            SingelLinkedList.SinglyLinkedList<string> sll = new SingelLinkedList.SinglyLinkedList<string>();

            sll.Add("Jonas");
            sll.Add("Manuel");
            sll.Add("Markus");
            sll.Add("Peter");
            sll.Add("Christian");
            sll.Add("Christoph");

            Console.WriteLine("Gibt was geprüft werden soll ob vorhande: ");
            string name = Console.ReadLine();
            Console.WriteLine("Prüfen ob " + name + " vorhanden: " + sll.Contains(name));

            Console.WriteLine("Wert an Index 2: " + sll.FindByIndex(2));
            Console.WriteLine("Wert an Index 4: " + sll.FindByIndex(4));

            Console.WriteLine("Entferne 'Peter': " + sll.Remove("Peter"));
            Console.WriteLine("Ist Peter noch in der Liste?  " + sll.Contains("Peter"));

            Console.WriteLine("Entferne 'Christoph': " + sll.Remove("Jonas"));

            Console.WriteLine("Anszal der noch vorhanden Element: " + sll.Count());

            sll.Clear();
            Console.WriteLine("Die ganze Liste wird es gelöche und dann sind noch soviel Elemente vorhanden: " + sll.Count());

            //Aufgabe B





        }
    }
}
