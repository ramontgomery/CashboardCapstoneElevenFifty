using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.TradeModels
{
    public class NewTrade
    {

        public bool IsCrypto { get; set; }
        [Required]
        public bool IsOpen { get; set; }
        [Required]
        public DateTime DateEntered { get; set; }
        [Required]
        public string DateTimeOpened { get; set; }
        [Required]
        [MaxLength(8, ErrorMessage = "Symbol should be 8 characters or less. Please use Base Symbol and not Symbol with Pair"), MinLength(3)]
        public string Symbol { get; set; } = string.Empty;
        [MaxLength(20)]
        public string? AssetName { get; set; }
        [Required]
        public string DirectionOpened { get; set; } = string.Empty;
        [Required]

        public double PriceAtEntry { get; set; }
        public double? Target { get; set; }
        public float? SizeInUsd { get; set; }
        public float? StopLoss { get; set; }
        public string? TradeReason { get; set; }
        [Required]
        [Range(1, 10)]
        public int ConfidenceLevel { get; set; }


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
