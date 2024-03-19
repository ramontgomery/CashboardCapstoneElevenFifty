using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.TradeModels
{
    public class NewClosedTrade
    {
        public int TradeEntityId { get; set; }
        public bool IsOpen { get; set; } = false;
        public bool IsCrypto { get; set; }

        public bool? Profitabile { get; set; }
        public float? PriceAtExit { get; set; }

        public string? ClosedReason { get; set; } = string.Empty;
        [Range(1, 10)]
        public int? TradeRating { get; set; }
        public string? Improvements { get; set; }
        public string? Observations { get; set; }

        public double? ProfitPercent { get; set; }

        public bool? TargetReached { get; set; }


        public string? ApplicationUserId { get; set; }
    }
}
