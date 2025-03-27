using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashtable
{
    class Hashtable<K, V>
    {
        private ArrayList.ArrayList<SingelLinkedList.SinglyLinkedList<Tuple<K,V>>>m_container;

        public Hashtable(int size)
        {
            m_container = new ArrayList.ArrayList<SingelLinkedList.SinglyLinkedList<Tuple<K, V>>>(size);
        }
        public void put(K key, V value)
        {
            key.GetHashCode();

            throw new NotImplementedException();
        }

        public V get(K key)
        {
            return default(V);
        }

        public bool get(K key, out V value)
        {
            value = default(V);
            return true;
        }

    }
}
