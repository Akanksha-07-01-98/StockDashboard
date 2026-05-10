using SimpleTrader.Domain.Services;
using SimpleTrader.FinancialModellingPrepAPI.Results;
using StockDashboardApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModellingPrepAPI.Service
{
    public class MajorIndexService : IMajorIndexService
    {
        public async Task<MajorIndex> GetMajorIndex(MajorIndexType indexType)
        {
            string symbol = GetStockSymbol(indexType);
            

            using (FinancialModelingPrepHttpClient client = new FinancialModelingPrepHttpClient())
            {
                string uri = $"quote?symbol={symbol}&apikey=OPiFfF88CslMZWUWhgip9sdaV4dVPlBj";
                MajorIndex data = await client.GetAsync<MajorIndex>(uri);

                return data;
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
                    throw new Exception("MajorIndexType does not have a suffixed defined");
            }
        }
    }
}
