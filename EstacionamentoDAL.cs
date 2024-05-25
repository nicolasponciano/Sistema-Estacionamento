using System;
using System.Data;
using System.Data.OleDb;

namespace Estacionamento
{
    class EstacionamentoDAL
    {
        private static String strConexao = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=estacionamento.mdb";
        private static OleDbConnection conn = new OleDbConnection(strConexao);
        private static OleDbCommand strSQL;
        private static OleDbDataReader result;

        public static void Conecta()
        {
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                Erro.setMsg("Problemas ao se conectar ao Banco de Dados");
            }
        }

        public static void Desconecta()
        {
            conn.Close();
        }

        public static void InserirUmVeiculo(EstacionamentoClasse umVeiculo)
        {
            // Verificar se a conexão já está aberta e fechar se necessário
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open(); // Abre a conexão

                using (OleDbTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Inserir dados na tabela veiculo
                        OleDbCommand updtVeiculo = new OleDbCommand("INSERT INTO veiculo (placa, tipoVeiculo, ficha) VALUES (@placa, @tipoVeiculo, @ficha)", conn, transaction);
                        updtVeiculo.Parameters.Add("@placa", OleDbType.VarChar).Value = umVeiculo.getPlaca();
                        updtVeiculo.Parameters.Add("@tipoVeiculo", OleDbType.VarChar).Value = umVeiculo.getTipoVeiculo();
                        updtVeiculo.Parameters.Add("@ficha", OleDbType.VarChar).Value = umVeiculo.getFicha();
                        updtVeiculo.ExecuteNonQuery();

                        // Inserir dados na tabela cliente
                        OleDbCommand updtCliente = new OleDbCommand("INSERT INTO cliente (cnh, nomeCliente, ficha) VALUES (@cnh, @nomeCliente, @ficha)", conn, transaction);
                        updtCliente.Parameters.Add("@cnh", OleDbType.VarChar).Value = umVeiculo.getCNH();
                        updtCliente.Parameters.Add("@nomeCliente", OleDbType.VarChar).Value = umVeiculo.getNomeCliente();
                        updtCliente.Parameters.Add("@ficha", OleDbType.VarChar).Value = umVeiculo.getFicha();
                        updtCliente.ExecuteNonQuery();

                        // Inserir dados na tabela valor
                        OleDbCommand updtValor = new OleDbCommand("INSERT INTO valor (valorInicial, horas, valorFinal, ficha) VALUES (@valorInicial, @horas, @valorFinal, @ficha)", conn, transaction);
                        updtValor.Parameters.Add("@valorInicial", OleDbType.VarChar).Value = umVeiculo.getPrecoInicial();
                        updtValor.Parameters.Add("@horas", OleDbType.VarChar).Value = umVeiculo.getPrecoPorHora();
                        updtValor.Parameters.Add("@valorFinal", OleDbType.VarChar).Value = umVeiculo.getTotal();
                        updtValor.Parameters.Add("@ficha", OleDbType.VarChar).Value = umVeiculo.getFicha();
                        updtValor.ExecuteNonQuery();

                        // Commit da transação
                        transaction.Commit();
                        Erro.setErro(false);
                    }
                    catch (Exception)
                    {
                        // Rollback da transação em caso de erro
                        transaction.Rollback();
                        Erro.setMsg("ficha já cadastrada!");
                        Erro.setErro(true);
                    }
                }
            }
            catch (Exception)
            {
                Erro.setMsg("Erro ao abrir a conexão: ");
                Erro.setErro(true);
            }
            finally
            {
                // Garantir que a conexão será fechada
                try
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
                catch (Exception)
                {
                    Erro.setMsg("Erro ao fechar a conexão: ");
                    Erro.setErro(true);
                }
            }
        }




        public static void AtualizaUmVeiculo(EstacionamentoClasse umVeiculo)
        {
            // Verifica se a conexão já está aberta e fechar se necessário
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open(); // Abre a conexão

                // Atualizar dados na tabela veiculo
                OleDbCommand updtVeiculo = new OleDbCommand("UPDATE veiculo SET tipoVeiculo = @tipoVeiculo, ficha = @ficha WHERE placa = @placa", conn);
                updtVeiculo.Parameters.Add("@tipoVeiculo", OleDbType.VarChar).Value = umVeiculo.getTipoVeiculo();
                updtVeiculo.Parameters.Add("@ficha", OleDbType.VarChar).Value = umVeiculo.getFicha();
                updtVeiculo.Parameters.Add("@placa", OleDbType.VarChar).Value = umVeiculo.getPlaca();
                updtVeiculo.ExecuteNonQuery();

                // Atualizar dados na tabela cliente
                OleDbCommand updtCliente = new OleDbCommand("UPDATE cliente SET nomeCliente = @nomeCliente, ficha = @ficha WHERE cnh = @cnh", conn);
                updtCliente.Parameters.Add("@nomeCliente", OleDbType.VarChar).Value = umVeiculo.getNomeCliente();
                updtCliente.Parameters.Add("@ficha", OleDbType.VarChar).Value = umVeiculo.getFicha();
                updtCliente.Parameters.Add("@cnh", OleDbType.VarChar).Value = umVeiculo.getCNH();
                updtCliente.ExecuteNonQuery();

                // Atualizar dados na tabela valor
                OleDbCommand updtValor = new OleDbCommand("UPDATE valor SET valorInicial = @valorInicial, horas = @horas, valorFinal = @valorFinal WHERE ficha = @ficha", conn);
                updtValor.Parameters.Add("@valorInicial", OleDbType.VarChar).Value = umVeiculo.getPrecoInicial();
                updtValor.Parameters.Add("@horas", OleDbType.VarChar).Value = umVeiculo.getPrecoPorHora();
                updtValor.Parameters.Add("@valorFinal", OleDbType.VarChar).Value = umVeiculo.getTotal();
                updtValor.Parameters.Add("@ficha", OleDbType.VarChar).Value = umVeiculo.getFicha();
                updtValor.ExecuteNonQuery();

                Erro.setErro(false);
            }
            catch (Exception)
            {
                Erro.setMsg("Erro ao atualizar dados: ");
                Erro.setErro(true);
            }
            finally
            {
                // Garante que a conexão será fechada
                try
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    Erro.setMsg("Erro ao fechar a conexão: ");
                    Erro.setErro(true);
                }
            }
        }



        public static void ConsultaUmVeiculo(EstacionamentoClasse umVeiculo)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string consulta = @"SELECT v.placa, v.tipoVeiculo, c.cnh, c.nomeCliente, val.valorInicial, val.horas, val.valorFinal
                            FROM ((veiculo v
                            INNER JOIN cliente c ON v.ficha = c.ficha)
                            INNER JOIN valor val ON v.ficha = val.ficha)
                            WHERE v.ficha = @ficha";

                using (OleDbCommand updt = new OleDbCommand(consulta, conn))
                {
                    updt.Parameters.Add("@ficha", OleDbType.VarChar).Value = umVeiculo.getFicha();
                    using (OleDbDataReader reader = updt.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            umVeiculo.setPlaca(reader.GetString(reader.GetOrdinal("placa")));
                            umVeiculo.setTipoVeiculo(reader.GetString(reader.GetOrdinal("tipoVeiculo")));
                            umVeiculo.setCNH(reader.GetString(reader.GetOrdinal("cnh")));
                            umVeiculo.setNomeCliente(reader.GetString(reader.GetOrdinal("nomeCliente")));
                            umVeiculo.setPrecoInicial(reader.GetString(reader.GetOrdinal("valorInicial")));
                            umVeiculo.setPrecoPorHora(reader.GetString(reader.GetOrdinal("horas")));
                            umVeiculo.setPrecoFinal(reader.GetString(reader.GetOrdinal("valorFinal")));
                        }
                        else
                        {
                            Erro.setMsg("Veículo não encontrado.");
                            return;
                        }
                    }
                }

                Erro.setErro(false);
            }
            catch (Exception)
            {
                Erro.setMsg("Erro ao consultar dados: ");
                Erro.setErro(true);
            }
            finally
            {
                try
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
                catch (Exception)
                {
                    Erro.setMsg("Erro ao fechar a conexão: ");
                    Erro.setErro(true);
                }
            }
        }


        public static void ExcluiUmVeiculo(EstacionamentoClasse umVeiculo)
        {
            // Verifica se a conexão já está aberta e fecha se necessário
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open(); // Abre a conexão

                // Deletar dados na tabela veiculo
                String auxVeiculo = "DELETE FROM veiculo WHERE ficha = @ficha";
                OleDbCommand cmdVeiculo = new OleDbCommand(auxVeiculo, conn);
                cmdVeiculo.Parameters.Add("@ficha", OleDbType.VarChar).Value = umVeiculo.getFicha();
                cmdVeiculo.ExecuteNonQuery();

                // Deletar dados na tabela cliente
                String auxCliente = "DELETE FROM cliente WHERE ficha = @ficha";
                OleDbCommand cmdCliente = new OleDbCommand(auxCliente, conn);
                cmdCliente.Parameters.Add("@ficha", OleDbType.VarChar).Value = umVeiculo.getFicha();
                cmdCliente.ExecuteNonQuery();

                // Deletar dados na tabela valor
                String auxValor = "DELETE FROM valor WHERE ficha = @ficha";
                OleDbCommand cmdValor = new OleDbCommand(auxValor, conn);
                cmdValor.Parameters.Add("@ficha", OleDbType.VarChar).Value = umVeiculo.getFicha();
                cmdValor.ExecuteNonQuery();

                Erro.setErro(false);
            }
            catch (Exception ex)
            {
                Erro.setMsg("Erro ao deletar dados: " + ex.Message);
                Erro.setErro(true);
            }
            finally
            {
                // Garante que a conexão será fechada
                try
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    Erro.setMsg("Erro ao fechar a conexão: " + ex.Message);
                    Erro.setErro(true);
                }
            }
        }

    }
}
