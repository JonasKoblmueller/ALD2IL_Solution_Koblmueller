using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArrayList
{
    public class ArrayList<T>
    {
        private T[] myarry;
        private int count;

        //Konstruktor
        public ArrayList(int size)
        {
            myarry = new T[size]; //Array mit der Größe size erstellen
            count = 0; //Anfangs ist die Liste leer 
        }

        public void Add(T item) //Element hinzufügen
        {
            myarry[count] = item;
            count++;

            //if (count == myarry.Length) //Array ist voll
            //{
            //    T[] temp = new T[myarry.Length * 2];
            //    for (int i = 0; i < myarry.Length; i++)
            //    {
            //        temp[i] = myarry[i];
            //    }
            //    myarry = temp;
            //}

            if (count == myarry.Length) 
            { 
                Array.Resize(ref myarry, myarry.Length*2);
            }

        }

       public void InsertAT(int index, T intem)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            for (int i = count; i > index; i--)
            {
                myarry[i] = myarry[i - 1];
            }
            myarry[index] = intem;
            count++;
        }

        public void RemoveAT(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            //Alle Elemente nach dem Index um eine Position nach vorne verschieben
            for (int i = index; i < count - 1; i++)
            {
                myarry[i] = myarry[i + 1];
            }
            count--;

            if (count < myarry.Length / 2)
            {
                Array.Resize(ref myarry, myarry.Length / 2);
            }
        }

        public bool Remove(T item)
        {
            int index = -1;
            for (int i = 0; i < count; i++)
            {
                if (myarry[i].Equals(item))
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                return false;
            }
            RemoveAT(index);
            return true;
        }

        //Zugriff mit Index auf ein Element
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                return myarry[index];
            }
            set
            {
                if (index < 0 || index >= count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                myarry[index] = value;
            }
        }

        public void Clear()
        {
            myarry = new T[myarry.Length];
            count = 0;
        }

        public int Count()
        {
            return count;
        }








    }
}
