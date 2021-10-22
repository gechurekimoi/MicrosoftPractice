using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LRUCache
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            //ArrayList arrayList = new ArrayList();

            //LRUCache lRUCache = new LRUCache(2);

            //arrayList.Add(null);

            //lRUCache.Put(1, 1); // cache is {1=1}
            //arrayList.Add(null);

            //lRUCache.Put(2, 2); // cache is {1=1, 2=2}
            //arrayList.Add(null);

            //arrayList.Add(lRUCache.Get(1));    // return 1

            //lRUCache.Put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
            //arrayList.Add(null);

            //arrayList.Add(lRUCache.Get(2));    // returns -1 (not found)


            //lRUCache.Put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
            //arrayList.Add(null);


            //arrayList.Add(lRUCache.Get(1));    // return -1 (not found)


            //arrayList.Add(lRUCache.Get(3));    // return 3


            //arrayList.Add(lRUCache.Get(4));    // return 4


        }
    }


    public class LRUCache
    {
        public class Cache
        {
            public int Key { get; set; }
            public int Value { get; set; }

            public Cache(int Key, int Value)
            {
                this.Key = Key;
                this.Value = Value;
            }
        }

        Dictionary<int, LinkedListNode<Cache>> dictionary = new Dictionary<int, LinkedListNode<Cache>>();

        LinkedList<Cache> linkedList = new LinkedList<Cache>();

        public int Capacity = 0;


        public LRUCache(int capacity)
        {
            this.Capacity = capacity;
        }

        public int Get(int key)
        {

            if (!dictionary.ContainsKey(key))
            {
                return -1;
            }

            //once something is retrived it comes to the top of the cache
            var itemToBeUpdated = dictionary[key];

            linkedList.Remove(itemToBeUpdated);

            linkedList.AddFirst(itemToBeUpdated);

            return itemToBeUpdated.Value.Value;

        }

        public void Put(int key, int value)
        {

            if (dictionary.ContainsKey(key))
            {
                //we need to update the item  by deleting old and adding new 

                dictionary[key].Value.Value = value;

                var itemToBeUpdated = dictionary[key];
                
                linkedList.Remove(itemToBeUpdated.Value);

                linkedList.AddFirst(itemToBeUpdated);

            }
            else
            {
                var itemToBeAdded = new LinkedListNode<Cache>(new Cache(key, value));

                dictionary.Add(key, itemToBeAdded);

                linkedList.AddFirst(itemToBeAdded);


                if (dictionary.Count > Capacity)
                {
                    //remove object from both dictionary and linked list
                    var lessUsedItem = linkedList.Last.Value;

                    dictionary.Remove(lessUsedItem.Key);
                    linkedList.RemoveLast();
                }

            }

        }
    }




    //public class LRUCache
    //{

    //    private Dictionary<int, int> dataStore;
    //    private Dictionary<int, DateTime> getsStore;
    //    private int MaxCapacity;
    //    public LRUCache(int capacity)
    //    {
    //        MaxCapacity = capacity;

    //        dataStore = new Dictionary<int, int>();

    //        getsStore = new Dictionary<int, DateTime>();

    //    }

    //    public int Get(int key)
    //    {
    //        int value = 0;

    //        bool valueExists = dataStore.TryGetValue(key, out value);

    //        if (valueExists)
    //        {
    //            UpdateGetStore(key);
    //            return value;
    //        }
    //        else
    //        {
    //            return -1;
    //        }
    //    }

    //    public void Put(int key, int value)
    //    {

    //        if (dataStore.ContainsKey(key))
    //        {
    //            UpdateKeyWithNewValue(key, value);
    //        }
    //        else
    //        {
    //            if (dataStore.Count >= MaxCapacity)
    //            {
    //                RemoveLessUsedElement();
    //            }

    //            dataStore.Add(key, value);

    //            getsStore.Add(key, DateTime.Now);
    //        }



    //    }


    //    private void RemoveLessUsedElement()
    //    {

    //        var LessUsedElement = getsStore.OrderBy(p => p.Value).FirstOrDefault().Key;

    //        dataStore.Remove(LessUsedElement);

    //        getsStore.Remove(LessUsedElement);
    //    }

    //    private void UpdateGetStore(int Key)
    //    {
    //        DateTime value = DateTime.Now;

    //        getsStore.TryGetValue(Key, out value);

    //        getsStore.Remove(Key);

    //        value = DateTime.Now;

    //        getsStore.Add(Key, value);
    //    }

    //    private void UpdateKeyWithNewValue(int Key, int Value)
    //    {
    //        dataStore.Remove(Key);

    //        dataStore.Add(Key, Value);

    //        UpdateGetStore(Key);
    //    }
    //}

}
