using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_V
{
    class Validate
    {
        private bool e = false, o=false;
        public bool Prover(string l, string l1, string a, string b, string c, string d)
        {
            if (l == l1 && a == b && c == d) 
            {
                e = true;
            }
            else
            {
                e = false;
            }

            if (e)
            {
                o = true;
            }
            return o;
        }
    }
}
