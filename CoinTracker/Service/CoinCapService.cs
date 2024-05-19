using CoinTracker.Models;
using System.Collections.ObjectModel;
using System.IO.Compression;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
namespace CoinTracker.Service
{
    public class CoinCapService : ICoinCapService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        private const string AssetsEndpoint = "/assets";
        private const string RatesEndpoint = "/rates";

        public CoinCapService(HttpClient httpClient, string baseUrl)
        {
            _httpClient = httpClient;
            _baseUrl = baseUrl;
        }

        public async Task<ObservableCollection<Asset>> GetAssets() 
        {
            var response = await _httpClient.GetAsync(_baseUrl + AssetsEndpoint);
            response.EnsureSuccessStatusCode();

            using (var stream = await response.Content.ReadAsStreamAsync())
            using (var decompressedStream = new GZipStream(stream, CompressionMode.Decompress))
            using (var reader = new StreamReader(decompressedStream))
            {
                var responseBody = await reader.ReadToEndAsync();
                var data = JsonConvert.DeserializeObject<BaseAssetResponse>(responseBody);
                
                if (data == null)
                {
                    return new ObservableCollection<Asset>();
                }
                return new ObservableCollection<Asset>(data.Data.Take(10));
            }
        }

        public async Task<ObservableCollection<Rate>> GetRates()
        {
            var response = await _httpClient.GetAsync(_baseUrl + RatesEndpoint);
            response.EnsureSuccessStatusCode();

            using (var stream = await response.Content.ReadAsStreamAsync())
            using (var decompressedStream = new GZipStream(stream, CompressionMode.Decompress))
            using (var reader = new StreamReader(decompressedStream))
            {
                var responseBody = await reader.ReadToEndAsync();
                var data = JsonConvert.DeserializeObject<BaseRateResponse>(responseBody);

                if (data == null)
                {
                    return new ObservableCollection<Rate>();
                }
                return new ObservableCollection<Rate>(data.Data);
            }
        }
    }
}
