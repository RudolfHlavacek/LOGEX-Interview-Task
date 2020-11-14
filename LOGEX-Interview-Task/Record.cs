using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGEX_Interview_Task
{
    class Record
    {
        private string redex;
        private string record;

        public Record(string redex)
        {
            this.redex = redex;
        }

        public Record(string redex, string record)
        {
            this.redex = redex;
            this.record = record;
        }

        public void ChangeRecord(string new_record)
        {
            this.record = new_record;
        }

        public bool IsValid()
        {

        }

        public int GetNumber()
        {

        }

        public string GetLastName()
        {

        }
    }
}
