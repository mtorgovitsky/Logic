using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trees;

namespace Logic
{
    public class Manager
    {
        Dictionary<string, Doc> documents;

        public Manager()
        {
            documents = new Dictionary<string, Doc>();
        }

        /// <summary>
        /// Checks if there's such a member in the Doc collection (called documents)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool IsDuplicate(string input)
        {
            input = Utils.Normalize(input);
            string key = Utils.Order(input);
            if (documents.ContainsKey(key))
            {
                documents[key].docCount++;
                Permutation addMember = new Permutation(input);
                if (input == addMember.perm)
                    addMember.count++;
                else
                {
                    documents[key].treeMember.Add(addMember);
                    addMember.count++;
                }
            }

        }
    }
}
