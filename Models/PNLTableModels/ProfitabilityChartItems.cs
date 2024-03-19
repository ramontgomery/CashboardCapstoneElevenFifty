using Models.TradeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.PNLTableModels
{
    public class ProfitabilityChartItems
    {
        public string ApplicationUserId { get; set; }
        public double TotalProfit { get; set; }
        public double TotalLosses { get; set; }
        public double TotalPercentLoss { get; set; }
        public double TotalPercentGain { get; set; }
        public List<double> ListOfProfits = new List<double>();
        public List<double> ListOfLosses = new List<double>();
        public List<DateTime> ClosedTradeDates = new List<DateTime>(); 
        public List<TradeDetail> TradeDetailList= new List<TradeDetail>();

    }
}
