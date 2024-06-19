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
		public static ObservableCollection<Pesticide> AvailablePesticides = [new Pesticide("Stomp"), new Pesticide("Amistar")];
		public static ObservableCollection<Field> AvailableFields = [new Field("U taty"), new Field("Byce")];
	}
}
