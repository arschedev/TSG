using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace backend.Classes;

public static class Pdf
{
    public static void Generate(StudentForm form, string dest)
    {
        var writer = new PdfWriter(dest);
        var pdf = new PdfDocument(writer);
        var document = new Document(pdf);

        document.Add(new Paragraph("Fisa Studentului\n\n").SetFontSize(20).SimulateBold()
            .SetTextAlignment(TextAlignment.CENTER));

        document.Add(new Paragraph($"Nume: {form.Nume}"));
        document.Add(new Paragraph($"Prenume: {form.Prenume}"));
        document.Add(new Paragraph($"Facultate: {form.Facultate}"));
        document.Add(new Paragraph($"Motivatie participare: {form.Motivatie}\n\n"));

        document.Add(new Paragraph($"{DateTime.Now}"));
        document.Add(new Paragraph("Semnat electronic").SimulateItalic());

        document.Close();
    }
}