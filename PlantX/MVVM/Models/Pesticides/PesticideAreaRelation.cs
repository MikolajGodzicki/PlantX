using PlantX.MVVM.Models.Fields;
using PlantX.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PlantX.MVVM.Models.Pesticides
{
    class PesticideAreaRelation {
        public Pesticide Pesticide { get; set; }
        public Field Field { get; set; }

        public decimal CalculatedWeight => Pesticide.Weight * ((decimal)Field.Area / 100);

        public string PesticideWeightType {
            get {
                string weightType = Pesticide.WeightType switch {
                    WeightType.Kilogram => "Kg",
                    WeightType.Liter => "L",
                    _ => "Nieznany"
                };

                return weightType;
            }
        }
    }
}
