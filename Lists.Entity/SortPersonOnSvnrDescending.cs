using System;
using System.Collections;

namespace Lists.Entity
{
    internal class SortPersonOnSvnrDescending : IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            Person person1 = x as Person;
            Person person2 = y as Person;

            if (person1 == null)
                throw new ArgumentNullException(nameof(person1));
            if (person2 == null)
                throw new ArgumentNullException(nameof(person2));

            if (person1.Svnr < person2.Svnr)
            {
                return 1;
            }
            else if (person1.Svnr > person2.Svnr)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}