using System;
using System.Collections;
using System.Collections.Generic;

namespace Lists.Entity
{
    public class Person : IComparable
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public int Age { get; set; }
        public int PostCode { get; set; }
        public int Svnr { get; set; }

        public Person()
            : this("noName", "noName", 0, 0, 0)
        {

        }
        public Person(string firstName, string lastName, int age, int postCode, int svnr)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            PostCode = postCode;
            Svnr = svnr;
        }

        public static IComparer SortOnAgeDescending()
        {
            return (IComparer)new SortPersonAgeDescending();
        }
        public static IComparer SortOnPostCodeDescending()
        {
            return (IComparer)new SortPersonPostCodeDescending();
        }
        public static IComparer SortOnSvnrDescending()
        {
            return (IComparer)new SortPersonOnSvnrDescending();
        }
        public int CompareTo(object obj)
        {
            Person other = obj as Person;

            if (other == null)
                throw new ArgumentNullException(nameof(other));

            return this.FullName.CompareTo(other.FullName) * -1;
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName} | {Age} | {PostCode}";
        }

    }
}
