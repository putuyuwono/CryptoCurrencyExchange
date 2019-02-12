using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;

namespace CryptocurrencyExchange
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        internal void RaisePropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        #region Data Bindings

        private double btcValue;
        public double BtcValue
        {
            get { return btcValue; }
            set
            {
                btcValue = value;
                RaisePropertyChanged("BtcValue");
            }
        }

        private double satValue;
        public double SatValue
        {
            get { return satValue; }
            set
            {
                satValue = value;
                RaisePropertyChanged("SatValue");
            }
        }

        private double convEthValue;
        public double ConvEthValue
        {
            get { return convEthValue; }
            set
            {
                convEthValue = value;
                RaisePropertyChanged("ConvEthValue");
            }
        }

        private double convEtcValue;
        public double ConvEtcValue
        {
            get { return convEtcValue; }
            set
            {
                convEtcValue = value;
                RaisePropertyChanged("ConvEtcValue");
            }
        }

        private double convLtcValue;
        public double ConvLtcValue
        {
            get { return convLtcValue; }
            set
            {
                convLtcValue = value;
                RaisePropertyChanged("ConvLtcValue");
            }
        }

        private double convWavesValue;
        public double ConvWavesValue
        {
            get { return convWavesValue; }
            set
            {
                convWavesValue = value;
                RaisePropertyChanged("ConvWavesValue");
            }
        }

        private double convDashValue;
        public double ConvDashValue
        {
            get { return convDashValue; }
            set
            {
                convDashValue = value;
                RaisePropertyChanged("ConvDashValue");
            }
        }

        private double convXmrValue;
        public double ConvXmrValue
        {
            get { return convXmrValue; }
            set
            {
                convXmrValue = value;
                RaisePropertyChanged("ConvXmrValue");
            }
        }

        private double convDogeValue;
        public double ConvDogeValue
        {
            get { return convDogeValue; }
            set
            {
                convDogeValue = value;
                RaisePropertyChanged("ConvDogeValue");
            }
        }

        private double convBchValue;
        public double ConvBchValue
        {
            get { return convBchValue; }
            set
            {
                convBchValue = value;
                RaisePropertyChanged("ConvBchValue");
            }
        }

        private double convUSDValue;
        public double ConvUSDValue
        {
            get { return convUSDValue; }
            set
            {
                convUSDValue = value;
                RaisePropertyChanged("ConvUSDValue");
            }
        }

        private double convRUBValue;
        public double ConvRUBValue
        {
            get { return convRUBValue; }
            set
            {
                convRUBValue = value;
                RaisePropertyChanged("ConvRUBValue");
            }
        }

        private double convKRWValue;
        public double ConvKRWValue
        {
            get { return convKRWValue; }
            set
            {
                convKRWValue = value;
                RaisePropertyChanged("ConvKRWValue");
            }
        }


        #endregion

        public MainViewModel()
        {
            Init();

            SatValue = 1;

            ConvertSatToBTC();
        }

        private void Init()
        {
            listCryptocurrency = new List<Cryptocurrency>
            {
                Cryptocurrency.ETH,
                Cryptocurrency.ETC,
                Cryptocurrency.LTC,
                Cryptocurrency.Waves,
                Cryptocurrency.Dash,
                Cryptocurrency.XMR,
                Cryptocurrency.DOGE,
                Cryptocurrency.BCH
            };

            listFiatcurrency = new List<Fiatcurrency>
            {
                Fiatcurrency.USD,
                Fiatcurrency.RUB,
                Fiatcurrency.KRW
            };
        }

        private void ConvertSatToBTC()
        {
            BtcValue = SatValue / 100000000;
        }

        public void Refresh()
        {
            ConvertSatToBTC();
            foreach (var cryptocurrency in listCryptocurrency)
            {
                try
                {
                    dynamic obj = JArray.Parse(GetRequest(cryptocurrency))[0];
                    Double.TryParse((string)obj.price_btc, out double btcPrice);
                    double conValue = 1 / btcPrice * BtcValue;

                    if (cryptocurrency.CryptoID == Cryptocurrency.ETH.CryptoID)
                    {
                        ConvEthValue = conValue;
                    }
                    else if (cryptocurrency.CryptoID == Cryptocurrency.ETC.CryptoID)
                    {
                        ConvEtcValue = conValue;
                    }
                    else if (cryptocurrency.CryptoID == Cryptocurrency.LTC.CryptoID)
                    {
                        ConvLtcValue = conValue;
                    }
                    else if (cryptocurrency.CryptoID == Cryptocurrency.Waves.CryptoID)
                    {
                        ConvWavesValue = conValue;
                    }
                    else if (cryptocurrency.CryptoID == Cryptocurrency.Dash.CryptoID)
                    {
                        ConvDashValue = conValue;
                    }
                    else if (cryptocurrency.CryptoID == Cryptocurrency.XMR.CryptoID)
                    {
                        ConvXmrValue = conValue;
                    }
                    else if (cryptocurrency.CryptoID == Cryptocurrency.DOGE.CryptoID)
                    {
                        ConvDogeValue = conValue;
                    }
                    else if (cryptocurrency.CryptoID == Cryptocurrency.BCH.CryptoID)
                    {
                        ConvBchValue = conValue;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }                
            }

            foreach (var fiatcurrency in listFiatcurrency)
            {
                try
                {
                    dynamic obj = JArray.Parse(GetRequest(fiatcurrency))[0];
                    

                    if (fiatcurrency.FiatID == Fiatcurrency.USD.FiatID)
                    {
                        Double.TryParse((string)obj.price_usd, out double btcPrice);
                        double conValue = btcPrice * BtcValue;
                        ConvUSDValue = conValue;
                    }
                    else if (fiatcurrency.FiatID == Fiatcurrency.RUB.FiatID)
                    {
                        Double.TryParse((string)obj.price_rub, out double btcPrice);
                        double conValue = btcPrice * BtcValue;
                        ConvRUBValue = conValue;
                    }
                    else if(fiatcurrency.FiatID == Fiatcurrency.KRW.FiatID)
                    {
                        Double.TryParse((string)obj.price_krw, out double btcPrice);
                        double conValue = btcPrice * BtcValue;
                        ConvKRWValue = conValue;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private string GetRequest(Cryptocurrency crypto)
        {
            string json = string.Empty;

            string url = SERVICE_URL_CRYP.Replace("{coin-id}", crypto.CryptoID);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }

            return json;
        }

        private string GetRequest(Fiatcurrency fiat)
        {
            string json = string.Empty;

            string url = SERVICE_URL_FIAT.Replace("{fiat-id}", fiat.FiatID);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }

            return json;
        }


        private List<Cryptocurrency> listCryptocurrency;
        private List<Fiatcurrency> listFiatcurrency;
        private const string SERVICE_URL_CRYP = "https://api.coinmarketcap.com/v1/ticker/{coin-id}/";
        private const string SERVICE_URL_FIAT = "https://api.coinmarketcap.com/v1/ticker/bitcoin/?convert={fiat-id}";
    }
}
