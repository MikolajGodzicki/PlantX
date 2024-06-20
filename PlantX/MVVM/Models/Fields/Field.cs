using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantX.MVVM.Models.Fields
{
    public class Field
    {
        public string Name { get; set; }
        public decimal Area { get; set; }

        public Field(string name, decimal area)
        {
            Name = name;
            Area = area;
        }
    }
}
