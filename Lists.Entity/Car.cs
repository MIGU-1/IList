using System;
using System.Collections.Generic;
using System.Text;

namespace Lists.Entity
{
    public class Car
    {
        public string Make { get; set; }
        public string Type { get; set; }
        public int Number { get; set; }

        public Car(string make, string type, int number)
        {
            Make = make;
            Type = type;
            Number = number;
        }

    }
}
