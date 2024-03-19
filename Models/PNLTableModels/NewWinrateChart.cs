using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.PNLTableModels
{
    public class NewWinrateChart
    {
        public string ApplicationUserId { get; set; }
        public List<WinrateChartItems> WinrateChartItems = new List<WinrateChartItems>();
    }
}
