using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationsWF.Model
{
    public class Position
    {
        private string par1;
        private string par2;
        private string exchange;
        private string ferramenta;
        private string tecnica;
        private ArrayList indicadores;
        private string tipoTrade;
        private string tipoPosicao;
        private string capital;
        private string entrada;
        private string alvo;
        private string stop;
        private string parcial;
        private string status;
        private string data_abertura;
        private string hora_abertura;
        private string data_fechamento;
        private string hora_fechamento;
        private ArrayList historico;
        private int idPosition;
        private string resultado;
        private double riscoPercent;
        private double ganhoPercent;
        private double parcialPercent;
        private string relacaoRiscoGanho;

        public double RiscoValor { get => calculaRiscoValor(); }
        public double GanhoPercent { get => ganhoPercent; set => ganhoPercent = value; }
        public double GanhoValor { get => calculaGanhoValor(); }
        public double ParcialPercent { get => parcialPercent; set => parcialPercent = value; }
        public double ParcialValor { get => calculaGanhoParcialValor(); }
        public string RelacaoRiscoGanho { get => relacaoRiscoGanho; set => relacaoRiscoGanho = value; }
        public string Alvo { get => alvo; set => AtualizarAlvo(value); }
        public string Stop { get => stop; set => AtualizarStop(value); }
        public string Parcial { get => parcial; set => AtualizarParcial(value); }
        public string Entrada { get => entrada; set => AtualizarEntrada(value); }
        public string Capital { get => capital; set => AtualizarCapital(value); }
        public string TipoPosicao { get => tipoPosicao; set => AtualizarTipoPosicao(value); }
        public string TipoTrade { get => tipoTrade; set => tipoTrade = value; }
        public string Ferramenta { get => ferramenta; set => ferramenta = value; }
        public string Exchange { get => exchange; set => exchange = value; }
        public string HoraAbertura { get => hora_abertura; set => hora_abertura = value; }
        public ArrayList Indicadores { get => indicadores; set => indicadores = value; }
        public string DataAbertura { get => data_abertura; set => data_abertura = value; }
        public string DataFechamento { get => data_fechamento; set => data_fechamento = value; }
        public string HoraFechamento { get => hora_fechamento; set => hora_fechamento = value; }
        public string Status { get => status; set => status = value; }
        public ArrayList Historico { get => historico; set => historico = value; }
        public string Resultado { get => resultado; set => resultado = value; }
        public string Tecnica { get => tecnica; set => tecnica = value; }
        public string Par1 { get => par1; set => par1 = value; }
        public string Par2 { get => par2; set => par2 = value; }
        public int IdPosition { get => idPosition; set => idPosition = value; }
        public TimeSpan Duracao { get => CalculaDuracao(); }

        private TimeSpan CalculaDuracao()
        {
            try
            {
                if (status == "Posição fechada")
                {
                    DateTime datetimeAbertura = DateTime.Parse(data_abertura + " " + hora_abertura);
                    DateTime datetimeFechamento = DateTime.Parse(data_fechamento + " " + hora_fechamento);
                    return datetimeFechamento - datetimeAbertura;
                }
                else
                {
                    DateTime datetimeAbertura = DateTime.Parse(data_abertura + " " + hora_abertura);
                    return DateTime.Now - datetimeAbertura;
                }
            }
            catch (Exception)
            {
                return new TimeSpan();
            }
        }

        private void AtualizarCapital(string value)
        {
            capital = value;
            calculaValores();
        }

        private void AtualizarTipoPosicao(string value)
        {
            tipoPosicao = value;
            calculaValores();
        }

        private void AtualizarStop(string value)
        {
            stop = value;
            calculaValores();
        }

        private void AtualizarParcial(string value)
        {
            parcial = value;
            calculaValores();
        }

        private void AtualizarEntrada(string value)
        {
            entrada = value;
            calculaValores();
        }

        private void AtualizarAlvo(string value)
        {
            alvo = value;
            calculaValores();
        }

        public double RiscoPercent { get => riscoPercent; set => riscoPercent = value; }

        public Position()
        {
        }

        public Position(int idPosition, string par1, string par2, string exchange, string ferramenta, string tecnica, ArrayList indicadores, string tipoTrade, string tipoPosicao, string capital, string entrada, string alvo, string stop, string parcial, string data_abertura, string hora_abertura, ArrayList historico)
        {
            this.idPosition = idPosition;
            this.par1 = par1;
            this.par2 = par2;
            this.exchange = exchange;
            this.ferramenta = ferramenta;
            this.tecnica = tecnica;
            this.indicadores = indicadores;
            this.tipoTrade = tipoTrade;
            this.tipoPosicao = tipoPosicao;
            this.capital = capital;
            this.entrada = entrada;
            this.alvo = alvo;
            this.stop = stop;
            this.parcial = parcial;
            this.data_abertura = data_abertura;
            this.hora_abertura = hora_abertura;
            this.historico = historico;

            this.status = "Posição Aberta";
            this.resultado = "Aguardando fechamento";
            this.RiscoPercent = calculaRiscoPercent();
            this.GanhoPercent = calculaGanhoPercent();
            this.ParcialPercent = calculaGanhoParcialPercent();
            this.RelacaoRiscoGanho = calculaRelacaoRiscoGanho();
        }

        internal void calculaValores()
        {
            try
            {
                this.RiscoPercent = calculaRiscoPercent();
                this.GanhoPercent = calculaGanhoPercent();
                this.ParcialPercent = calculaGanhoParcialPercent();
                this.RelacaoRiscoGanho = calculaRelacaoRiscoGanho();

            }
            catch (Exception)
            {
            }
        }

        private double calculaRiscoPercent()
        {
            try
            {
                if (tipoPosicao == "Short position")
                    return ((Convert.ToDouble(this.entrada) - Convert.ToDouble(this.stop)) * 100 / Convert.ToDouble(this.entrada));
                else
                    return ((Convert.ToDouble(this.stop) - Convert.ToDouble(this.entrada)) * 100 / Convert.ToDouble(this.entrada));
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private double calculaRiscoValor()
        {
            float capital = float.Parse(this.capital, CultureInfo.InvariantCulture.NumberFormat);
            return capital * this.RiscoPercent / 100;
        }

        private double calculaGanhoPercent()
        {
            try
            {
                if (tipoPosicao == "Short position")
                    return ((Convert.ToDouble(this.entrada) - Convert.ToDouble(this.alvo)) * 100 / Convert.ToDouble(this.entrada));
                else
                    return ((Convert.ToDouble(this.alvo) - Convert.ToDouble(this.entrada)) * 100 / Convert.ToDouble(this.entrada));
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private double calculaGanhoValor()
        {
            // Create a NumberFormatInfo object and set some of its properties.
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";
            return Convert.ToDouble(this.capital, provider) * this.GanhoPercent / 100;
        }

        private string calculaRelacaoRiscoGanho()
        {
            int numerador = Convert.ToInt32(Math.Abs(RiscoPercent));
            int denominador = Convert.ToInt32(Math.Abs(GanhoPercent));
            int novoNumerador = 0;
            int novoDenominador = 0;

            if (numerador > denominador) // CASO O NUMERADOR SEJA MAIOR QUE O DENOMINADOR
            {
                for (int i = 2; i < denominador; i++)
                    if (numerador % i == 0 && denominador % i == 0)
                    {
                        novoNumerador = numerador / i;
                        novoDenominador = denominador / i;
                    }
            }
            else if (numerador < denominador)
            { // CASO O DENOMINADOR SEJA MAIOR QUE O NUMERADOR
                for (int i = 2; i <= numerador; i++)
                {
                    if (numerador % i == 0 && denominador % i == 0)
                    {
                        novoNumerador = numerador / i;
                        novoDenominador = denominador / i;
                    }
                }
            }
            else if (novoNumerador == novoDenominador)
            {//NUMEROS IGUAIS
                novoNumerador = novoDenominador = 1;
            }

            if (novoNumerador == 0 && novoDenominador == 0)
            {//numero muito diferentes - sem mdc
                novoNumerador = numerador;
                novoDenominador = denominador;
            }

            return novoNumerador + "/" + novoDenominador;
        }

        private double calculaGanhoParcialPercent()
        {
            try
            {
                return ((Convert.ToDouble(this.parcial) - Convert.ToDouble(this.entrada)) * 100 / Convert.ToDouble(this.entrada));
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private double calculaGanhoParcialValor()
        {
            // Create a NumberFormatInfo object and set some of its properties.
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";
            return Convert.ToDouble(this.capital, provider) * this.ParcialPercent / 100;
        }

    }
}
