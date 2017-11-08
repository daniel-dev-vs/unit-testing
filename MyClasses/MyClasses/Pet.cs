using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses
{
    public class Pet
    {
        public Pet()
        {

        }

        public Dog AdoptDog()
        {
            return new Dog();
        }
    }

    public class Dog : Pet
    {
        public Dog() { }
        public void Latir()
        {
            Console.WriteLine("AUAUAU");
        }
    }

    public class Car
    {
        public Car() { }
        public void Miar()
        {
            Console.WriteLine("MIAU MIAU");
        }

    }
}
