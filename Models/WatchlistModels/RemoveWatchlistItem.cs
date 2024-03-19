using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.WatchlistModels
{
    public class RemoveWatchlistItem
    {
        public string ApplicationUserId { get; set; }
        public List<CryptoWatchlistDetail> cryptoWatchlistItems = new List<CryptoWatchlistDetail>();

    }
}
