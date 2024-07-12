using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.Win32;
using PlantX.Converters;
using PlantX.MVVM.Models.Pesticides;
using PlantX.MVVM.Models.Raports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace PlantX.PDF {
	public class PDFCreator {
        public void CreatePdfFromRaport(Raport raport) {
            SaveFileDialog saveFileDialog = new SaveFileDialog() {
                Filter = "Dokument (.PDF)|*.pdf"
            };

            if (saveFileDialog.ShowDialog() == true) {
                PdfWriter pdfWriter = new PdfWriter(saveFileDialog.FileName);
                PdfDocument pdfDocument = new PdfDocument(pdfWriter); 
                Document document = new Document(pdfDocument);

                document.Add(new Paragraph($"{raport.Title} - {raport.CreationDate.ToString("dd.MM.yyyy")}").SetBold());
                document.Add(new Paragraph($"Obszar polny: {raport.Field.Name}"));
				document.Add(new Paragraph($"Roślina: {raport.Plant.Name}"));
				document.Add(new Paragraph($"Pestycydy"));

                Table table = new Table(UnitValue.CreatePercentArray(2)).UseAllAvailableWidth();

                foreach (var relation in raport.Pesticides) {
                    table.AddCell(relation.Pesticide.Name);
					table.AddCell(WeightConverter.GetConvertedWeight(relation.Pesticide, relation.CalculatedWeight));
                }

				document.Add(table);

				document.Close();
			}
		}
    }
}
