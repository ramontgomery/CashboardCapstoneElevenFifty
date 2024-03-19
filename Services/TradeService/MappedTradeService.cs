using AutoMapper;
using cashboard3._5.Data;
using cashboard3._5.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Models.TradeModels;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.TradeService
{
    public class MappedTradeService : ITradeService
    {
        private string _userId;
        private readonly DataDbContext _context;
        private readonly IMapper _mapper;
        public MappedTradeService(DataDbContext context, IHttpContextAccessor httpContext, IMapper mapper)
        {
            var user = httpContext.HttpContext.User.Identity as ClaimsIdentity;
            var userId = user!.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            
            //if (userId == null) throw new Exception("Invalid User Details");
            
            _userId = userId;
            _context = context;
            _mapper = mapper;
            

        }

        public async Task<bool> NewTradeAsync(NewOpenTrade model)
        {
            var conversion = _mapper.Map<TradeEntity>(model);
            conversion.DateEntered = DateTime.UtcNow;
            conversion.ApplicationUserId = _userId;

            await _context.Trades.AddAsync(conversion);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> NewClosedTradeAsync(NewClosedTrade model)
        {
            var conversion = _mapper.Map<TradeEntity>(model);
            conversion.DateEntered = DateTime.UtcNow;
            conversion.ApplicationUserId = _userId;

            await _context.Trades.AddAsync(conversion);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> CloseTradeAsync(int id)
        {
            var tradeToClose = await _context.Trades.FindAsync(id);
            if (tradeToClose != null || tradeToClose.ApplicationUserId != _userId)
            {
                return false;
            }
            tradeToClose.IsOpen = false;
            return await _context.SaveChangesAsync() == 1;

        }
        public async Task<bool> EditTradeDetail(TradeDetail model)
        {
            var tradeToEdit = await _context.Trades.FirstOrDefaultAsync(x => x.TradeEntityId == model.TradeEntityId);

            if (tradeToEdit == null || tradeToEdit.ApplicationUserId != _userId)
            {
                return false;
            }


            _mapper.Map(model, tradeToEdit);


            await _context.SaveChangesAsync();

            return true;
        }
            public async Task<bool> EditTradeAsync(EditTrade model)
        {
            var tradeToEdit = _context.Trades.FirstOrDefault(x => x.TradeEntityId == model.TradeEntityId);
            if (tradeToEdit != null || tradeToEdit.ApplicationUserId != _userId)
            {
                return false;
            }
            var conversion = _mapper.Map(model, tradeToEdit);
            _context.Trades.Update(conversion);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteTradeAsync(int tradeEntityId)
        {
            var trade = await _context.Trades.FirstOrDefaultAsync(x => x.TradeEntityId == tradeEntityId);
            if (trade == null) { return false; }
            _context.Trades.Remove(trade);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<TradeDetail> GetTradeById(int id)
        {
            var tradeInfo = await _context.Trades.FirstOrDefaultAsync(x => x.TradeEntityId == id) /*&& x.ApplicationUserId == _userId)*/;

            if (tradeInfo == null)
            {
                throw new Exception("Trade by this id does not exist");
            }

            return _mapper.Map<TradeDetail>(tradeInfo);
        }
        public async Task<IEnumerable<TradeDetail>> GetAllTrades()
        {
            var trades = await _context.Trades.ToListAsync();
            return _mapper.Map<IEnumerable<TradeDetail>>(trades);
        }
        public async Task<IEnumerable<TradeDetail>> GetOpenTrades()
        {
            var closedTrades = await _context.Trades.Where(c=> c.IsOpen == true).ToListAsync();
            return _mapper.Map<IEnumerable<TradeDetail>>(closedTrades);
        }
        public async Task<IEnumerable<TradeDetail>> GetClosedTrades()
        {
            var openTrades = await _context.Trades.Where(c => c.IsOpen == false).ToListAsync();

            return _mapper.Map<IEnumerable<TradeDetail>>(openTrades);
        }
    }
}
