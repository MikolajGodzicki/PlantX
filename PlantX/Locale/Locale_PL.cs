using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantX.Locale
{
    public class Locale_PL
    {
        public const string Pesticide_NameRequired = "Podaj nazwę pestycydu.";
		public const string Pesticide_Exists = "Pestycyd o takiej nazwie już istnieje.";
		public const string Pesticide_NotExists = "Pestycyd o takiej nazwie nie istnieje.";
		public const string Pesticide_WeightGreaterThanZero = "Moc musi być większa od 0.";
		public const string Pesticide_Created = "Utworzono pestycyd.";
		public const string Pesticide_Edited = "Zmieniono pestycyd.";

		public const string Field_NameRequired = "Podaj nazwę obszaru polnego.";
		public const string Field_Exists = "Obszar polny o tej nazwie już istnieje.";
		public const string Field_NotExists = "Obszar polny o tej nazwie nie istnieje.";
		public const string Field_AreaGreaterThanZero = "Powierzchnia musi być większa od 0.";
		public const string Field_Created = "Utworzono obszar polny.";
		public const string Field_Edited = "Zmieniono obszar polny.";

		public const string Plant_NameRequired = "Podaj nazwę rośliny.";
		public const string Plant_Exists = "Roślina o tej nazwie już istnieje.";
		public const string Plant_NotExists = "Roślina o tej nazwie nie istnieje.";
		public const string Plant_Created = "Utworzono roślinę.";
		public const string Plant_Edited = "Zmieniono roślinę.";

		public const string Raport_WrongIndex = "Wybrano złą pozycje.";
		public const string Raport_PesticideExists = "Nie możesz dodać tego samego pestycydu.";
		public const string Raport_WrongTitle = "Tytuł nie może być pusty.";
		public const string Raport_FieldNotSelected = "Nie wybrano obszaru polnego.";
		public const string Raport_PlantNotSelected = "Nie wybrano rośliny.";
		public const string Raport_PesticideBelowOne = "Musi być dodany co najmniej jeden pestycyd.";
		public const string Raport_Created = "Utworzono raport.";
		public const string Raport_NotExists = "Taki raport nie istnieje.";
		public const string Raport_Removed = "Usunięto raport.";
		public const string Raport_PesticideRemoved = "Usunięto pestycyd.";
		public const string Raport_PesticideAdded = "Dodano pestycyd.";
		public const string Raport_PesticideNotExists = "Taki pestycyd nie istnieje.";
		public const string Raport_PDFCreated = "Pomyślnie utworzono raport PDF.";
	}
}
