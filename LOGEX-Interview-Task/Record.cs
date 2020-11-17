using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LOGEX_Interview_Task
{
    /// <summary>
    /// Class representing employee record.
    /// </summary>
    public class Record
    {
        /// <summary>
        /// Regular expresion pattern.
        /// </summary>
        private string pattern;
        
        /// <summary>
        /// Regex object.
        /// </summary>
        private Regex regex;

        /// <summary>
        /// String containing record.
        /// </summary>
        private string record;

        /// <summary>
        /// Variable is true when record is valid according regex.
        /// </summary>
        private bool valid;

        /// <summary>
        /// Variable containing number from record if it is in valid format. Otherwise contains -42.
        /// </summary>
        private int number;

        /// <summary>
        /// Variable containing last name from record if it is in valid format. Otherwise contains "-42".
        /// </summary>
        private string last_name;

        /// <summary>
        /// Ctor of class Record.
        /// </summary>
        /// <param name="pattern">Regular expresion patter of the record.</param>
        public Record(string pattern)
        {
            this.pattern = pattern;
            this.regex = new Regex(pattern);
            this.valid = false;
        }

        /// <summary>
        /// Method replace old record with new one.
        /// </summary>
        /// <param name="new_record">New record in string format.</param>
        public void ChangeRecord(string new_record)
        {
            record = new_record;
            ParseRecord();
        }

        /// <summary>
        /// If record is in valid format then it is parsed - number and last name are stored in class variables.
        /// </summary>
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

        /// <summary>
        /// Validates if record is in regex format.
        /// </summary>
        /// <returns>Returns true if record is valid. Otherwise returns false.</returns>
        public bool IsValid()
        {
            return valid;
        }

        /// <summary>
        /// Method gets from record a number.
        /// </summary>
        /// <returns>Returns number if record is valid. Otherwise returns -42.</returns>
        public int GetNumber()
        {
            if (valid)
                return this.number;
            else
                return -42;
        }

        /// <summary>
        /// Method gets last name from record.
        /// </summary>
        /// <returns>Return last name if record is valid. Otherwise returns "-42".</returns>
        public string GetLastName()
        {
            if (valid)
                return this.last_name;
            else
                return "-42";
        }
    }
}
