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
using iTextSharp.text.pdf.draw;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloTaxas;

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

            Paragraph titulo = DefinirTitulo(locacao);
            Paragraph veiculo = ConfigurarDadosCarro(locacao);
            Image imagemPdf = ConfigurarImagem(locacao);
            DottedLineSeparator seperator = new DottedLineSeparator();
            Paragraph espacoQuebraLinha = PegarQuebraDeLinha();
            Paragraph cliente = ConfiguracaoDadosCliente(locacao);
            Paragraph dadosLocacao = ConfiguracaoDadosLocacao(locacao);
            Paragraph camposDeAssinatura = ConfigurarCamposDeAssinatura();

            doc.Add(titulo);
            doc.Add(seperator);
            doc.Add(veiculo);
            doc.Add(imagemPdf);
            doc.Add(espacoQuebraLinha);
            doc.Add(seperator);
            doc.Add(cliente);
            doc.NewPage();
            doc.Add(dadosLocacao);
            doc.Add(camposDeAssinatura);
            doc.Close();

        }

        private Paragraph ConfigurarCamposDeAssinatura()
        {
            Paragraph campoAssinatura = new Paragraph("\n\n\n\n", new Font(Font.NORMAL, 20, 1));
            campoAssinatura.Alignment = 300;
            campoAssinatura.Font = new Font(Font.NORMAL, 14);
            campoAssinatura.Add("______________________       ______________________");
            campoAssinatura.Add("    Responsavel  Loja                  Cliente     ");
            campoAssinatura.Alignment = Element.ALIGN_CENTER;
            return campoAssinatura;
        }

        private Paragraph ConfiguracaoDadosLocacao(Locacao locacao)
        {
            Paragraph paragrafoDaLocacao = new Paragraph("\nDados Locação: \n", new Font(Font.NORMAL, 20, 1));
            paragrafoDaLocacao.Alignment = 300;
            paragrafoDaLocacao.Font = new Font(Font.NORMAL, 14);
            paragrafoDaLocacao.Add("        Veiculo: " + locacao.Veiculo);
            paragrafoDaLocacao.Add("\n        Plano Cobranca: " + locacao.PlanoCobranca);
            paragrafoDaLocacao.Add("\n        Grupo de Veiculos: " + locacao.GrupoVeiculos);
            paragrafoDaLocacao.Add("\n        Cliente :" + locacao.Cliente);
            paragrafoDaLocacao.Add("\n        Condutor: " + locacao.Condutores);


            paragrafoDaLocacao.Add("\n        NIvel combustivel Inicio: " + locacao.NivelTanqueEnumInicio.ToString());
            if (locacao.StatusDevolucao) paragrafoDaLocacao.Add("\n        NIvel combustivel Final: " + locacao.NivelTanqueEnumDevolucao.ToString());

            paragrafoDaLocacao.Add("\n        Quilometragem Inicial: " + locacao.QuilometragemInicial);
            if (locacao.StatusDevolucao) paragrafoDaLocacao.Add("\n        Quilometragem Final: " + locacao.QuilometragemFinal);

            paragrafoDaLocacao.Add("\n        Dia da locação: " + locacao.DataLocacao);
            paragrafoDaLocacao.Add("\n        Dia Estimado da devolução: " + locacao.DataEstimadaDevolucao);
            if (locacao.StatusDevolucao) paragrafoDaLocacao.Add("\n        Dia Real Devolução: " + locacao.DataRealDaDevolucao);

            if (locacao.StatusDevolucao)
            {
                AdicionarTextoBold("\n        Valor Final da Locação: ",paragrafoDaLocacao);
                paragrafoDaLocacao.Add( locacao.GerarValorLocacao().ToString());
            }
            else
            {
                AdicionarTextoBold("\n        Valor Estimado da Locação: ",paragrafoDaLocacao);
                paragrafoDaLocacao.Add(locacao.GerarValorLocacao().ToString());
            }

            string statusDaLocacao = (locacao.StatusDevolucao) ? "Devolução Quitada" : "Locação Pendente";
            AdicionarTextoBold("\n        Status da Locação: ", paragrafoDaLocacao);
            paragrafoDaLocacao.Add(statusDaLocacao);
            AdicionarTextoBold("\n        Lista De Taxas Cadastradas: ", paragrafoDaLocacao);
            foreach (Taxas tax in locacao.ListaTaxas)
            {
                paragrafoDaLocacao.Add("\n        " + tax.ToString());
            }

            paragrafoDaLocacao.Add(new Paragraph());
            return paragrafoDaLocacao;
        }

        private void AdicionarTextoBold(string v, Paragraph veiculo)
        {
            veiculo.Font = new Font(Font.NORMAL, 14, 1);
            veiculo.Add(v);
            veiculo.Font = new Font(Font.NORMAL, 14);
        }

        private Paragraph ConfiguracaoDadosCliente(Locacao locacao)
        {
            Cliente cli = locacao.Cliente;

            Paragraph veiculo = new Paragraph("\nCliente: \n", new Font(Font.NORMAL, 14, 1));
            veiculo.Alignment = 300;
            veiculo.Font = new Font(Font.NORMAL, 14);

            veiculo.Add("        Nome: " + cli.Nome);
            if (cli.TipoCliente == "PessoaJuridica") veiculo.Add("\n        CNPJ: " + cli.Cnpj);
            else veiculo.Add("\n        CPF: " + cli.Cpf);
            veiculo.Add("\n        Email: " + cli.Email);
            veiculo.Add("\n        Endereco: " + cli.Endereco);
            veiculo.Add("\n        Telefone: " + cli.Telefone);

            veiculo.Add(new Paragraph());
            return veiculo;
        }
        private Paragraph PegarQuebraDeLinha()
        {
            Paragraph veiculo = new Paragraph("\n", new Font(Font.NORMAL, 14));
            return veiculo;
        }
        private Paragraph ConfigurarDadosCarro(Locacao locacao)
        {
            Paragraph veiculo = new Paragraph("\nVeiculo: \n", new Font(Font.NORMAL, 14, 1));
            veiculo.Alignment = 300;
            veiculo.Font = new Font(Font.NORMAL, 14);
            veiculo.Add("        Marca: " + locacao.Veiculo.Marca);
            veiculo.Add("\n        Modelo: " + locacao.Veiculo.Modelo);
            veiculo.Add("\n        Quilometragem: " + locacao.Veiculo.Quilometragem);
            veiculo.Add("\n        Placa :" + locacao.Veiculo.Placa);
            veiculo.Add("\n        Ano: " + locacao.Veiculo.Ano);
            veiculo.Add("\n        Cor: " + locacao.Veiculo.Cor);
            veiculo.Add("\n        Tipo Combustivel: " + locacao.Veiculo.TipoCombustivel);
            veiculo.Add("\n        Capacidade Tanque: " + locacao.Veiculo.CapacidadeTanque.ToString());
            veiculo.Add(new Paragraph());
            return veiculo;
        }

        private static Image ConfigurarImagem(Locacao locacao)
        {
            Image imagemPdf = Image.GetInstance(locacao.Veiculo.Foto);
            imagemPdf.ScaleToFit(400f, 300f);
            imagemPdf.Alignment = Element.ALIGN_CENTER;
            return imagemPdf;
        }

        private Paragraph DefinirTitulo(Locacao locacao)
        {
            string titulo = "";
            if (locacao.StatusDevolucao) titulo = "Devolução de Locação\n";
            else titulo = "Locação de Veiculo\n";

            Paragraph paragrafo = new Paragraph(titulo + "\n", new Font(Font.NORMAL, 18, 1));
            paragrafo.Alignment = Element.ALIGN_CENTER;
            return paragrafo;
        }
    }
}
