using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SingelLinkedList;
using ArrayList;
using System.IO;
using System.Diagnostics;



namespace Vergleich_SLL_und_ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\jonas\\OneDrive - FH OOe\\FH_Master\\2_Semester\\Algorithmen_und_Datenstrukturen\\ALD2IL_Solution\\Rechtschreibpruefung\\german.dic"; 
            string[] words = File.ReadAllLines(filePath);

            SinglyLinkedList<string> sll = new SinglyLinkedList<string>();
            ArrayList<string> arrayList = new ArrayList<string>(words.Length);

            Stopwatch stopwatch = new Stopwatch();

            // Befüllen der SinglyLinkedList
            stopwatch.Start();
            foreach (var word in words)
            {
                sll.Add(word);
            }
            stopwatch.Stop();
            Console.WriteLine($"SinglyLinkedList - Zeit zum befüllen (Add): {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Reset();

            //Befüllen der ArrayList
            stopwatch.Start();
            foreach (var word in words)
            {
                arrayList.Add(word);
            }
            stopwatch.Stop();
            Console.WriteLine($"ArrayList - Zeit zum befüllen (Add): {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Reset();

            //Suchen der Elemente
            stopwatch.Start();
            foreach (var word in words)
            {
                sll.Contains(word);
            }
            stopwatch.Stop();
            Console.WriteLine($"SinglyLinkedList - Zeit zum suchen (Contains): {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Reset();

            //Aufrufen jedes Elements per Index
            stopwatch.Start();
            for (int i = 0; i < arrayList.Count(); i++)
            {
                var element = arrayList[i];
            }
            stopwatch.Stop();
            Console.WriteLine($"ArrayList - Zeit zum suchen (wird hier mit Index gemacht): {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Stop();
            Console.WriteLine($"ArrayList - Zeit zum suchen (wird hier mit Index gemacht): {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Reset();

            // Entfenen von jeden Element
            stopwatch.Start();
            foreach (var word in words)
            {
                sll.Remove(word);
            }
            stopwatch.Stop();
            Console.WriteLine($"SinglyLinkedList - Zeit zum Entferen jedes einzelen Elemenst: {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Reset();

            stopwatch.Start();
            foreach (var word in words)
            {
                arrayList.Remove(word);
            }
            stopwatch.Stop();
            Console.WriteLine($"ArrayList - Zeit zum Entferen jedes einzelen Elemenst: {stopwatch.ElapsedMilliseconds} ms");



        }
    }
}
