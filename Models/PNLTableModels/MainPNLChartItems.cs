using Models.TradeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.PNLTableModels
{
    public class MainPNLChartItems
    {
        public string ApplicationUserId { get; set; }
        public List<string> ChartXAxisLabels { get; set; } = new List<string>();
        public List<double> ChartYAxisData { get; set; } = new List<double>();

    }
}
