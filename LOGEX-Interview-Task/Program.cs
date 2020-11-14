using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGEX_Interview_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input_strings = { "020_Jan.Krutý", "21_Petr.Malý", "021_Pavel.Novák", "514_Karel.Ospalý" };
            string[] expected_strings = { "021 2x: Malý, Novák", "020 1x: Krutý", "514 1x: Ospalý" };

            foreach (string s in input_strings)
            {
                Console.WriteLine(s);
            }
            
            Console.ReadKey();
        }
    }
}
