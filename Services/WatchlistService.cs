using AutoMapper;
using cashboard3._5.Data;
using cashboard3._5.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Models.TradeModels;
using Models.WatchlistModels;
using Services.Contracts;
using System.Security.Claims;


namespace Services
{
    public class WatchlistService : IWatchlistService
    {

        private string _userId;
        private readonly DataDbContext _context;
        private readonly IMapper _mapper;

        public WatchlistService(DataDbContext context, IHttpContextAccessor httpContext, IMapper mapper)
        {
            var user = httpContext.HttpContext.User.Identity as ClaimsIdentity;
            var userId = user!.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) throw new Exception("Invalid User Details");

            _userId = userId;
            _context = context;
            _mapper = mapper;


        }

        public async Task<bool> DeleteCryptoWatchlistItem(int cryptoWatchlistId)
        {
            var watchlistItem = await _context.CryptoWatchlist.FirstOrDefaultAsync(x => x.CryptoWatchlistEntityId == cryptoWatchlistId);
            if (watchlistItem == null) { return false; }
            _context.CryptoWatchlist.Remove(watchlistItem);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteStockWatchlistItem(int stockWatchlistId)
        {
            var watchlistItem = await _context.StockWatchlist.FirstOrDefaultAsync(x => x.StockWatchlistEntityId == stockWatchlistId);
            if (watchlistItem == null) { return false; }
            _context.StockWatchlist.Remove(watchlistItem);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<GenericWatchlistDetail> GetCryptoWatchlistItem(int entityId)
        { 
            var cryptoItem = await _context.CryptoWatchlist.FirstOrDefaultAsync(x => x.CryptoWatchlistEntityId == entityId);
            return _mapper.Map<GenericWatchlistDetail>(cryptoItem);
        }

        public async Task<GenericWatchlistDetail> GetStockWatchlistItem(int entityId)
        {
            var cryptoItem = await _context.StockWatchlist.FirstOrDefaultAsync(x => x.StockWatchlistEntityId == entityId);
            return _mapper.Map<GenericWatchlistDetail>(cryptoItem);
        }


        public async Task<IEnumerable<CryptoWatchlistDetail>> GetAllCryptoWatchlistDetails()
        {
            var cryptoWatchlist = await _context.CryptoWatchlist.ToListAsync();

            return _mapper.Map<IEnumerable<CryptoWatchlistDetail>>(cryptoWatchlist);
        }
        public async Task<IEnumerable<StockWatchlistDetail>> GetAllStockWatchlistDetails()
        {
            var stockWatchlistDetail = await _context.StockWatchlist.ToListAsync();

            return _mapper.Map<IEnumerable<StockWatchlistDetail>>(stockWatchlistDetail);
        }


        public async Task<bool> NewWatchlistItemCrypto(AddWatchlistItem model)
        {
            var conversion = _mapper.Map<CryptoWatchlistEntity>(model);
            conversion.DateEntered = DateTime.UtcNow;
            conversion.ApplicationUserId = _userId;

            await _context.CryptoWatchlist.AddAsync(conversion);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> NewWatchlistItemStock(AddWatchlistItemStock model)
        {
            var conversion = _mapper.Map<StockWatchlistEntity>(model);
            conversion.DateEntered = DateTime.UtcNow;
            conversion.ApplicationUserId = _userId;

            await _context.StockWatchlist.AddAsync(conversion);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> UpdateCryptoWatchlistItem(UpdateCryptoWatchlistItem model)
        {
            var cryptoWatchlistItem = _context.CryptoWatchlist.FirstOrDefault(x => x.CryptoWatchlistEntityId == model.CryptoWatchlistEntityId);
            if (cryptoWatchlistItem != null || cryptoWatchlistItem.ApplicationUserId != _userId)
            {
                return false;
            }
            var conversion = _mapper.Map(model, cryptoWatchlistItem);
            _context.CryptoWatchlist.Update(conversion);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> UpdateStockWatchlistItem(UpdateStockWatchlistItem model)
        {
            var stockWatchlistItem = _context.StockWatchlist.FirstOrDefault(x => x.StockWatchlistEntityId == model.StockWatchlistEntityId);
            if (stockWatchlistItem != null || stockWatchlistItem.ApplicationUserId != _userId)
            {
                return false;
            }
            var conversion = _mapper.Map(model, stockWatchlistItem);
            _context.StockWatchlist.Update(conversion);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
