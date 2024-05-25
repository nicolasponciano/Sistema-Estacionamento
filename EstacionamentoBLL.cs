using System;

namespace Estacionamento
{
    class EstacionamentoBLL
    {
        public static void conecta()
        {
            EstacionamentoDAL.Conecta();
        }

        public static void desconecta()
        {
            EstacionamentoDAL.Desconecta();
        }

        public static void ValidaFicha(EstacionamentoClasse umVeiculo, char op)
        {
            Erro.setErro(false);
            if (string.IsNullOrEmpty(umVeiculo.getFicha()))
            {
                Erro.setMsg("A Ficha é de preenchimento obrigatório!");
                return;
            }
            if (int.Parse(umVeiculo.getFicha()) <= 0)
            {
                Erro.setMsg("O valor da ficha deve ser numérico e positivo!");
                return;
            }
            if (op == 'c')
                EstacionamentoDAL.ConsultaUmVeiculo(umVeiculo);
            else
                EstacionamentoDAL.ExcluiUmVeiculo(umVeiculo);
        }


        public static void validaDadosVeiculo(EstacionamentoClasse umVeiculo, char op)
        {
            Erro.setErro(false);
            if (string.IsNullOrEmpty(umVeiculo.getPlaca()))
            {
                Erro.setMsg("A Placa é de preenchimento obrigatório!");
                return;
            }
            if (umVeiculo.getPlaca().Length != 7)
            {
                Erro.setMsg("A Placa deve conter 7 caracteres!");
                return;
            }
            if (string.IsNullOrEmpty(umVeiculo.getTipoVeiculo()))
            {
                Erro.setMsg("O Tipo de Veículo é de preenchimento obrigatório!");
                return;
            }
            if (string.IsNullOrEmpty(umVeiculo.getCNH()))
            {
                Erro.setMsg("A CNH é de preenchimento obrigatório!");
                return;
            }
            if (umVeiculo.getCNH().Length != 11)
            {
                Erro.setMsg("A CNH deve conter 11 dígitos!");
                return;
            }

            if (float.Parse(umVeiculo.getCNH()) <= 0)
            {
                Erro.setMsg("O valor da CNH deve ser numérico e positivo!");
                return;
            }
            if (string.IsNullOrEmpty(umVeiculo.getNomeCliente()))
            {
                Erro.setMsg("O Nome do Cliente é de preenchimento obrigatório!");
                return;
            }
            if (string.IsNullOrEmpty(umVeiculo.getFicha()))
            {
                Erro.setMsg("A ficha é de preenchimento obrigatório!");
                return;
            }
            if (umVeiculo.getFicha().Length > 3)
            {
                Erro.setMsg("A ficha não deve conter mais que 3 dígitos!");
                return;
            }
            if (string.IsNullOrEmpty(umVeiculo.getPrecoInicial()))
            {
                Erro.setMsg("O valor inicial é de preenchimento obrigatório!");
                return;
            }
            
            if (int.Parse(umVeiculo.getFicha()) <= 0)
            {
                Erro.setMsg("O valor da ficha deve ser numérico e positivo!");
                return;
            }
            if (int.Parse(umVeiculo.getPrecoInicial()) <= 0)
            {
                Erro.setMsg("O valor inicial deve ser numérico e positivo!");
                return;
            }
            if (int.Parse(umVeiculo.getPrecoPorHora()) <= 0)
            {
                Erro.setMsg("O valor por hora deve ser numérico e positivo!");
                return;
            }
            if (int.Parse(umVeiculo.getTotal()) <= 0)
            {
                Erro.setMsg("O valor final deve ser numérico e positivo!");
                return;
            }

            if (op == 'i')
                EstacionamentoDAL.InserirUmVeiculo(umVeiculo);
            else
                EstacionamentoDAL.AtualizaUmVeiculo(umVeiculo);
        }
    }
}
