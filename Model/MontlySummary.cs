using OperationsWF.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Positions.Model
{
    public class MonthSummary
    {
        private int mes = 0;
        private long lucro;
        private long percentCapitalInicial;
        private TimeSpan duracaoMedia;
        private ArrayList posicoes = new ArrayList();

        public MonthSummary (int mes) {
            this.mes = mes;
        }

        public int Mes { get => mes; }
        public ArrayList Posicoes { get => posicoes; }
        public string MesNome { get => GetNomeMes(); }
        public int TotalOperacoes { get => posicoes.Count; }
        public string DuracaoMedia { get => CalculaDuracaoMedia(); }
        public double TaxaAcerto { get => CalculaTaxaAcerto(); }

        private double CalculaTaxaAcerto()
        {
            //carrega totais
            int totalAlvos = 0;
            foreach (Position position in Posicoes)
            {
                if (position.Resultado == "Alvo")
                    totalAlvos = totalAlvos + 1;
            }
            return totalAlvos * 100 / TotalOperacoes;
        }

        private string CalculaDuracaoMedia()
        {
            TimeSpan tempoTotal = new TimeSpan(0);
            foreach (Position posicao in posicoes)
            {
                tempoTotal = tempoTotal + posicao.Duracao;
            }
            TimeSpan duracaoMedia = new TimeSpan(tempoTotal.Ticks / TotalOperacoes);
            return String.Format("Duração: {0} Dias - {1} Horas - {2} Min.", duracaoMedia.Days, duracaoMedia.Hours, duracaoMedia.Minutes);
        }

        private string GetNomeMes()
        {
            switch (mes) {
                case 1:
                    return "Janeiro";
                case 2:
                    return "Fevereiro";
                case 3:
                    return "Março";
                case 4:
                    return "Abril";
                case 5:
                    return "Maio";
                case 6:
                    return "Junho";
                case 7:
                    return "Julho";
                case 8:
                    return "Agosto";
                case 9:
                    return "Setembro";
                case 10:
                    return "Outubro";
                case 11:
                    return "Novembro";
               default:
                    return "Dezembro";
            }
        }
    }
}
