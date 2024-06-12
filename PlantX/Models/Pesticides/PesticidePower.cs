using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantX.Models.Pesticides
{
    [Serializable]
    internal class PesticidePower
    {
        /// <summary>
        /// Defines how many liters or kilograms are used to spray on defined Ares
        /// </summary>
        public float Weight { get; set; }

        /// <summary>
        /// Defines what type of weight is: liters, kilograms
        /// </summary>
        public WeightType WeightType { get; set; }

        /// <summary>
        /// Defines the size of farming field
        /// </summary>
        public float Ares { get; set; }
    }
}
