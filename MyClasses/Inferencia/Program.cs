using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClasses;

namespace Inferencia
{
    class Program
    {
        public delegate string Reverse(string s);

        static string ReverseString(string s)
        {
            return new string(s.Reverse().ToArray());
        }

        static string DesreverseString(string s)
        {
            return new string(s.Reverse().ToArray());
        }
        static void Main(string[] args)
        {

            List<int> list = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                list.Add(i);
            }

            List<int> result = list.FindAll(i => i % 2 == 0);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            ////Delegate

            ////Reverse rev = ReverseString;
            ////Func<string,string> rev = ReverseString;


            //Console.WriteLine(rev("a string"));



        }
    }
}
