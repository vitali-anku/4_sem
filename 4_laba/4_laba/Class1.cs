using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_laba
{
    class Prism:IComparable<Prism>
    {
        private const string figureType = "Prism";
        private int baseSide;
        private int height;
        public int[] aggr = new int[3];
        private int numberOfEdges;
        private double capasity;
        public static int numberOfInstances;
        public readonly int ID;

        int IComparable<Prism>.CompareTo(Prism obj)
        {
            if (this.Capasity == (obj as Prism).Capasity)
                return 1;
            if (this.Capasity > (obj as Prism).Capasity)
                return -1;
            else
                return 0;
        }

        public override string ToString()
        {
            string buf = null;
            for (int i = 0; i < aggr.Length-1; i++)
            {
                buf += aggr[i];
                buf += ", ";
            }
            buf += NumberOfEdges;
            return buf;
        }

        public Prism()
        {
            baseSide = 0;
            height = 0;
            numberOfEdges = 0;
            ID = BaseSide.GetHashCode() + Height.GetHashCode() + NumberOfEdges.GetHashCode();
            numberOfInstances++;
        }

        public Prism(int BaseSide, int Height, int NumberOfEdges)
        {
            aggr[0]= this.baseSide = BaseSide;
            aggr[1] = this.height = Height;
            aggr[2] = this.numberOfEdges = NumberOfEdges;
        }


        public double Capasity
        {
            get
            {
                return capasity;
            }
            set
            {
                capasity = value;
            }
        }

        public string FigureType
        {
            get { return figureType; }
        }
        public int BaseSide
        {
            get
            {
                return baseSide;
            }
            set
            {
                if (value > 0)
                {
                    baseSide = value;
                }
                else
                {
                    Console.WriteLine("Wrong parameter: Base side. Repeat input:");
                    BaseSide = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                if (value > 0)
                {
                    height = value;
                }
                else
                {
                    Console.WriteLine("Wrong parameter: Height. Repeat input:");
                    Height = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
        public int NumberOfEdges
        {
            get
            {
                return numberOfEdges;
            }
            set
            {
                if (value > 2)
                {
                    numberOfEdges = value;
                }
                else
                {
                    Console.WriteLine("Wrong parameter: Number of edges. Repeat input:");
                    NumberOfEdges = Convert.ToInt32(Console.ReadLine());
                }
            }
        }

        public static void ClassInfo()
        {
            Console.WriteLine("This class realize Prism figure");
        }

        public void Print()
        {
            Console.WriteLine("Base side:{0}\nHeight:{1}\nNumber of edges:{2}\nID: {3}", BaseSide, Height, NumberOfEdges, ID);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Prism);
        }

        public bool Equals(Prism obj)
        {
            if (obj == null) return false;
            return this.BaseSide == obj.BaseSide && this.Height == obj.Height && this.NumberOfEdges == obj.NumberOfEdges;
        }

        public override int GetHashCode()
        {
            return BaseSide.GetHashCode() + Height.GetHashCode() + NumberOfEdges.GetHashCode();
        }

        ~Prism()
        {
            numberOfInstances--;
        }
    }
}
