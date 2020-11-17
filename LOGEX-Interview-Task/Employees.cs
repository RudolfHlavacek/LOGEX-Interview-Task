using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGEX_Interview_Task
{
    public class Employees
    {
        private Dictionary<int, List<string>> records;
        private Record reg;


        public Employees(string regex_pattern)
        {
            this.records = new Dictionary<int, List<string>>();
            this.reg = new Record(regex_pattern);
        }

        public void Add(string employee_record)
        {
            reg.ChangeRecord(employee_record);
            
            if(reg.IsValid())
            {
                int number = reg.GetNumber();
                string last_name = reg.GetLastName();

                if (!records.ContainsKey(number))
                {
                    records[number] = new List<string>();
                }
                records[number].Add(last_name);
            }
        }

        public void Add(string[] employee_records)
        {
            foreach(string rec in employee_records)
            {
                Add(rec);
            }
        }

        public override string ToString()
        {
            OrderRecords();

            List<string> output = new List<string>();
            foreach (int item in records.Keys)
            {
                records[item].Sort();

                string tmp = String.Format("{0:D3} {1}x: ", item, records[item].Count());
                tmp += String.Join(", ", records[item]);
                output.Add(tmp);
            }

            return String.Join("\n", output);
        }

        private void OrderRecords()
        {
            records = records.OrderByDescending(pair => pair.Value.Count())
                             .ToDictionary(pair => pair.Key, pair => pair.Value);
        }
    }
}
