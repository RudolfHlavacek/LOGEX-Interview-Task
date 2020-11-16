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

        public Record()
        {

        }

        public Record(string pattern)
        {
            this.pattern = pattern;
            regex = new Regex(pattern);
        }

        //public Record(string redex, string record)
        //{
        //    this.redex = redex;
        //    this.record = record;
        //}

        public void ChangeRecord(string new_record)
        {
            this.record = new_record;
        }

        public bool IsValid()
        {
            return false;
        }

        public int GetNumber()
        {
            return -42;
        }

        public string GetLastName()
        {
            return "-42";
        }
    }
}
