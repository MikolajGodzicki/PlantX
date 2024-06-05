using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantX.Model.Pesticides
{
    [Serializable]
    internal class Pesticide
    {
        /// <summary>
        /// Defines name of pesticide used in farming
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Defines the power of pesticide, ex. 10 Liters per 100 Ares
        /// </summary>
        public PesticidePower Power { get; set; }
    }
}
