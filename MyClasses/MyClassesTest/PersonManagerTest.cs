using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System.Collections.Generic;

namespace MyClassesTest
{
    [TestClass]
    public class PersonManagerTest
    {
        [TestMethod]
        public void IsInstanceOfEmployee()
        {
            PersonManager pmgr = new PersonManager();

            Person per = pmgr.CreatePerson("Daniel", "Ferreira", false);

            Assert.IsInstanceOfType(per, typeof(Employee));
        }

        [TestMethod]
        public void IsCollectIsOfTypeTest()
        {
            PersonManager mgr = new PersonManager();
            List<Person> peopleActual = new List<Person>();

            peopleActual = mgr.GetEmployees();


            CollectionAssert.AllItemsAreInstancesOfType(peopleActual, typeof(Employee));
        }

        [TestMethod]
        public void IsInstanceOfEmployeeAndSupervirs()
        {
            PersonManager mgr = new PersonManager();
            List<Person> peopleActual = new List<Person>();

            peopleActual = mgr.GetEmployees();


            CollectionAssert.AllItemsAreNotNull(peopleActual);
        }

        [TestMethod]
        public void DoEmployeeExisTest()
        {
            Supervisor super = new Supervisor();

            super.Employees = new List<Employee>();

            super.Employees.Add(new Employee() {FirstName = "Rexona", LastName = "Men" });

            super.Employees.Add(new Employee() { FirstName = "Logitech", LastName = "Mouse" });

            Assert.IsTrue(super.Employees.Count > 0);

        }
    }
}
