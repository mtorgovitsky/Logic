using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal class Permutation : IComparable<Permutation>
    {
        public string perm { get; set; }
        public int count { get; set; }

        public Permutation(string strInput)
        {
            perm = strInput;
            count++;
        }

        public int CompareTo(Permutation other)
        {
            int whoIsBigger = string.Compare(this.perm, other.perm);
            return whoIsBigger;
        }
    }
}
