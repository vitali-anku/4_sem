using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_laba
{
    class Program
    {

        static void Main(string[] args)
        {
            CollectionType<Prism> firstCollection = new CollectionType<Prism>();
            Prism first = new Prism(10, 20, 30);
            //firstCollection.Add(first);
            //firstCollection.WriteToFile();
            //firstCollection.Print();

            Console.WriteLine("\n" + new String('*', 30));

            List<string> list = new List<string>();
            list.Add("qwe");
            list.Add("ewqeqw");
            list.Add("zxcasdsad");
            foreach (string item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n1 " + new String('*', 30));

            list.Sort();
            foreach (string item in list)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n2" + new String('*', 30));

            list.Remove("qwe");
            foreach (string item in list)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n3" + new String('*', 30));

            list.Reverse();
            foreach (string item in list)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n4" + new String('*', 30));

            string[] words = { "the", "fox", "jumped", "over", "the", "dog" };
            LinkedList<string> str = new LinkedList<string>(words);
            Display(str, "1:");
            str.AddFirst("today");
            Display(str, "2:");
            str.Count();
            Display(str, "3:");
        }

        private static void Display(LinkedList<string> words, string item)
        {
            Console.WriteLine(item);
            foreach(string word in words)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        
    }
}
