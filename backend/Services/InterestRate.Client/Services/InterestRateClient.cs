using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace InterestRate.Client.Services
{
    public class InterestRateClient : IInterestRateClient
    {
        private readonly HttpClient _httpClient;

        public InterestRateClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<double> GetInterestRate()
        {
            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"{_httpClient.BaseAddress}{InterestRateConstants.GetUrl}")
                };

                var response = await _httpClient.SendAsync(request);

                return await GetInterestRateResponseAsync(response);
            }
            catch
            {
                return default;
            }
        }

        private async Task<double> GetInterestRateResponseAsync(HttpResponseMessage response)
        {
            var contentResponse = string.Empty;

            if (response?.Content != null)
                contentResponse = await response.Content.ReadAsStringAsync();

            if (response?.StatusCode == HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<double>(contentResponse);

            return default;
        }
    }
}
