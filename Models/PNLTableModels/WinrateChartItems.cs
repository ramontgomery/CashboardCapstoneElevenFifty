using Models.TradeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.PNLTableModels
{
    public class WinrateChartItems
    {
        public string ApplicationUserId { get; set; }
        public int TotalTrades { get; set; }
        public int TotalWins { get; set; }
        public double WinRatePercentage { get; set; }
        public List<DateTime> DateOfClosedTrade = new List<DateTime>();
        
        public List<TradeDetail> TradeDetailsList = new List<TradeDetail>();
    }
}
