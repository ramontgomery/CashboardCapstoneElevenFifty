using cashboard3._5.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.WatchlistModels
{
    public class AllWatchlistDetail
    {
        public string ApplicationUserId { get; set; }
        public List<CryptoWatchlistDetail>? CryptoWatchlist { get; set; }
        public List<StockWatchlistDetail>? StockWatchlist { get; set;}
    }
}
