using Models.TradeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.WatchlistModels;

namespace Services.Contracts
{
    public interface IWatchlistService
    {
        Task<bool> NewWatchlistItemCrypto(AddWatchlistItem model);
        Task<bool> NewWatchlistItemStock(AddWatchlistItemStock model);

       Task<GenericWatchlistDetail> GetCryptoWatchlistItem(int entityId);
        Task<GenericWatchlistDetail> GetStockWatchlistItem(int entityId);
        Task<bool> UpdateStockWatchlistItem(UpdateStockWatchlistItem model);
        Task<bool> UpdateCryptoWatchlistItem(UpdateCryptoWatchlistItem model);

        Task<bool> DeleteStockWatchlistItem(int stockWatchlistId);

        Task<bool> DeleteCryptoWatchlistItem(int cryptoWatchlistId);


        Task<IEnumerable<CryptoWatchlistDetail>> GetAllCryptoWatchlistDetails();
        Task<IEnumerable<StockWatchlistDetail>> GetAllStockWatchlistDetails();
    }
}
