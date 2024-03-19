using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.TradeModels;

namespace Models.PNLTableModels
{
    public class AllPNLDataDetail
    {


        public double? TotalPnl { get; set; }

        public double? CryptoPnlPercent { get; set; }

        public double? StockPnlPercent { get; set; }

        public double? WinRateStocks { get; set; }

        public double? WinRateCrypto { get; set; }

        public double? WinRateTotal { get; set; }


        public string ApplicationUserId { get; set; }

    }
}