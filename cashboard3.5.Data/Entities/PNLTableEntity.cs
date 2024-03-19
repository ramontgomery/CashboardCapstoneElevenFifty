using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cashboard3._5.Data.Entities
{
    public class PNLTableEntity
    {
        [Key]
        public int PNLTableEntityId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double? TotalPnlPercent { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double? CryptoPnlPercent { get;}
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double? StockPnlPercent { get; set;  }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double? WinRateStocks { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double? WinRateCrypto { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double? WinRateTotal { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double? ProfitabilityPercent { get; set; }
        [Required]
        public string ApplicationUserId { get; set; }
        public List<TradeEntity> TradeEntityList = new List<TradeEntity>();
    }
}