namespace CoinTracker.Models
{
    public class Market
    {
        public string ExchangeId { get; set; } = null!;
        public int Rank { get; set; }
        public string BaseSymbol { get; set; } = null!;
        public string BaseId { get; set; } = null!;
        public string QuoteSymbol { get; set; } = null!;
        public string QuoteId { get; set; } = null!;
        public decimal PriceQuote { get; set; }
        public decimal? PriceUsd { get; set; }
        public decimal? VolumeUsd24Hr { get; set; }
        public decimal? PercentExchangeVolume { get; set; }
        public int? TradesCount24Hr { get; set; }
        public long Updated { get; set; }
    }
}
