using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGEX_Interview_Task
{
    class Employees
    {
        private Dictionary<int, List<string>> records;
        private Record reg;

        //public Employees()
        //{
        //    this.records = new Dictionary<int, List<string>>();
        //    this.rec = new Record();
        //}

        public Employees(string regex)
        {
            this.records = new Dictionary<int, List<string>>();
            this.reg = new Record(regex);
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

        //public override string ToString()
        //{
        //    return base.ToString();
        //}
    }
}
