using Newtonsoft.Json;
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
		static string[] files = ["plants.plx", "pesticides.plx", "fields.plx", "raports.plx"];


		public static ObservableCollection<Plant> AvailablePlants = default!;
		public static ObservableCollection<Pesticide> AvailablePesticides = default!;
		public static ObservableCollection<Field> AvailableFields = default!;

		public static ObservableCollection<Raport> Raports = default!;

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
			string fulldataPath = GetFullPath();

			if (!Directory.Exists(fulldataPath)) {
				Directory.CreateDirectory(fulldataPath);
			}

			foreach (string file in files) {
				string filePath = Path.Combine(fulldataPath, file);
				if (!File.Exists(filePath)) {
					File.Create(filePath);
				}
			}

			AvailablePlants = GetFileCollection<Plant>(File.ReadAllText(Path.Combine(fulldataPath, files[0])));
			AvailablePesticides = GetFileCollection<Pesticide>(File.ReadAllText(Path.Combine(fulldataPath, files[1])));
			AvailableFields = GetFileCollection<Field>(File.ReadAllText(Path.Combine(fulldataPath, files[2])));
			Raports = GetFileCollection<Raport>(File.ReadAllText(Path.Combine(fulldataPath, files[3])));
		}

		public static void Save() {
			string fulldataPath = GetFullPath();

			SaveCollectionToFile(AvailablePlants, Path.Combine(fulldataPath, files[0]));
			SaveCollectionToFile(AvailablePesticides, Path.Combine(fulldataPath, files[1]));
			SaveCollectionToFile(AvailableFields, Path.Combine(fulldataPath, files[2]));
			SaveCollectionToFile(Raports, Path.Combine(fulldataPath, files[3]));
		}

		private static string GetFullPath() {
			string appdataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			string fulldataPath = $"{appdataPath}\\.PlantX\\data";

			return fulldataPath;
		}

		private static void SaveCollectionToFile<T>(ObservableCollection<T> objectToSave, string filePath) {
			var content = JsonConvert.SerializeObject(objectToSave);

			File.WriteAllText(filePath, content);
		}

		private static ObservableCollection<T> GetFileCollection<T>(string fileContent) {
			var collection = JsonConvert.DeserializeObject<ObservableCollection<T>>(fileContent);

			if (collection is null) {
				return new ObservableCollection<T>();
			}

			return collection;
		}
	}
}
