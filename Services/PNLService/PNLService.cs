using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Models.PNLTableModels;
using Services.Contracts;


using cashboard3._5.Data;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using AutoMapper;
using Services.TradeService;
using Models.TradeModels;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace Services.PNLService
{
    public class PNLService : IPnlService
    {
        private string _userId;
        private readonly DataDbContext _context;
        private readonly IMapper _mapper;
        private readonly ITradeService _tradeService;
        public PNLService(DataDbContext context, IHttpContextAccessor httpContextAccessor, ITradeService tradeService)
        {
            _tradeService = tradeService;
            _context = context;
            var userIdClaim = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            _userId = userIdClaim?.Value ?? throw new Exception("User is not authenticated.");
        }

        public async Task<AllPNLDataDetail> CalculatePNLData()
        {
            var closedTrades = await _context.Trades
                .Where(t => t.ApplicationUserId == _userId && !t.IsOpen)
                .ToListAsync();

            var pnlDetail = new AllPNLDataDetail
            {
                ApplicationUserId = _userId,
                TotalPnl = 0,
                CryptoPnlPercent = 0,
                StockPnlPercent = 0,
                WinRateStocks = 0,
                WinRateCrypto = 0,
                WinRateTotal = 0,

            };

            // Begin calculations
            int totalTrades = closedTrades.Count;
            int totalProfitableTrades = 0;
            int cryptoTrades = 0;
            int cryptoProfitableTrades = 0;
            int stockTrades = 0;
            int stockProfitableTrades = 0;
            double totalPnl = 0;
            double cryptoPnl = 0;
            double stockPnl = 0;

            foreach (var trade in closedTrades)
            {
                double tradePnl = (trade.PriceAtExit ?? 0 - trade.PriceAtEntry) * (trade.SizeInUsd ?? 0);
                totalPnl += tradePnl;

                if (tradePnl > 0) totalProfitableTrades++;

                if (trade.IsCrypto)
                {
                    cryptoPnl += tradePnl;
                    cryptoTrades++;
                    if (tradePnl > 0) cryptoProfitableTrades++;
                }
                else
                {
                    stockPnl += tradePnl;
                    stockTrades++;
                    if (tradePnl > 0) stockProfitableTrades++;
                }
            }


            pnlDetail.TotalPnl = totalPnl;
            pnlDetail.CryptoPnlPercent = cryptoPnl;
            pnlDetail.StockPnlPercent = stockPnl;
            pnlDetail.WinRateStocks = stockTrades > 0 ? (double)stockProfitableTrades / stockTrades * 100 : 0;
            pnlDetail.WinRateCrypto = cryptoTrades > 0 ? (double)cryptoProfitableTrades / cryptoTrades * 100 : 0;
            pnlDetail.WinRateTotal = totalTrades > 0 ? (double)totalProfitableTrades / totalTrades * 100 : 0;


            return pnlDetail;
        }


        public async Task<MainPNLChartItems> GeneratePNLChartData()
        {

            var closedTrades = await _context.Trades
                .Where(t => t.ApplicationUserId == _userId && !t.IsOpen)
                .OrderBy(t => t.DateEntered)
                .ToListAsync();

            var pnlChartItems = new MainPNLChartItems
            {
                ApplicationUserId = _userId
            };


            foreach (var trade in closedTrades)
            {

                if (trade.PriceAtExit.HasValue && trade.SizeInUsd.HasValue)
                {
                    double profit = (trade.PriceAtExit.Value - trade.PriceAtEntry) * trade.SizeInUsd.Value;

                    pnlChartItems.ChartXAxisLabels.Add(trade.Symbol);
                    pnlChartItems.ChartYAxisData.Add(profit);
                }
            }

            return pnlChartItems;
        }
    }
}

