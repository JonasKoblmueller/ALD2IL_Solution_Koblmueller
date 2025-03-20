using SingelLinkedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rechtschreibpruefung
{
    class Program
    {

        static void Main(string[] args)
        {
            SinglyLinkedList<string> woerterbuch = LadeWoerterbuch("C:\\Users\\jonas\\OneDrive - FH OOe\\FH_Master\\2_Semester\\Algorithmen_und_Datenstrukturen\\ALD2IL_Solution\\Rechtschreibpruefung\\german.dic");

            Console.WriteLine("Gib einen einfachen Deutschen Satz ein: ");
            string satz = Console.ReadLine();
            string[] woerter = satz.Split(new[] { ' ', ',', '.', '!', '?', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine("\nÜberprüfter Satz:");
            foreach (string wort in woerter)
            {
                if (woerterbuch.Contains(wort.ToLower())) // Groß-/Kleinschreibung ignorieren
                {
                    Console.Write(wort + " ");
                }
                else
                {
                    ConsoleHelper.WriteColored(wort + " ", ConsoleColor.Red);
                }
            }
        }


        private static SinglyLinkedList<string> LadeWoerterbuch(string dateipfad)
        {
            SinglyLinkedList<string> woerterbuch = new SinglyLinkedList<string>();

            try
            {
                using (StreamReader reader = new StreamReader(dateipfad))
                {
                    string zeile;
                    while ((zeile = reader.ReadLine()) != null)
                    {
                        woerterbuch.Add(zeile.Trim().ToLower()); // Wörter in Kleinbuchstaben speichern
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Feherl beim Laden des Wörterbuchs:  {ex.Message}", ConsoleColor.Red);
            }

            return woerterbuch;
        }

        public static class ConsoleHelper
        {
            public static void WriteLineColored(string text, ConsoleColor color)
            {
                Console.ForegroundColor = color;
                Console.WriteLine(text);
                Console.ResetColor();
            }

            public static void WriteColored(string text, ConsoleColor color)
            {
                Console.ForegroundColor = color;
                Console.Write(text);
                Console.ResetColor();
            }
        }

    }
}
