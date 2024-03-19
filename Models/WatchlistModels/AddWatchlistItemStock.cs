using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.WatchlistModels
{
    public class AddWatchlistItemStock
    {
        public DateTime DateEntered { get; set; }
        [Required]
        [MaxLength(8, ErrorMessage = "Symbol should be 8 characters or less. Please use Base Symbol and not Symbol with Pair"), MinLength(3)]
        public bool IsCrypto { get; set; } = false;
        public string Symbol { get; set; } = string.Empty;
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
