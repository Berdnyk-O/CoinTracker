using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinTracker.Models
{
    class BaseAssetMarketDataResponse
    {
        public AssetMarketData[] Data { get; set; } = null!;
    }
}
