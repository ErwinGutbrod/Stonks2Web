using CsvHelper.Configuration.Attributes;
using System;

namespace Stonks2.StockBot
{
    public class StooqRecord
    {

        [Index(0)]
        public string Symbol { get; set; }

        [Index(1)]
        public DateTime Date { get; set; }

        [Index(2)]
        public DateTime Time { get; set; }

        [Index(3)]
        public float Open { get; set; }

        [Index(4)]
        public float High { get; set; }

        [Index(5)]
        public float Low { get; set; }

        [Index(6)]
        public float Close { get; set; }

        [Index(7)]
        public float Volume { get; set; }

        public string ToChatBotString()
        {
            return this.Symbol + " quote is $" + this.Close + " per share." ;
        }
    }
}