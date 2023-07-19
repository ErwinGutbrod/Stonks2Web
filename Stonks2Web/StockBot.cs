using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Security.Cryptography.Xml;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin;
using System.IO;
using CsvHelper;
using System.Threading.Tasks;
using System.Globalization;

namespace Stonks2Web
{
    public class StockBot : IStockBot
    {
        public string CheckStock(string key)
        {
            string formattedMessage;

            using (HttpClient client = new HttpClient { BaseAddress = new Uri("https://stooq.com/q/l/?s=" + key + "&f=sd2t2ohlcv&h&e=csv")})
            {
                try
                {
                    // Add an Accept header for JSON format.
                    client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
                    if (response.IsSuccessStatusCode)
                    {
                    }
                    // List data response.                
                    using (var reader = new StreamReader(response.Content.ReadAsStreamAsync().Result))
                    {

                        var csvr = new CsvReader(reader, CultureInfo.InvariantCulture);
                        csvr.Read();
                        csvr.ReadHeader();
                        csvr.Read();
                        var responseValue = csvr.GetRecord<StooqRecord>();
                        formattedMessage = responseValue.ToChatBotString();
                    }
                }
                catch (Exception)
                {

                    throw;
                }                  
                    
            }           

            return formattedMessage;
        }
    }
}