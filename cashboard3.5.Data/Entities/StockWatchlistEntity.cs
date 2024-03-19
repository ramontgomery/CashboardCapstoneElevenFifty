using System;
using System.ComponentModel.DataAnnotations;

namespace cashboard3._5.Data.Entities
{
    public class StockWatchlistEntity
    {
        [Key]
        public int StockWatchlistEntityId { get; set; }
        [Required]
        public DateTime DateEntered { get; set; }
        [Required]
        [MaxLength(8, ErrorMessage = "Symbol should be 8 characters or less. Please use Base Symbol and not Symbol with Pair"), MinLength(3)]

        public string Symbol { get; set; } = string.Empty;
        [MaxLength(20)]
        public string? AssetName { get; set; }
        public string? Thesis { get; set; }
        public float? TargetEntry { get; set; }
        public float? TargetExit { get; set; }
        public string? InvalidationOfThesis { get; set; }
        public string? Notes { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }
    }
}