﻿using JustASecond.DAL.Data.Models;
using JustASecond.DAL.Interfaces;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;

namespace JustASecond.DAL.Repos
{
    public class InvoiceRepo : IInvoiceRepo
    {
        /// <summary>
        /// Erstellt eine Rechnung im PDF Format auf Basis einer Bestellung
        /// </summary>
        /// <param name="order"></param>
        /// <param name="invoinceNumber"></param>
        /// <returns></returns>
        public void CreateInvoicePDF(Order order, int invoinceNumber)
        {
            var document = new PdfDocument();
            var page = document.AddPage();
            var gfx = XGraphics.FromPdfPage(page);
            var font = new XFont("OpenSans", 20, XFontStyle.Bold);

            gfx.DrawString("Hello Philipp!",
                           font,
                           XBrushes.Black,
                           new XRect(20, 20, page.Width, page.Height),
                           XStringFormats.Center);

            document.Save(@"C:\Users\2108\Collini Dienstleistungs GmbH\Lerchenmüller Niklas - Shared\School Archive\THeel\INF\4. Class\test.pdf");

            // Rechnungsnummer nicht Identity, UST ka 10%, Firma, Datum, Ausgestellt am, etc
        }
    }
}
