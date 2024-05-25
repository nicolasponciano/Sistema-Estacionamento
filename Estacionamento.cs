using System;

namespace Estacionamento
{
    public class EstacionamentoClasse
    {
       
        public string Ficha { get; set; } = "ficha";
        public string Placa { get; set; } = "placa";
        public string TipoVeiculo { get; set; } = "tipoVeiculo";

      
        public string CNH { get; set; } = string.Empty;
        public string NomeCliente { get; set; } = "nomeCliente";

       
        public string PrecoInicial { get; set; } = "valorInicial";
        public string PrecoPorHora { get; set; } = "";
        public string PrecoFinal { get; set; } = string.Empty;

       


        public EstacionamentoClasse()
        {

        }


        public void setFicha(string ficha)
        {
            this.Ficha = ficha;
        }
        public string getFicha()
        {
            return this.Ficha;
        }

        public void setPlaca(string placa)
        {
            this.Placa = placa;
        }
        public string getPlaca()
        {
            return this.Placa;
        }

        public void setTipoVeiculo(string tipoVeiculo)
        {
            this.TipoVeiculo = tipoVeiculo;
        }
        public string getTipoVeiculo()
        {
            return this.TipoVeiculo;
        }

        public void setCNH(string cnh)
        {
            this.CNH = cnh;
        }
        public string getCNH()
        {
            return this.CNH ?? string.Empty;
        }

        public void setNomeCliente(string nomeCliente)
        {
            this.NomeCliente = nomeCliente;
        }
        public string getNomeCliente()
        {
            return this.NomeCliente;
        }

        public void setPrecoInicial(string precoInicial)
        {
            this.PrecoInicial = precoInicial;
        }
        public string getPrecoInicial()
        {
            return this.PrecoInicial;
        }

        public void setPrecoPorHora(string precoPorHora)
        {
            this.PrecoPorHora = precoPorHora ?? string.Empty;
        }
        public string getPrecoPorHora()
        {
            return this.PrecoPorHora;
        }

        public void setPrecoFinal(string precoFinal)
        {
            this.PrecoFinal = precoFinal ?? string.Empty; 
        }
        public string getPrecoFinal()
        {
            return this.PrecoFinal;
        }

        public string getTotal()
        {
            try
            {
                float.Parse(CNH).ToString();
                return (float.Parse(PrecoInicial) * float.Parse(PrecoPorHora)).ToString();
            }
            catch (FormatException)
            {
                return "Erro de calculo";
            }
        }
    }
}
