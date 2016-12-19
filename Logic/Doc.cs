using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trees;

namespace Logic
{
    internal class Doc : IComparable
    {
        public int docCount { get; set; }
        public BinaryTree<Permutation> treeMember { get; set; }


        public Doc(string member)
        {
            docCount++;
        }
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
