using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SingelLinkedList
{
    public class SinglyLinkedList<T> //Geneerict, Datentypen generisch verwenden
    {
        //Konstruktor
        public SinglyLinkedList(K key)
            {
                head = null;
                tail = null;
                count = 0;
            }
        private class Node<T>
        {
        public Node(T value)
            {
                Value = value;
                next = null;
            }
            public T Value { get; set; }
            public Node<T> next;
        }

        Node<T> head;
        Node<T> tail;
        int count;

        //Hinzufügen eines Elements
        public void Add(T value)
        {
            count++;
            if (head == null) //list is empty
            {
                Node<T> element = new Node<T>(value);
                head = element;
                head.Value = value;
                tail = head;
                return;
            }

            //Constant
            tail.next = new Node<T>(value);
            tail.next.Value = value;
            tail = tail.next;

            ////Linearer Aufwand
            //Node<T> current = head;
            //while(current.next != null)
            //{
            //    current = current.next;
            //}

            //current is the last element of the list
            //current.next = new Node<T>();
            //current.next.Value = value;

        }
        public int Count()
        {
            return count;
        }

        //Methode zum entfernen eines Elements
        public bool Remove(T value)
        {
            if (head == null) return false; //In case of empty list

            Node<T> prev = null;
            Node<T> current = head;

            while(current.next != null)
            {
                if(current.Value.Equals(value))
                {
                    if(current == head)
                    {
                        head = head.next;
                        if(head == null) //Liste ist leer!!
                        {
                            tail = null;
                        }
                    }
                    else
                    {
                        prev.next = current.next;
                        if (current.next == null)
                        {
                            tail = prev;
                        }
                    }
                    count--;
                    return true;
                }      
                prev = current;
                current = current.next;                 
            }
            return false;
        }

        //Mit der Methode Contains wird überprüft ob das Element in der Liste enthatlen ist. 
        public bool Contains(T value)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return true;
                }
                current = current.next;
            }
            return false;
        }

        //Diese Methode prüft ob eine Element an einem bestimmten Indey vorhanden ist.
        public bool IsObjectAtIndex(T value, uint index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            Node<T> current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.next;
            }
            return current.Value.Equals(value);
        }

        //Mit dieser Moethode kann ein Element mittels Indey aufgerufen werden. 
        public T FindByIndex(uint index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            Node<T> current = head;
            for(int i = 0; i< index; i++)
            {
                current = current.next;
            }
            return current.Value;
        }

        //Mit dieser Method kann man die gesamte Liste löschen
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }


        //IEnumerabe Interface



    }
}
