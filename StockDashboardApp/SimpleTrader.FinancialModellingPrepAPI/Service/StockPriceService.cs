using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Services;
using SimpleTrader.FinancialModellingPrepAPI.Results;
using StockDashboardApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModellingPrepAPI.Service
{
    public class StockPriceService : IStockPriceService
    {
        public async Task<double> GetPrice(string symbol)
        {
        
            string uri = $"quote-short?symbol={symbol}&apikey=OPiFfF88CslMZWUWhgip9sdaV4dVPlBj";

            using (FinancialModelingPrepHttpClient client = new FinancialModelingPrepHttpClient())
            {
                StockPriceResult data = await client.GetAsync<StockPriceResult>(uri);

                if (data.price == 0)
                {
                    throw new InvalidSymbolException(symbol);
                }
                return data.price;
            }
        }
    }
}
