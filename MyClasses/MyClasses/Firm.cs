using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses
{
    class Firm
    {
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Employee : Person { }

    public class Supervisor : Person
    {
        public List<Employee> Employees { get; set; }

    }

    public class PersonManager
    {
        public Person CreatePerson(string first, string last, bool isSupervisor)
        {
            Person ret = null;

            if (!string.IsNullOrEmpty(first))
            {
                if (isSupervisor)
                {
                    ret = new Supervisor();
                }
                else
                {
                    ret = new Employee();
                }

                ret.FirstName = first;
                ret.LastName = last;
            }

            return ret;
        }

        public List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();

            people.Add(new Person() { FirstName = "Daniel", LastName = "Ferreira" });
            people.Add(new Person() { FirstName = "Rexona", LastName = "Men" });
            people.Add(new Person() { FirstName = "Logitech", LastName = "Mouse" });

            return people;
        }


        public List<Person> GetSupervisors()
        {
            List<Person> people = new List<Person>();

            people.Add(CreatePerson("Daniel", "Ferreira", true));
            people.Add(CreatePerson("RExona", "Men", true));


            return people;
        }

        public List<Person> GetEmployees()
        {
            List<Person> people = new List<Person>();

            people.Add(CreatePerson("Daniel", "Ferreira", false));
            people.Add(CreatePerson("RExona", "Men", false));


            return people;
        }

        public List<Person> GetEmployeesAndSupervisors()
        {
            List<Person> people = new List<Person>();

            people.Add(CreatePerson("Daniel", "Ferreira", false));
            people.Add(CreatePerson("RExona", "Men", false));

            people.Add(CreatePerson("Daniel", "Ferreira", true));
            people.Add(CreatePerson("RExona", "Men", true));


            return people;
        }

    }
}
