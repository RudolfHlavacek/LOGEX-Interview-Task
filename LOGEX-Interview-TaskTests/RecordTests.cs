using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LOGEX_Interview_Task;

namespace LOGEX_Interview_TaskTests
{
    [TestClass]
    public class RecordTests
    {
        private string regex_pattern = @"^\d+_[a-zA-ZáčďéěíňóřšťúůýžÁČĎÉĚÍŇÓŘŠŤÚŮÝŽöüÖÜ]+\.[a-zA-ZáčďéěíňóřšťúůýžÁČĎÉĚÍŇÓŘŠŤÚŮÝŽöüÖÜ]+$";
        private Record record;

        [TestInitialize]
        public void Initialize()
        {
            record = new Record(regex_pattern);
        }

        [TestMethod]
        public void DefaultValues()
        {
            Assert.AreEqual(false, record.IsValid());
            Assert.AreEqual(-42, record.GetNumber());
            Assert.AreEqual("-42", record.GetLastName());
        }

        [TestMethod]
        public void IsValid_ValidInput_ReturnsTrue()
        {
            string[] valid_strings = { "1_Adam.Holy", "13_Adam.Holy", "123_ADam.Holy",
                                        "020_Jan.Krutý", "21_Petr.Malý", "021_Pavel.Novák", "514_Karel.Ospalý" };

            foreach (string s in valid_strings)
            {
                record.ChangeRecord(s);
                bool result = record.IsValid();
                Assert.AreEqual(true, result);
            }
        }

        [TestMethod]
        public void IsValid_InvalidInput_ReturnsFalse()
        {
            record.ChangeRecord("1a1_Adam.Holy");
            Assert.AreEqual(false, record.IsValid());

            record.ChangeRecord("1$3_Adam.Holy");
            Assert.AreEqual(false, record.IsValid());

            record.ChangeRecord("123_Ad_am.Holy");
            Assert.AreEqual(false, record.IsValid());

            record.ChangeRecord("020_Jan.Kru.tý");
            Assert.AreEqual(false, record.IsValid());

            record.ChangeRecord("21_Petr..Malý");
            Assert.AreEqual(false, record.IsValid());

            record.ChangeRecord("021__Pavel.Novák");
            Assert.AreEqual(false, record.IsValid());

            record.ChangeRecord("514_Ka$rel.Ospalý");
            Assert.AreEqual(false, record.IsValid());

        }

        [TestMethod]
        public void GetNumber_ValidRec_ReturnsNumber()
        {
            record.ChangeRecord("020_Jan.Krutý");
            Assert.AreEqual(20, record.GetNumber());

            record.ChangeRecord("21_Petr.Malý");
            Assert.AreEqual(21, record.GetNumber());

            record.ChangeRecord("021_Pavel.Novák");
            Assert.AreEqual(21, record.GetNumber());

            record.ChangeRecord("514_Karel.Ospalý");
            Assert.AreEqual(514, record.GetNumber());
        }

        [TestMethod]
        public void GetNumber_InvalidRec_ReturnsErrorNumber()
        {
            int error_number = -42;

            record.ChangeRecord("020_Jan..Krutý");
            Assert.AreEqual(error_number, record.GetNumber());

            record.ChangeRecord("21_Pe_tr.Malý");
            Assert.AreEqual(error_number, record.GetNumber());

            record.ChangeRecord("0B1_Pavel.Novák");
            Assert.AreEqual(error_number, record.GetNumber());

            record.ChangeRecord("514_Karel.Ospalý.Pomalý");
            Assert.AreEqual(error_number, record.GetNumber());
        }

        [TestMethod]
        public void GetLastName_ValidRec_ReturnsValidString()
        {
            record.ChangeRecord("020_Jan.Krutý");
            Assert.AreEqual("Krutý", record.GetLastName());

            record.ChangeRecord("21_Petr.Malý");
            Assert.AreEqual("Malý", record.GetLastName());

            record.ChangeRecord("021_Pavel.Novák");
            Assert.AreEqual("Novák", record.GetLastName());

            record.ChangeRecord("514_Karel.Ospalý");
            Assert.AreEqual("Ospalý", record.GetLastName());
        }

        [TestMethod]
        public void GetLastName_InvalidRec_ReturnsErrorString()
        {
            string error_string = "-42";

            record.ChangeRecord("020_Jan..Krutý");
            Assert.AreEqual(error_string, record.GetLastName());

            record.ChangeRecord("21_Pe_tr.Malý");
            Assert.AreEqual(error_string, record.GetLastName());

            record.ChangeRecord("0B1_Pavel.Novák");
            Assert.AreEqual(error_string, record.GetLastName());

            record.ChangeRecord("514_Karel.Ospalý.Pomalý");
            Assert.AreEqual(error_string, record.GetLastName());
        }

        [TestMethod]
        public void ChangeRecord_ValidChange()
        {
            record.ChangeRecord("020_Jan.Krutý");
            Assert.AreEqual(true, record.IsValid());
            Assert.AreEqual(20, record.GetNumber());
            Assert.AreEqual("Krutý", record.GetLastName());

            record.ChangeRecord("21_Petr.Malý");
            Assert.AreEqual(true, record.IsValid());
            Assert.AreEqual(21, record.GetNumber());
            Assert.AreEqual("Malý", record.GetLastName());
        }

        [TestMethod]
        public void ChangeRecord_InvalidChange()
        {
            record.ChangeRecord("020_Jan.Krutý");
            Assert.AreEqual(true, record.IsValid());
            Assert.AreEqual(20, record.GetNumber());
            Assert.AreEqual("Krutý", record.GetLastName());

            record.ChangeRecord("21__Petr.Malý");
            Assert.AreEqual(false, record.IsValid());
            Assert.AreEqual(-42, record.GetNumber());
            Assert.AreEqual("-42", record.GetLastName());
        }
    }
}
