using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tamagotchi
{
    class Dog : ILand
    {
        public double Batheability { get; set; }
        public double Feedability { get; set; }
        public double Sleepability { get; set; }

        public Dog()
        {
            Batheability = 1;
            Feedability = 1;
            Sleepability = 1;
        }

        public void Bathe()
        {
            Batheability = 1;
        }

        public void Feed()
        {
            Feedability = 1;
        }

        public void Sleep()
        {
            Sleepability = 1;
        }

        public void update()
        {
            Batheability -= 0.0001;
            Feedability -=  0.001;
            Sleepability -= 0.00001;
        }
    }
}
