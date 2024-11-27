using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using PdfSharp;
using PdfSharp.Pdf;
using System.Reflection.Metadata;
using PdfSharp.Drawing;
using PdfSharp.Pdf.AcroForms;
using PdfSharp.Fonts;
using System.Reflection;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf.Structure;

using MigraDoc;
using MigraDoc.DocumentObjectModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MigraDoc.DocumentObjectModel.Visitors;
using System.Security.Cryptography.X509Certificates;
using MigraDoc.Rendering;
using static PdfSharp.Snippets.Drawing.ImageHelper;
using System.Text;

namespace GPO_BLAZOR.DBAgents
{

   /* public class FileFontResolver : IFontResolver // FontResolverBase
    {
        public string DefaultFontName => throw new NotImplementedException();

        public byte[] GetFont(string faceName)
        {
            using (var ms = new MemoryStream())
            {
                using (var fs = File.Open(faceName, FileMode.Open))
                {
                    fs.CopyTo(ms);
                    ms.Position = 0;
                    return ms.ToArray();
                }
            }
        }

        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            if (familyName.Equals("Times", StringComparison.CurrentCultureIgnoreCase))
            {
                if (isBold && isItalic)
                {
                    return new FontResolverInfo("Fonts/timesbi.ttf");
                }
                else if (isBold)
                {
                    return new FontResolverInfo("Fonts/timesbd.ttf");
                }
                else if (isItalic)
                {
                    return new FontResolverInfo("Fonts/timesi.ttf");
                }
                else
                {
                    return new FontResolverInfo("Fonts/times.ttf");
                }
            }
            if (familyName.Equals("Arial", StringComparison.CurrentCultureIgnoreCase))
            {
                if (isBold && isItalic)
                {
                    return new FontResolverInfo("Fonts/timesbi.ttf");
                }
                else if (isBold)
                {
                    return new FontResolverInfo("Fonts/timesbd.ttf");
                }
                else if (isItalic)
                {
                    return new FontResolverInfo("Fonts/timesi.ttf");
                }
                else
                {
                    return new FontResolverInfo("Fonts/times.ttf");
                }
            }
            return null;
        }
    }


    /// <summary>
    /// Helper class that reads font data from embedded resources.
    /// </summary>
    public static class FontHelper
    {
        public static byte[] Arial
        {
            get { return LoadFontData("GPO_BLAZOR.fonts.arial.arial.ttf"); }
        }

        public static byte[] ArialBold
        {
            get { return LoadFontData("GPO_BLAZOR.fonts.arial.arialbd.ttf"); }
        }

        public static byte[] ArialItalic
        {
            get { return LoadFontData("GPO_BLAZOR.fonts.arial.ariali.ttf"); }
        }

        public static byte[] ArialBoldItalic
        {
            get { return LoadFontData("GPO_BLAZOR.fonts.arial.arialbi.ttf"); }
        }

        /// <summary>
        /// Returns the specified font from an embedded resource.
        /// </summary>
        static byte[] LoadFontData(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();

            // Test code to find the names of embedded fonts
            //var ourResources = assembly.GetManifestResourceNames();

            using (Stream stream = assembly.GetManifestResourceStream(name))
            {
                if (stream == null)
                    throw new ArgumentException("No resource with name " + name);

                int count = (int)stream.Length;
                byte[] data = new byte[count];
                stream.Read(data, 0, count);
                return data;
            }
        }
    }

    public class DBConnector
    {


        private (int right, int left, int up, int low) margin = (10, 10, 10, 10);

        static public MemoryStream F (Stream g)
        {



            //Size = 297x210 877х620 
            Console.WriteLine("1");
            PdfDocument fdocument = new PdfDocument();

            

            Console.WriteLine("1");
            fdocument.Language = "ru";
            PdfPage page = fdocument.AddPage();

            page.Orientation = PageOrientation.Portrait;



            //fdocument.Save(g);

            GlobalFontSettings.FontResolver = new FileFontResolver();

            Console.WriteLine("1");
            XGraphics gfx = XGraphics.FromPdfPage(page);

            Console.WriteLine("1");
            XFont h = new XFont("Times", 14, XFontStyleEx.Regular);

            XTextFormatter tf = new XTextFormatter(gfx);

            tf.Text = "text";



            

            tf.Alignment = XParagraphAlignment.Right;

            //XSize g = new XSize(10, 10);

            XStringFormat format = new XStringFormat();
            format.LineAlignment = XLineAlignment.Near;
            format.Alignment = XStringAlignment.Near;

            PdfTableAttributes table = new PdfTableAttributes();    

            

            Console.WriteLine("1");
            /*gfx.DrawString(("2Аstringhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh" +
                "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh" +
                "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh" +
                "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh" +
                "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh" +
                "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh" +
                "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh" +
                "hhhhhhh".ToUpper()), h, XBrushes.Black, XPoint.Subtract((new XPoint(20, 850)), (new XVector(2, 3))));*//*

            int size = 6;

            tf.DrawString("Заведующему кафедры КИБЭВС\n" +
                "Шелупанову Александру Александровичу\n" +
                "от студента группы 731-1\n" +
                $"Татаринова Максима Денисовича\t", h, XBrushes.Black, (new XRect(0, 60, page.Width-45, 200)), format);

            tf.Alignment = XParagraphAlignment.Center;

            h = new XFont("Times", 14, XFontStyleEx.Bold);

            tf.DrawString("Заявление  ", h, XBrushes.Black, (new XRect(60, 60+(14*size), page.Width - 45, 200)), format);

            h = new XFont("Times", 14, XFontStyleEx.Regular);

            tf.Alignment = XParagraphAlignment.Justify;

            tf.DrawString("    Прошу направить меня на прохождение производственной практики: экспулуатационной практики в профильную организацию " +
                "Федеральное государственное автономное образовательное учреждение высшего образования «Томский государственный университет систем управления и радиоэлектроники» " +
                "(адресс: 634050, г. Томск, пр. Ленина, 40)  с 10.06.2024г. по 22.06.2024г.", h, XBrushes.Black, (new XRect(60, 60 + (14 * (size+2)), page.Width - 45-60, 200)), format);

            tf.Alignment = XParagraphAlignment.Left;

            tf.DrawString("Дата: 14.05.2024 ", h, XBrushes.Black, (new XRect(60+20, 60 + (14 * (size+9)), page.Width - 45 - 60, 200)), format);

            tf.Alignment = XParagraphAlignment.Right;

            tf.DrawString("Подпись _________________", h, XBrushes.Black, (new XRect(60 + 20, 60 + (14 * (size + 9)), page.Width - 45 - 60-20, 200)), format);

            tf.Alignment = XParagraphAlignment.Left;

            tf.DrawString("Согласовано:", h, XBrushes.Black, (new XRect(60, 60 + (14 * (size + 16)), page.Width - 45 - 60, 200)), format);

            tf.DrawString("Зав.Кафедрой КИБЭВС:", h, XBrushes.Black, (new XRect(60, 60 + (14 * (size + 17)), page.Width - 45 - 60, 200)), format);

            tf.DrawString("Руководитель практики от университета:", h, XBrushes.Black, (new XRect(60, 60 + (14 * (size + 19)), 180, 200)), format);

            tf.Alignment = XParagraphAlignment.Right;

            tf.DrawString("_________________ Шелупанов А.А.", h, XBrushes.Black, (new XRect(60, 60 + (14 * (size + 17)), page.Width - 45 - 60, 200)), format);

            tf.DrawString("_________________ Новохрестов А.К.", h, XBrushes.Black, (new XRect(60, 60 + (14 * (size + 19)), page.Width - 45 - 60, 200)), format);

            //gfx.DrawPolygon((new XPen(XColor.FromArgb(122, 122, 122, 122))), XBrushes.Black, (new XPoint[] {  new XPoint(0, 0), new XPoint(page.Width, page.Height)}), XFillMode.Winding);

            //gfx.DrawPolygon((new XPen(XColor.FromArgb(122, 122, 122, 122))), XBrushes.Black, (new XPoint[] { new XPoint(0, 0), new XPoint(0, page.Height), new XPoint(page.Width, page.Height), new XPoint(page.Width, 0), }), XFillMode.Winding);

            //for (int i = 0; i<100; i++)
            //    gfx.DrawString(i.ToString(), h, XBrushes.Black, new XPoint(20, 20*i-20));





            MigraDoc.DocumentObjectModel.Document document = new MigraDoc.DocumentObjectModel.Document();
            Section section = document.AddSection();
            Section section2 = document.AddSection();


            section.PageSetup.PageFormat = PageFormat.A4;//стандартный размер страницы
            section.PageSetup.Orientation = Orientation.Portrait;//ориентация
            section.PageSetup.BottomMargin = 60;//нижний отступ
            section.PageSetup.TopMargin = 60;//верхний отступ

            section.PageSetup.LeftMargin = 60;
            section.PageSetup.RightMargin = 45;

            Paragraph paragraph = section.AddParagraph();
            Paragraph paragraph2 = section.AddParagraph();

            Paragraph paragraph3 = section2.AddParagraph();

            paragraph.Format.Font.ApplyFont( new Font("Times"));

            Text text = new Text("text");
            paragraph.AddText("text");//текст
            paragraph.AddFormattedText("formatted text1", (new Font("Times")));// форматированный текст
            paragraph2.AddFormattedText("formatted text2", (new Font("Times")));
            paragraph3.AddFormattedText("formatted text3", (new Font("Times")));
            paragraph.Add(text);//добавление любого из перечисленых ниже
            paragraph.AddBookmark("Bookmark");//закладка
            paragraph.AddChar('c');//символ
            paragraph.AddDateField("10.10.2010");//дата
            paragraph.AddFootnote("Footnote");//нижняя подпись
                                              //и еще много чего

            var tables = section.AddTable();

            tables.Borders.Visible = true;

            tables.Borders.Top.Visible = true;

            var collumnsd = tables.AddColumn().Width;

            collumnsd.Centimeter = 7;

            tables.AddColumn();
            tables.AddColumn();
            tables.AddColumn();
            string acc = "";
            for (int i = 0; i < 100; i++)
            {
                var row = tables.AddRow();

                var cells = row.Cells;

                var ty = cells[0];

                acc += i+" ";

                var p2 = ty.AddParagraph();

                p2.AddText("dfddddddddd "+i+" "+ acc);

                cells[1].AddParagraph().AddText("2222222222222 "+i + " " + acc);

                cells[2].AddParagraph().AddText("333333333333333 "+i + " " + acc);
            }



            var pdfRenderer = new PdfDocumentRenderer(true);
            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();
            pdfRenderer.PdfDocument.Save("PDFFile2.pdf");


            Console.WriteLine("1");
            //fdocument.AddPage(page);

            //Console.WriteLine("1");
            using (MemoryStream jk = new MemoryStream())
            {
                //fdocument.AddPage(page);
                Console.WriteLine("2");
                fdocument.Save("PDFFile1.pdf");
                Console.WriteLine("2");
                fdocument.Save(jk);
                fdocument.Close();
                return jk;
            }

            //gfx.DrawString("Line", h, );
           
        }



    }
            */


}
