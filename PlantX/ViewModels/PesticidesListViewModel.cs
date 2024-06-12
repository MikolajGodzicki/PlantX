using PlantX.Models.Pesticides;
using PlantX.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace PlantX.ViewModels {
    internal class PesticidesListViewModel : ViewModelBase {
        private ObservableCollection<Pesticide> pesticides { get; set; }

        public PesticidesListViewModel() {
            pesticides = new ObservableCollection<Pesticide>() {
                new Pesticide() { Name = "Signum", Power = new PesticidePower() {
                    Ares = 10,
                    Weight = 1f,
                    WeightType = WeightType.Liter
                  }
                },
                new Pesticide() { Name = "Karate", Power = new PesticidePower() {
                    Ares = 20,
                    Weight = 21f,
                    WeightType = WeightType.Kilogram
                  }
                }
            };
        }

        public ObservableCollection<Pesticide> Pesticides {
            get => pesticides;
            set {
                if (pesticides != value) {
                    pesticides = value;
                    OnPropertyChanged(nameof(Pesticides));
                }
            }
        }

        public ICommand AddPesticideCommand => new RelayCommand(AddPesticide);

        private void AddPesticide() {
        }
    }
}
