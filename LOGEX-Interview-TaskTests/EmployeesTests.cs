using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LOGEX_Interview_Task;

namespace LOGEX_Interview_TaskTests
{
    [TestClass]
    public class EmployeesTests
    {
        private Employees employees;
        private string regex_pattern = @"^\d+_[a-zA-Z]+\.[a-zA-Z]+$";

        [TestInitialize]
        public void Initialize()
        {
            employees = new Employees(regex_pattern);
        }

        [TestMethod]
        public void DefaultValues()
        {
            Assert.AreEqual("", employees.ToString());
        }

        [TestMethod]
        public void Add_ValidString()
        {
            employees.Add("020_Jan.Kruty");

            Assert.AreEqual("020 1x: Kruty", employees.ToString());
        }

        [TestMethod]
        public void Add_InvalidString()
        {
            employees.Add("02A_Jan.Kruty");

            Assert.AreEqual("", employees.ToString());
        }

        [TestMethod]
        public void Add_ValidArrayOfStrings_SameNumber_SameLastName()
        {
            string[] inputs = { "020_Jan.Kruty", "020_Jan.Kruty" };
            employees.Add(inputs);
            
            Assert.AreEqual("020 2x: Kruty, Kruty", employees.ToString());
        }

        [TestMethod]
        public void Add_ValidArrayOfStrings_SameNumber_DiffLastName()
        {
            string[] inputs = { "020_Jan.Kruty", "020_Adam.Novotny" };
            employees.Add(inputs);

            Assert.AreEqual("020 2x: Kruty, Novotny", employees.ToString());
        }

        [TestMethod]
        public void Add_ValidArrayOfStrings_SameNumber_DiffLastName_NonOrdered()
        {
            string[] inputs = { "020_Jan.Kruty", "020_Jan.Fibich" };
            employees.Add(inputs);

            Assert.AreEqual("020 2x: Fibich, Kruty", employees.ToString());
        }

        [TestMethod]
        public void Add_ValidArrayOfStrings_DiffNumber_SameLastName()
        {
            string[] inputs = { "020_Jan.Kruty", "021_Jan.Kruty" };
            employees.Add(inputs);

            Assert.AreEqual("020 1x: Kruty\n021 1x: Kruty", employees.ToString());
        }

        [TestMethod]
        public void Add_InvalidArrayOfStrings()
        {
            string[] inputs = { "02A_Jan.Kruty", "021__Jan.Kruty", "020_Jan.Fib.ich", "514_Kar$el.Ospalý" };
            employees.Add(inputs);

            Assert.AreEqual("", employees.ToString());
        }

        [TestMethod]
        public void Add_ValidAndInvalidArrayOfStrings()
        {
            string[] inputs = { "020_Jan.Kruty", "21_Petr.Maly", "514_Karel.Ospaly.NonValid", "021_Pavel.Novak", "514_Karel.Ospaly" };
            employees.Add(inputs);

            Assert.AreEqual("021 2x: Maly, Novak\n020 1x: Kruty\n514 1x: Ospaly", employees.ToString());
        }
    }
}
