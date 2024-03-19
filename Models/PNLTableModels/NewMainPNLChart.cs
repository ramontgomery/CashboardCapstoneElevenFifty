using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.PNLTableModels
{
    public class NewMainPNLChart
    {
        public string ApplicationUserId { get; set; }
        public List<MainPNLChartItems> MainPNLChartItems = new List<MainPNLChartItems>();
    }
}
