using SimpleTrader.FinancialModellingPrepAPI.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModellingPrepAPI
{
    public class FinancialModelingPrepHttpClient:HttpClient
    {
        public FinancialModelingPrepHttpClient()
        {
            this.BaseAddress = new Uri("https://financialmodelingprep.com/stable/");
        }

        public async Task<T?> GetAsync<T>(string uri)
        {
            var response = await GetAsync(uri);

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            if (json.TrimStart().StartsWith("["))
            {
                var list = JsonSerializer.Deserialize<List<T>>(
                    json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                return list.FirstOrDefault();
            }

            return JsonSerializer.Deserialize<T>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }
    }
}
