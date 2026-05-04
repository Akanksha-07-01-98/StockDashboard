using SimpleTrader.Domain.Services;
using StockDashboardApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http.Json;

namespace SimpleTrader.FinancialModellingPrepAPI.Service
{
    public class MajorIndexService : IMajorIndexService
    {
        public async Task<MajorIndex> GetMajorIndex(MajorIndexType indexType)
        {
            string symbol = GetStockSymbol(indexType);
            string uri = $"https://financialmodelingprep.com/stable/quote?symbol={symbol}&apikey=OPiFfF88CslMZWUWhgip9sdaV4dVPlBj";

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                var json = await response.Content.ReadAsStringAsync();

                var data = JsonSerializer.Deserialize<List<MajorIndex>>(json);

                return data?.FirstOrDefault();
            }
        }

        private string GetStockSymbol(MajorIndexType indexType)
        {
            switch(indexType)
            {
                case MajorIndexType.DowJones:
                    return "^DJI";
                case MajorIndexType.Nasdaq:
                    return "^IXIC";
                case MajorIndexType.Apple:
                    return "AAPL";
                default:
                    break;
            }
            return "^DJI";
        }
    }
}
