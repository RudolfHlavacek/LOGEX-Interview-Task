using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGEX_Interview_Task
{
    /// <summary>
    /// Class to store and print valid formatted employee records.
    /// </summary>
    public class Employees
    {
        /// <summary>
        /// Dictionary contains string list of employee's last names.
        /// </summary>
        private Dictionary<int, List<string>> records;

        /// <summary>
        /// Regex object.
        /// </summary>
        private Record reg;

        /// <summary>
        /// Ctor of class Employees.
        /// </summary>
        /// <param name="regex_pattern">Regular expresion patter of valid employee record.</param>
        public Employees(string regex_pattern)
        {
            this.records = new Dictionary<int, List<string>>();
            this.reg = new Record(regex_pattern);
        }

        /// <summary>
        /// Method adds employee record if it is in valid format.
        /// </summary>
        /// <param name="employee_record">String of employee record.</param>
        public void Add(string employee_record)
        {
            reg.ChangeRecord(employee_record);
            
            if(reg.IsValid())
            {
                // Gets number and last name if record is in valid format.
                int number = reg.GetNumber();
                string last_name = reg.GetLastName();

                if (!records.ContainsKey(number))
                {
                    // Create new string list if key does not exist.
                    records[number] = new List<string>();
                }
                // Add last name into dictionary using number as key.
                records[number].Add(last_name);
            }
        }

        /// <summary>
        /// Method adds multiple employee records if they are in valid format.
        /// </summary>
        /// <param name="employee_records">Array of strings containing employee's records.</param>
        public void Add(string[] employee_records)
        {
            foreach(string rec in employee_records)
            {
                Add(rec);
            }
        }

        /// <summary>
        /// Method returns formatted emploee records as one string.
        /// </summary>
        /// <returns>Formated string of records.</returns>
        public override string ToString()
        {
            // Orders dictionary by keys.
            OrderRecords();

            List<string> output = new List<string>();
            foreach (int item in records.Keys)
            {
                // Sorts last names in list.
                records[item].Sort();

                // Creates one output line in correct format.
                string tmp = String.Format("{0:D3} {1}x: ", item, records[item].Count());
                tmp += String.Join(", ", records[item]);
                output.Add(tmp);
            }

            return String.Join("\n", output);
        }

        /// <summary>
        /// Method orders record keys in descending order according count of list item. Key with the most elements will be first.
        /// </summary>
        private void OrderRecords()
        {
            records = records.OrderByDescending(pair => pair.Value.Count())
                             .ToDictionary(pair => pair.Key, pair => pair.Value);
        }
    }
}
