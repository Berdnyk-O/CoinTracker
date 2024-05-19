namespace CoinTracker.Models
{
    public class Exchange
    {
        public string ExchangeId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int Rank { get; set; }
        public decimal? PercentTotalVolume { get; set; }
        public decimal? VolumeUsd { get; set; }
        public int TradingPairs { get; set; }
        public bool? Socket { get; set; }
        public string ExchangeUrl { get; set; } = null!;
        public long Updated { get; set; }
    }
}
