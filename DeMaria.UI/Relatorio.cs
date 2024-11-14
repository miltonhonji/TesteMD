using DeMaria.BLL;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeMaria.UI
{
    public partial class frmRelatorio : Form
    {
        private int idCliente;
        private int idProduto;

        public frmRelatorio()
        {
            //InitializeComponent();
        }

        public frmRelatorio(int idCliente)
        {
            InitializeComponent();
            //IdCliente
            CriarRelatorioCliente(idCliente);
        }

        private void CriarRelatorioCliente(int idCliente)
        {
            try
            {
                //Define um dos caminhos
                RelatorioRepository relatorioRepository = new RelatorioRepository();
                //Define um dos caminhos
                this.rpvRelatorio.LocalReport.ReportPath = @"C:\Reports\RelatorioCliente.rdlc";
                //DataSet
                DataSet dsCliente = relatorioRepository.GerarRelatorioDoCliente(idCliente);
                //DataSource para o Dataset
                if (dsCliente.Tables.Contains("Cliente"))
                {
                    //Acrescentando uma dataTable
                    DataTable dtCliente = dsCliente.Tables["Cliente"];
                    //Cria o ReportDataSource.
                    ReportDataSource reportDataSource = new ReportDataSource("Cliente", dtCliente);
                    //Limpa o datasource
                    this.rpvRelatorio.LocalReport.DataSources.Clear();
                    //Adiciona o relatório
                    this.rpvRelatorio.LocalReport.DataSources.Add(reportDataSource);
                    // Atualiza o ReportViewer para exibir o relatório
                    this.rpvRelatorio.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message) ;
            }
        }

        private void CriarRelatorioProduto(int idProduto)
        {
            try
            {
                //Define um dos caminhos
                RelatorioRepository relatorioRepository = new RelatorioRepository();
                //Define um dos caminhos
                this.rpvRelatorio.LocalReport.ReportPath = @"C:\Reports\RelatorioProduto.rdlc";
                //DataSet
                DataSet dsProduto = relatorioRepository.GerarRelatorioDoProduto(idProduto);
                //DataSource para o Dataset
                if (dsProduto.Tables.Contains("Produto"))
                {
                    //Acrescentando uma dataTable
                    DataTable dtProduto = dsProduto.Tables["Produto"];
                    //Cria o ReportDataSource.
                    ReportDataSource reportDataSource = new ReportDataSource("Produto", dtProduto);
                    //Limpa o datasource
                    this.rpvRelatorio.LocalReport.DataSources.Clear();
                    //Adiciona o relatório
                    this.rpvRelatorio.LocalReport.DataSources.Add(reportDataSource);
                    // Atualiza o ReportViewer para exibir o relatório
                    this.rpvRelatorio.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
