using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagementSystem
{
    public class Animal
    {
        public string Name { get; set; }
        public string Diet { get; set; }
        public bool IsFed { get; set; }
        public Animal(string name, string diet)
        {
            Name = name;
            Diet = diet;
        }
    }
}
