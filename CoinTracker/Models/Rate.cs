namespace CoinTracker.Models
{
    public class Rate
    {
        public string Id { get; set; } = null!;
        public string Symbol { get; set; } = null!;
        public string? CurrencySymbol { get; set; }
        public string Type { get; set; } = null!;
        public decimal RateUsd { get; set; }
    }
}
