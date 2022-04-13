using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace Project.WEBUI.Models.Helpers
{
    public class Currency
        //Currency = Kur Xml ile Burda tanımla
        
    {
        public Currency()
        {
            string currentCurrencies = "http://www.tcmb.gov.tr/kurlar/today.xml";

            XmlDocument xmlDoc = new XmlDocument();


            xmlDoc.Load(currentCurrencies);


            EuroSell = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            EuroBuy = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            DolarSell = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            DolarBuy = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
        }

        public string EuroSell { get; set; }
        public string EuroBuy { get; set; }
        public string DolarSell { get; set; }
        public string DolarBuy { get; set; }
    }
}