using iText.IO.Font;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.Win32;
using PlantX.Converters;
using PlantX.MVVM.Models.Raports;

namespace PlantX.PDF {
	public class PDFCreator {
		public void CreatePdfFromRaport(Raport raport) {
			SaveFileDialog saveFileDialog = new SaveFileDialog() {
				Filter = "Dokument (.PDF)|*.pdf"
			};

			if (saveFileDialog.ShowDialog() == true) {
				PdfWriter pdfWriter = new PdfWriter(saveFileDialog.FileName);
				PdfDocument pdfDocument = new PdfDocument(pdfWriter);

				PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA, PdfEncodings.CP1250);

				Document document = new Document(pdfDocument).SetFont(font).SetFontSize(16);

				ImageData imageData = ImageDataFactory.Create("./PDF/Logo.png");
				Image image = new Image(imageData).SetHorizontalAlignment(HorizontalAlignment.RIGHT).SetWidth(64).SetHeight(64);
				document.Add(image);

				document.Add(new Paragraph($"{raport.Title} - {raport.CreationDate.ToString("dd.MM.yyyy")}")
					.SetBold()
					.SetTextAlignment(TextAlignment.CENTER));
				document.Add(new Paragraph("Obszar polny: ")
					.Add(
						new Paragraph($"{raport.Field.Name}")
						.SetBold()));
				document.Add(new Paragraph("Roślina: ")
					.Add(
						new Paragraph($"{raport.Plant.Name}")
						.SetBold()));
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
