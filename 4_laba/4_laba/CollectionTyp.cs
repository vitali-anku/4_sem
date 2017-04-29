using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_laba
{
    static class ListExtender
    {
        public static void SortMore(this List<string> inputList)
        {
            for (int i = 0; i < inputList.Count; i++)
            {
                for (int j = 0; j < inputList.Count - 1 - i; j++)
                {
                    if (inputList[j].Length > inputList[j + 1].Length)
                    {
                        string tmpParam = inputList[j];
                        inputList[j] = inputList[j + 1];
                        inputList[j + 1] = tmpParam;
                    }
                }
            }
        }


        public static void SortLess(this List<string> inputList)
        {
            for (int i = 0; i < inputList.Count; i++)
            {
                for (int j = 0; j < inputList.Count - 1 - i; j++)
                {
                    if (inputList[j].Length < inputList[j + 1].Length)
                    {
                        string tmpParam = inputList[j];
                        inputList[j] = inputList[j + 1];
                        inputList[j + 1] = tmpParam;
                    }
                }
            }
        }
    }
    class CollectionType<T> : IEnumerable where T:IComparable<T>
    {
        private List<T> list;

        public CollectionType()
        {
            list = new List<T>();
        }

        public T this[int index]
        {
            get
            {
                return list.ElementAt<T>(index);
            }
            set
            {
                list.Insert(index, value);
            }
        }

        public int Count()
        {
            return list.Count();
        }

        public void Add(T item)
        {
            list.Add(item);
        }

        public void Add(CollectionType<T> list2)
        {
            foreach(T item in list2)
            {
                list.Add(item);
            }
        }

        public void InsertAt(int index, T item)
        {
            list.Insert(index, item);
        }

        public void Remove(T item)
        {
            list.Remove(item);
        }

        public void Remove(int index)
        {
            list.RemoveAt(index);
        }

        public void Sort()
        {
            list.Sort();
        }

        public void ReverseLisr()
        {
            list.Reverse();
        }

        public void Print()
        {
            foreach(T item in list)
            {
                Console.Write(item);
            }
        }

        public void WriteToFile()
        {
            using (StreamWriter f1 = File.AppendText(@"D:\visual_studio\ООП\collection.txt"))
            {
                foreach (T item in list)
                {
                    if (item == null)
                        break;
                    f1.Write(item.ToString());
                }
                f1.Close();
            }
        }

        public static int GetMaxCollectionCount(CollectionType<T>[] array)
        {
            try
            {
                int maxCount = 0;
                foreach (CollectionType<T> item in array)
                {
                    if (item.Count() > maxCount)
                    {
                        maxCount = item.Count();
                    }
                }
                return maxCount;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public void Lendth()
        {
            list.Count();
        }

        public void SearchObj(T n)
        {
            int _serch = (from item in list
                          where item.CompareTo(n) == 0 ? true : false
                          select item).Count();
            Console.WriteLine(_serch);
        }

        public IEnumerator GetEnumerator()
        {
            return list.GetEnumerator();
        }


    }
}
