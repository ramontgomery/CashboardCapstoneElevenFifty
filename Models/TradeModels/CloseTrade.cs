using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.TradeModels
{
    public class CloseTrade
    {
        public int TradeEntityID { get; set; }
        public bool IsOpen { get; set; } = false;
    }
}
