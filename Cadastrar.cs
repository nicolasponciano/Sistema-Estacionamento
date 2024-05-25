using System;
using System.Data.OleDb;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Estacionamento
{
    public partial class Cadastrar : Form
    {
        EstacionamentoClasse umVeiculo = new EstacionamentoClasse();

        public Cadastrar()
        {
            InitializeComponent();
        }

        private void Cadastrar_Load(object sender, EventArgs e)
        {
            EstacionamentoBLL.conecta();
            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
        }

        private void Cadastrar_FormClosing(object sender, FormClosingEventArgs e)
        {
            EstacionamentoBLL.desconecta();
        }

        private void btnCVeiculo_Click(object sender, EventArgs e)
        {
            
            umVeiculo.setPlaca(txtPlaca.Text);
            umVeiculo.setTipoVeiculo(txtTipoVeiculo.Text);
            umVeiculo.setCNH(txtCNH.Text);
            umVeiculo.setNomeCliente(txtCliente.Text);
            umVeiculo.setFicha(txtFicha.Text);

            umVeiculo.PrecoInicial = txtValorInicial.Text;
            umVeiculo.PrecoPorHora = txtHoras.Text;
            txtValorFinal.Text = umVeiculo.getTotal();

            EstacionamentoBLL.validaDadosVeiculo(umVeiculo, 'i');

            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            else
                MessageBox.Show("Dados inseridos com sucesso!");
        }

        private void btnLimparCad_Click(object sender, EventArgs e)
        {
            txtCliente.Text = "";
            txtCNH.Text = "";
            txtPlaca.Text = "";
            txtTipoVeiculo.Text = "";
            txtFicha.Text = "";
            txtHoras.Text = "";
            txtValorFinal.Text = "";
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            umVeiculo.setPlaca(txtPlaca.Text);
            umVeiculo.setTipoVeiculo(txtTipoVeiculo.Text);
            umVeiculo.setCNH(txtCNH.Text);
            umVeiculo.setNomeCliente(txtCliente.Text);
            umVeiculo.setFicha(txtFicha.Text);

            umVeiculo.PrecoInicial = txtValorInicial.Text;
            umVeiculo.PrecoPorHora = txtHoras.Text;
            txtValorFinal.Text = umVeiculo.getTotal();

            EstacionamentoBLL.validaDadosVeiculo(umVeiculo, 'u');  // Usar 'u' para update

            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            else
                MessageBox.Show("Dados do veiculo alterados com sucesso!");
        }

        private void btnLer_Click(object sender, EventArgs e)
        {
            umVeiculo.setFicha(txtFicha.Text);

            EstacionamentoBLL.ValidaFicha(umVeiculo, 'c');

            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            else
            {
                txtPlaca.Text = umVeiculo.getPlaca();
                txtTipoVeiculo.Text = umVeiculo.getTipoVeiculo();
                txtCliente.Text = umVeiculo.getNomeCliente();
                txtCNH.Text = umVeiculo.getCNH();
                txtFicha.Text = umVeiculo.getFicha();
                txtValorInicial.Text = umVeiculo.getPrecoInicial();
                txtHoras.Text = umVeiculo.getPrecoPorHora();
                txtValorFinal.Text = umVeiculo.getPrecoFinal();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

            umVeiculo.setFicha(txtFicha.Text);

            EstacionamentoBLL.ValidaFicha(umVeiculo, 'e');

            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            else
                MessageBox.Show("conta Excluída!");
        }
    }
}
