using Models.TradeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.PNLTableModels;

namespace Services.Contracts
{
    public interface IPnlService
    {
        Task<AllPNLDataDetail> CalculatePNLData();

        Task<MainPNLChartItems> GeneratePNLChartData();
    }
}
