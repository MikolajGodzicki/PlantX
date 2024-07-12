using PlantX.MVVM.Models.Fields;
using PlantX.MVVM.Models.Pesticides;
using PlantX.MVVM.Models.Plants;
using PlantX.MVVM.Models.Raports;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PlantX.Data
{
	public sealed class PlantX_API {
		public static ObservableCollection<Plant> AvailablePlants = [new Plant("Koper"), new Plant("Natka")];
		public static ObservableCollection<Pesticide> AvailablePesticides = [new Pesticide("Stomp", 10, WeightType.Liter), new Pesticide("Amistar", 20, WeightType.Kilogram)];
		public static ObservableCollection<Field> AvailableFields = [new Field("U taty", 100), new Field("Byce", 50)];

		public static ObservableCollection<Raport> Raports = new ObservableCollection<Raport>();

		public static Field? GetFieldById(Guid ID) {
			return AvailableFields.FirstOrDefault(e => e.Id == ID);
		}

		public static Pesticide? GetPesticideById(Guid ID) {
			return AvailablePesticides.FirstOrDefault(e => e.Id == ID);
		}
		public static Plant? GetPlantById(Guid ID) {
			return AvailablePlants.FirstOrDefault(e => e.Id == ID);
		}

		public static void Initialize() {
			string appdataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			string fulldataPath = $"{appdataPath}\\.PlantX\\data";

			if (!Directory.Exists(fulldataPath)) {
				Directory.CreateDirectory(fulldataPath);
			}

			string[] files = ["plants.plx", "pesticides.plx", "fields.plx", "raports.plx"];

			foreach (string file in files) {
				string filePath = Path.Combine(fulldataPath, file);
				if (!File.Exists(filePath)) {
					File.Create(filePath);
				}
			}
		}
	}
}
