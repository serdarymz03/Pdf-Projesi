using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konsol
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Pdf_Okuma
            /*PdfDocument pdfDocument = PdfDocument.Open(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Örnek Dosyalar\\Pdf Dosyaları\\sample.pdf");

            foreach (Page page in pdfDocument.GetPages())
            {
                //string allText = page.Text;

                foreach (Word item in page.GetWords())
                {
                    Console.WriteLine(item);
                }

            }*/
            #endregion

            #region Pdf_Yazma
            /*
            PdfDocument pdfDocument = new PdfDocument();

            PdfPage pdfPage = pdfDocument.AddPage();

            XGraphics graphics = XGraphics.FromPdfPage(pdfPage);

            XFont font = new XFont("Calibri", 13);

            graphics.DrawString("İlk Pdf Dosyamızdan Merhaba", font, XBrushes.Blue, new XRect(20, 20, 1, 1), XStringFormats.TopLeft);
            graphics.DrawString("2. Satır Metin Örneği", font, XBrushes.Blue, new XRect(200, 40, 1, 1), XStringFormats.TopLeft);
            graphics.DrawString("Pdf Dosyası Olarak Örnek Metnimizi Yazıyoruz", font, XBrushes.Blue, new XRect(10, 60, 1, 1), XStringFormats.TopLeft);
            graphics.DrawString("Teşekkürler. C# İle Pdf Dosyamızın Son Satırına Geldik", font, XBrushes.Blue, new XRect(10, 75, 1, 1), XStringFormats.TopLeft);

            pdfDocument.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\test.pdf");
            */
            #endregion

            Console.WriteLine("İşlem Tamamlandı");
            Console.Read();
        }
    }
}
