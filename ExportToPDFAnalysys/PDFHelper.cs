using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportToPDFAnalysys
{
    public class PDFHelper
    {
        public static void DrawTable(XGraphics graphics, PdfPage page)
        {
            double width = page.Width;
            double drawableWidth = width - 120;
            double eachrectwidth = drawableWidth / 5;
            var x = 60.0;
            var y = 30;
            var height = 15;
            var rectList = GetRectangles();

            for (int a = 0; a < 6; a++)
            {
                for (int i = 0; i < 5; i++)
                {
                    var rectwidth = eachrectwidth;

                    var bounds = new XRect(x, y, rectList[i].width, rectList[i].height);
                    graphics.DrawRectangle(XPens.Black, bounds);

                    if (!string.IsNullOrEmpty(rectList[i].text) && a == 0)
                    {
                        var textColor = XBrushes.Black;
                        var layout = new XRect(x + 5, y, page.Width, page.Height);
                        var format = XStringFormats.TopLeft;
                        var font = new XFont("Times new roman", 10, XFontStyle.Regular);

                        graphics.DrawString(rectList[i].text, font, textColor, layout, format);
                    }
                    x = x + rectList[i].width;
                }
                y = y + height;
                x = 60.00;
            }

            //var state = graphics.Save();
            //graphics.Restore(state);
            //graphics.DrawString(
            //    "Hello World!",
            //    new XFont("Arial", 20),
            //    XBrushes.Black,
            //    bounds.Center,
            //    XStringFormats.Center);

        }

        public static List<RectText> GetRectangles()
        {
            return new List<RectText> {
                new RectText
                {
                    height= 15.00,
                    width = 100.00,
                    text = "Online Ref No"
                },
                new RectText
                {
                    height= 15.00,
                    width = 100.00,
                    text = "App No"
                },
                new RectText
                {
                    height= 15.00,
                    width = 75.00,
                },
                new RectText
                {
                    height= 15.00,
                    width = 100.00,
                    text = "File No"
                },
                new RectText
                {
                    height= 15.00,
                    width = 100.00,
                    text = "ITS ID"
                }
            };
        }

        public class RectText
        {
            public double width;
            public double height;
            public string text;
        }
    }
}
