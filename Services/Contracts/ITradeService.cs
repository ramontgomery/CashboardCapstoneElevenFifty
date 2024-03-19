using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.TradeModels;

namespace Services.Contracts
{
    public interface ITradeService 
    {


            Task<bool> NewTradeAsync(NewOpenTrade model);
            Task<bool> NewClosedTradeAsync(NewClosedTrade model);

            Task<bool> CloseTradeAsync(int id);

            Task<bool> EditTradeAsync(EditTrade model);
        Task<bool> EditTradeDetail(TradeDetail model);

        Task<bool> DeleteTradeAsync(int tradeEntityId);

            Task<TradeDetail> GetTradeById(int id);

            Task<IEnumerable<TradeDetail>> GetAllTrades();
            Task<IEnumerable<TradeDetail>> GetOpenTrades();
            Task<IEnumerable<TradeDetail>> GetClosedTrades();


    }
}
