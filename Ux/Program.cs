using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ux
{
    class Program
    {
        static Logic.Manager m = new Logic.Manager();

        static void Main(string[] args)
        {
            //START Check Utils class
            string hhh = "j       , t,  HHH  tuy";
            //string tmpStr = Utils.Normalize(hhh);
            string tmpStr = Utils.Order(hhh);
            //END   Check Utils class

            int choice = 0;
            while (choice != 3)
            {
               choice = PrintMenu();
               if (choice == 1)
               {
                   GetAndChechDoc();
               }
            }
        }


        static int PrintMenu()
        {
            Console.WriteLine("1 - To check if duplicate");
            Console.WriteLine("2 - Show details");
            Console.WriteLine("3 - Exit");
            int choice = int.Parse(Console.ReadLine());
            return choice;
        }

        private static void GetAndChechDoc()
        {
            string doc = "aa nn dd,qq    hh t.";
            bool isDup = m.IsDuplicate(doc);
        }
    }
}
