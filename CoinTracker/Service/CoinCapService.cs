using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
namespace CoinTracker.Service
{
    public class CoinCapService : ICoinCapService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public CoinCapService(HttpClient httpClient, string baseUrl)
        {
            _httpClient = httpClient;
            _baseUrl = baseUrl;
        }
    }
}
