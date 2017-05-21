using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace OOPLab08
{
    static class Extensions
    {
        public static int WordCount(this string s)
        {
            return Regex.Matches(s, @"[\w]+").Count;
        }

        //public static TabItem Sele
    }
}