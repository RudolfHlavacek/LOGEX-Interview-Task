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

            // XXX_FirstName.LastName, where XXX are decimals, and first and last names are strings.
            // String can contains enhanced latin alphabet.
            string regex_pattern = @"^\d+_[a-zA-ZáčďéěíňóřšťúůýžÁČĎÉĚÍŇÓŘŠŤÚŮÝŽöüÖÜ]+\.[a-zA-ZáčďéěíňóřšťúůýžÁČĎÉĚÍŇÓŘŠŤÚŮÝŽöüÖÜ]+$";

            Employees employees = new Employees(regex_pattern);
            employees.Add(input_strings);

            Console.WriteLine(employees.ToString());

            Console.ReadKey();
        }
    }
}
