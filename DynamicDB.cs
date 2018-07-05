using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationsWF
{
    public static class DynamicDB
    {
        public static string[] exchanges = new [] {
            "Poloniex",
            "Bitfinex",
            "Bittrex",
            "Binance",
            "Bitstamp",
            "Gemini",
            "OKEX",
            "CEX.io",
            "Coinbase",
            "CoinMama",
            "BitPanda",
            "Huobi",
            "Upbit",
            "Bithumb",
            "Lbank",
            "HitBTC",
            "BCEX",
            "GDAX",
            "Kraken",
            "Bibox",
            "BitFlyer",
            "Kucoin"
        };
        public static string[] ferramentas = new[] {
            "TradingView",
            "Nativa da Exchange"
        };
        public static string[] estadosPosicao = new[] {
            "Aberta",
            "Fechada"
        };
        public static string[] tiposTrade = new[] {
            "Day-trading",
            "Scalping",
            "Swing-trading",
            "Position"
        };

        public static string[] tecnicas = new[] {
            "Rompimento de cunha de baixa",
            "Rompimento de topos e fundos",
            "Somente indicadores",
            "Retração de Fibonacci"
        };

        public static string[] tiposPosicao = new[] {
            "Long position",
            "Short position"
        };

        public static string[] resultados = new[] {
            "Alvo",
            "Alvo com parcial",
            "Stop",
            "Stop com parcial",
            "Saída não prevista",
            "Aguardando fechamento"
        };

        public static string[] indicadores = new[] {
            "Ichimoku",
            "RSI",
            "Stochastic",
            "Médias móveis",
            "MACD",
            "Bollinger Bands"
        };

        public static string[] moedas = new[] {
            "BTC",
            "USD",
            "XMR",
            "XRP",
            "STR",
            "DASH",
            "ETH",
            "GNT",
            "BCH",
            "LTC",
            "ETC",
            "XEM",
            "DGB",
            "BTS",
            "ZEC",
            "OMG",
            "XPM"
        };
    }
}
