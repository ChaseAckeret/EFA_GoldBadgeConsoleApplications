using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    class Menu
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public decimal Price { get; set; }

        public Menu() { }
        public Menu(int id, string name, string description, string ingreidents, decimal price)
        {
            ID = id;
            Name = name;
            Description = description;
            Ingredients = ingreidents;
            Price = price;
        }
    }
}
