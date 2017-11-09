using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System.Collections.Generic;

namespace MyClassesTest
{
    [TestClass]
    public class CollectionAssertClass
    {
        [TestMethod]
        public void AreCollectionsEqualFailsBecauseNoCompareTest()
        {
            PersonManager mgr = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleExpected.Add(new Person() {FirstName = "Daniel", LastName = "Ferreira" });
            peopleExpected.Add(new Person() { FirstName = "Rexona", LastName = "Men" });
            peopleExpected.Add(new Person() { FirstName = "Logitech", LastName = "Mouse" });

            peopleActual = mgr.GetPeople();
            
            CollectionAssert.AreEqual(peopleExpected, peopleActual);
        }

        [TestMethod]
        public void AreCollectionsEqualWithComparerTest()
        {
            PersonManager mgr = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleExpected.Add(new Person() { FirstName = "Daniel", LastName = "Ferreira" });
            peopleExpected.Add(new Person() { FirstName = "Rexona", LastName = "Men" });
            peopleExpected.Add(new Person() { FirstName = "Logitech", LastName = "Mouse" });

            peopleActual = mgr.GetPeople();

            CollectionAssert.AreEqual(peopleExpected, peopleActual, Comparer<Person>.Create(
                (x,y) => x.FirstName == y.FirstName && x.LastName == y.LastName ?
                0 : 1));
        }

        [TestMethod]
        public void AreCollectionsEqualTest()
        {
            PersonManager mgr = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleExpected.Add(new Person() { FirstName = "Daniel", LastName = "Ferreira" });
            peopleExpected.Add(new Person() { FirstName = "Rexona", LastName = "Men" });
            peopleExpected.Add(new Person() { FirstName = "Logitech", LastName = "Mouse" });

            peopleActual = mgr.GetPeople();
            peopleExpected = peopleActual;

            CollectionAssert.AreEqual(peopleExpected, peopleActual);
        }

        [TestMethod]
        public void IsCollectIsOfTypeTest()
        {
            PersonManager mgr = new PersonManager();      
            List<Person> peopleActual = new List<Person>();            

            peopleActual = mgr.GetSupervisors();


            CollectionAssert.AllItemsAreInstancesOfType(peopleActual, typeof(Supervisor));
        }

    }
}
