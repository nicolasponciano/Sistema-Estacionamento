using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estacionamento
{
    public partial class Listar : Form
    {
        private static String strConexao = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=estacionamento.mdb";
        private OleDbConnection conn;

        public Listar()
        {
            InitializeComponent();
            conn = new OleDbConnection(strConexao);
        }

        private void Listar_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao se conectar ao banco de dados: ");
            }
        }

        private void Listar_FormClosing(object sender, FormClosingEventArgs e)
        {
            try   //verifica se a conexão está aberta
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao fechar a conexão: ");
            }
        }

        private void btnListaCadastro_Click(object sender, EventArgs e)
        {
            CriarDataGridViewDinamico();
        }

        private void CriarDataGridViewDinamico()
        {

            
            DataGridView dataGridView = new DataGridView
            {
                Location = new Point(100, 50),
                Size = new Size(750, 220),   
                AutoGenerateColumns = true
            };
            dataGridView.ReadOnly = false;


            // Obtém dados do banco de dados e preenche o DataGridView
            DataTable dataTable = new DataTable();
            try
            {
                string query = "SELECT v.ficha, v.placa, v.tipoVeiculo, c.cnh, c.nomeCliente, val.valorInicial, val.horas, val.valorFinal " +
                               "FROM ((veiculo v " +
                               "INNER JOIN cliente c ON v.ficha = c.ficha) " +
                               "INNER JOIN valor val ON v.ficha = val.ficha)";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                    adapter.Fill(dataTable);
                }
                dataGridView.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao obter dados: " + ex.Message);
            }

            // Adiciona o DataGridView ao formulário
            this.Controls.Add(dataGridView);
        }

        private void btnfechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
