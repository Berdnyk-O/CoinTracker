namespace CoinTracker.Models
{
    public class AssetMarketData
    {
        public string ExchangeId { get; set; } = null!;
        public string BaseId { get; set; } = null!;
        public string QuoteId { get; set; } = null!;
        public string BaseSymbol { get; set; } = null!;
        public string QuoteSymbol { get; set; } = null!;
        public decimal VolumeUsd24Hr { get; set; }
        public decimal PriceUsd { get; set; }
        public decimal VolumePercent { get; set; }
    }
}
