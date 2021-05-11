using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_C_sharp_12
{
    class MultiMap<TKey, TValue>
    {
        public MultiMap()
        {
            items = new List<KeyValuePair<TKey, TValue>>();
        }
        private List<KeyValuePair<TKey, TValue>> items;

        public ICollection<TKey> Keys => (ICollection<TKey>)(ICollection)from e in items select e.Key;

        public ICollection<TValue> Values => (ICollection<TValue>)(ICollection)from e in items select e.Value;
        public int Count => items.Count;

        

        public void Add(TKey key, TValue value)
        {
            items.Add(new KeyValuePair<TKey, TValue>(key,value));
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            items.Add(item);
        }

        public void Clear()
        {
            
            items.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            var elem = from e in items where (e.Key.GetHashCode() == item.Key.GetHashCode() && e.Value.GetHashCode() == item.Value.GetHashCode()) select e;
            return elem != null ? true : false;
        }

        public bool ContainsKey(TKey key)
        {
            var elem = from e in items where (e.Key.GetHashCode() == key.GetHashCode()) select e;
            return elem != null ? true : false;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        /// <summary>
        /// Delete first finded elem
        /// </summary>
        /// <param name="key">search key</param>
        /// <returns></returns>
        public bool Remove(TKey key)
        {
            items.Remove(items.Find(e => e.Key.GetHashCode() == key.GetHashCode()));
            return true;
        }

        /// <summary>
        /// Delete first finded elem
        /// </summary>
        /// <param name="item">search item</param>
        /// <returns></returns>
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            items.Remove(items.Find(e => e.GetHashCode() == item.GetHashCode()));
            return true;
        }
    }
}
