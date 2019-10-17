using Lists.Entity;
using Lists.ListLogic;
using System;
using System.Collections.Generic;

namespace List.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList myList = new MyList();
            Person person1 = new Person("Max1", "Mustermann", 10, 5270, 1234);
            Person person2 = new Person("Max2", "Mustermann", 12, 3380, 1235);
            Person person3 = new Person("Max3", "Mustermann", 11, 5634, 1236);
            Person person4 = new Person("Max4", "Mustermann", 14, 1234, 1237);
            Person person5 = new Person("Max5", "Mustermann", 13, 5270, 1238);
            Person person6 = new Person("Max6", "Mustermann", 15, 3380, 1239);
            Person person7 = new Person("Max7", "Mustermann", 16, 5634, 1240);
            Person person8 = new Person("Max8", "Mustermann", 17, 1234, 1241);

            myList.Add(person1);
            myList.Add(person2);
            myList.Add(person3);
            myList.Add(person4);
            myList.Add(person5);
            myList.Add(person6);
            myList.Add(person7);
            myList.Add(person8);

            Console.WriteLine("UNSORTIERT");

            foreach (var person in myList)
            {
                Console.WriteLine(person.ToString());
            }

            MyList.Sort(myList, Person.SortOnAgeDescending());

            Console.WriteLine("SORTIERT");

            foreach (var person in myList)
            {
                Console.WriteLine(person.ToString());
            }

            Console.ReadKey();
        }
    }
}
