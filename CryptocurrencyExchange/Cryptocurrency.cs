namespace CryptocurrencyExchange
{
    public class Cryptocurrency
    {
        public static Cryptocurrency BTC { get; } = new Cryptocurrency { CryptoID = "bitcoin" };
        public static Cryptocurrency ETH { get; } = new Cryptocurrency { CryptoID = "ethereum" };
        public static Cryptocurrency ETC { get; } = new Cryptocurrency { CryptoID = "ethereum-classic" };
        public static Cryptocurrency LTC { get; } = new Cryptocurrency { CryptoID = "litecoin" };
        public static Cryptocurrency Waves { get; } = new Cryptocurrency { CryptoID = "waves" };
        public static Cryptocurrency Dash { get; } = new Cryptocurrency { CryptoID = "dash" };
        public static Cryptocurrency XMR { get; } = new Cryptocurrency { CryptoID = "monero" };
        public static Cryptocurrency DOGE { get; } = new Cryptocurrency { CryptoID = "dogecoin" };
        public static Cryptocurrency BCH { get; } = new Cryptocurrency { CryptoID = "bitcoin-cash" };

        public string CryptoID { get; set; }        

    }
}
