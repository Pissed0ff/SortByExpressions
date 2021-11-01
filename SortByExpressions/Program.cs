using System;
using System.Collections.Generic;
using System.Linq;

namespace SortByExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>()
            {
                new Person() {FirstName = "Alex", SecondName ="Vagner", ThirdName = "Ivanovich", DateOfBirth = new DateTime(1965,10,30)},
                new Person() {FirstName = "David", SecondName ="Dehea", ThirdName = "Jonovich", DateOfBirth = new DateTime(1989,07,5)},
                new Person() {FirstName = "Irina", SecondName ="Guver", ThirdName = "Kirillovna", DateOfBirth = new DateTime(1999,11,23)}
            };




            var order = "SecondName";

            var res = people.OrderBy(order).ToList();
            var result = people.OrderBy(p => p.SecondName);

            foreach(var el in res)
                Console.WriteLine("{0} {1} {2} {3}",el.FirstName,el.SecondName,el.ThirdName,el.DateOfBirth);
        }
    }
}
