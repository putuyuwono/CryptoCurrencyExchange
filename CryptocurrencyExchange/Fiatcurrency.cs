using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyExchange
{
    class Fiatcurrency
    {
        public static Fiatcurrency USD { get; } = new Fiatcurrency { FiatID = "USD" };
        public static Fiatcurrency RUB { get; } = new Fiatcurrency { FiatID = "RUB" };
        public static Fiatcurrency KRW { get; } = new Fiatcurrency { FiatID = "KRW" };

        public string FiatID { get; set; }
    }
}
