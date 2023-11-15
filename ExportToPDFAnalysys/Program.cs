// See https://aka.ms/new-console-template for more information
using ExportToPDFAnalysys;
using PdfSharpCore.Drawing;
using PdfSharpCore.Fonts;
using PdfSharpCore.Pdf;
using PdfSharpCore.Utils;

Console.WriteLine("Hello, World!");

//PdfDocument doc = PdfDocument.FromFile(@"C:\Users\rpatn\Desktop\Loan application\QH Application Form.pdf");


//var form = doc.Form;


GlobalFontSettings.FontResolver = new FontResolver();

var document = new PdfDocument();
var page = document.AddPage();

var gfx = XGraphics.FromPdfPage(page);
var font = new XFont("Arial", 20, XFontStyle.Bold);

var textColor = XBrushes.Black;
var layout = new XRect(20, 20, page.Width, page.Height);
var format = XStringFormats.TopLeft;

//gfx.DrawString("Hello World!", font, textColor, layout, format);

PDFHelper.DrawTable(gfx, page);

document.Save("helloworld.pdf");