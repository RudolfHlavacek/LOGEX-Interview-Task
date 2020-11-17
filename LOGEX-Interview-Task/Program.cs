using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions; // TODO: Can be removed from here. ONLY testing purposes.

namespace LOGEX_Interview_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] input_strings = { "020_Jan.Krutý", "21_Petr.Malý", "021_Pavel.Novák", "514_Karel.Ospalý" };
            string[] input_strings = { "020_Jan.Kruty", "21_Petr.Maly", "21_Petr.Adam", "021_Pavel.Novak", "514_Karel.Ospaly",
                                        "020_Jan.Krutý", "21_Petr.Malý", "021_Pavel.Novák", "514_Karel.Ospalý.ospal"};
            string[] expected_strings = { "021 2x: Malý, Novák", "020 1x: Krutý", "514 1x: Ospalý" };

            //string regex_pattern = @"^\d{3}\_[a-zA-ZáčďéěíňóřšťúůýžÁČĎÉĚÍŇÓŘŠŤÚŮÝŽöüÖÜ]+\.[a-zA-ZáčďéěíňóřšťúůýžÁČĎÉĚÍŇÓŘŠŤÚŮÝŽöüÖÜ]+$";
            string regex_pattern = @"^\d+_[a-zA-ZáčďéěíňóřšťúůýžÁČĎÉĚÍŇÓŘŠŤÚŮÝŽöüÖÜ]+\.[a-zA-ZáčďéěíňóřšťúůýžÁČĎÉĚÍŇÓŘŠŤÚŮÝŽöüÖÜ]+$";

            //Regex reg = new Regex(regex_pattern);



            //foreach (string s in input_strings)
            //{
            //    string tmp = String.Format("{0}: {1}", s, reg.IsMatch(s));
            //    Console.WriteLine(tmp);
            //}

            //string[] words = input_strings[0].Split('_', '.');

            //foreach(string word in words)
            //    Console.WriteLine(word);

            //Console.WriteLine("\n\n\n\n\n");

            Employees employees = new Employees(regex_pattern);
            employees.Add(input_strings);

            //foreach(int item in employees.records.Keys)
            //{
            //    string temp = String.Format("{0}: ", item);
            //    temp += String.Join(", ", employees.records[item]);

            //    Console.WriteLine(temp);
            //}

            Console.WriteLine(employees.ToString());
            Console.WriteLine("\n\n\n");
            Console.WriteLine(employees.ToString());
            
            Console.ReadKey();
        }
    }
}
