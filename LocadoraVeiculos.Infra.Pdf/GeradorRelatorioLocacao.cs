using iTextSharp.text;
using iTextSharp.text.pdf;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using iTextSharp;
using System.Drawing;

namespace LocadoraVeiculos.Infra.Pdf
{
    public class GeradorRelatorioLocacao : IGeradorRelatorioLocacao
    {
        public void GerarRelatorioPdf(Locacao locacao, string caminhoArquivo)
        {
            Document doc = new Document(PageSize.A4);
            doc.SetMargins(40, 40, 40, 80);
            doc.AddCreationDate();

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminhoArquivo, FileMode.Create));

            doc.Open();

            Paragraph paragrafo = new Paragraph("", new Font(Font.NORMAL, 14));
            paragrafo.Alignment = Element.ALIGN_JUSTIFIED;

            string texto = "O PDF (Portable Document Format) é um formato de ";

            paragrafo.Add(texto);
            doc.Add(paragrafo);


            doc.Close();

        }
    }
}
