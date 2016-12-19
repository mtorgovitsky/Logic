using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logic
{
    public static class Utils
    {
        public static string Normalize(string param)
        {
            param = Regex.Replace(param, @"[ ,.     ]+", " ");
            return param.ToLower();
        }

        public static string Order(string param)
        {
            param = Normalize(param);
            string[] res = param.Split(' ');
            Array.Sort(res);
            return string.Join(" ", res);
        }
    }
}
