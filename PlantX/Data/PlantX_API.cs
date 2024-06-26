using PlantX.MVVM.Models.Fields;
using PlantX.MVVM.Models.Pesticides;
using PlantX.MVVM.Models.Plants;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantX.Data
{
    public sealed class PlantX_API
    {
        public static ObservableCollection<Plant> AvailablePlants = [new Plant("Koper"), new Plant("Natka")];
		public static ObservableCollection<Pesticide> AvailablePesticides = [new Pesticide("Stomp", 10, WeightType.Liter), new Pesticide("Amistar", 20, WeightType.Kilogram)];
		public static ObservableCollection<Field> AvailableFields = [new Field("U taty", 100), new Field("Byce", 50)];
	}
}
