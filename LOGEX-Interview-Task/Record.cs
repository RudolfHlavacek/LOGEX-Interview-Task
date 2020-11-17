using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LOGEX_Interview_Task
{
    class Record
    {
        private string pattern;
        private Regex regex;
        private string record;
        private bool valid;

        private int number;
        private string last_name;


        public Record(string pattern)
        {
            this.pattern = pattern;
            this.regex = new Regex(pattern);
            this.valid = false;
        }


        public void ChangeRecord(string new_record)
        {
            record = new_record;
            ParseRecord();
        }

        private void ParseRecord()
        {
            if (regex.IsMatch(record))
            {
                string[] rec_parts = record.Split('_', '.');
                number = int.Parse(rec_parts[0]);
                last_name = rec_parts[2];

                valid = true;
            }
            else
            {
                valid = false;
            }
        }

        public bool IsValid()
        {
            return valid;
        }

        public int GetNumber()
        {
            if (valid)
                return this.number;
            else
                return -42;
        }

        public string GetLastName()
        {
            if (valid)
                return this.last_name;
            else
                return "-42";
        }
    }
}
