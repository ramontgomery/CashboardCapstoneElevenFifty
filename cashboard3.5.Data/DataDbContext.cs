
using cashboard3._5.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace cashboard3._5.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options) { }
        public DbSet<TradeEntity> Trades { get; set; }
        public DbSet<CryptoWatchlistEntity> CryptoWatchlist { get; set; }
        public DbSet<PNLTableEntity> PnlTable { get; set; }
        public DbSet<StockWatchlistEntity> StockWatchlist { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TradeEntity>().HasData(

                        new TradeEntity

                        {

                            TradeEntityId = 1,
                            IsCrypto = true,
                            IsOpen = true,
                            DateEntered = DateTime.UtcNow,
                            DateTimeOpened = "03/01/2024",
                            Symbol = "BTC",
                            AssetName = "Bitcoin",
                            DirectionOpened = "Long",
                            PriceAtEntry = 65000.45,
                            Target = 70000.00,
                            SizeInUsd = 1000,
                            StopLoss = 61990,
                            TradeReason = "Strong uptrend based on many factors",
                            ConfidenceLevel = 9,


                        },

                        new TradeEntity

                        {

                            TradeEntityId = 2,
                            IsCrypto = true,
                            IsOpen = false,
                            DateEntered = DateTime.UtcNow,
                            DateTimeOpened = "03/02/2024",
                            Symbol = "ETH",
                            AssetName = "Ethereum",
                            DirectionOpened = "Long",
                            PriceAtEntry = 3510.45,
                            Target = 4000.00,
                            SizeInUsd = 1000,
                            StopLoss = 3400,
                            TradeReason = "Very Strong uptrend based on many factors, ETF soon",
                            ConfidenceLevel = 9,
                            Profitabile = true,
                            PriceAtExit = 3900,
                            ClosedReason = "market looked topped",
                            TradeRating = 7,
                            Improvements = "None",
                            Observations = "None",
                            ProfitPercent = 10,
                            TargetReached = false


                        },
                        new TradeEntity

                        {

                            TradeEntityId = 3,
                            IsCrypto = true,
                            IsOpen = true,
                            DateEntered = DateTime.UtcNow,
                            DateTimeOpened = "03/01/2024",
                            Symbol = "BTC",
                            AssetName = "Bitcoin",
                            DirectionOpened = "Long",
                            PriceAtEntry = 65000.45,
                            Target = 70000.00,
                            SizeInUsd = 1000,
                            StopLoss = 61990,
                            TradeReason = "Strong uptrend based on many factors",
                            ConfidenceLevel = 9,


                        },
                        new TradeEntity

                        {

                            TradeEntityId = 4,
                            IsCrypto = true,
                            IsOpen = true,
                            DateEntered = DateTime.UtcNow,
                            DateTimeOpened = "03/01/2024",
                            Symbol = "BTC",
                            AssetName = "Bitcoin",
                            DirectionOpened = "Long",
                            PriceAtEntry = 65000.45,
                            Target = 70000.00,
                            SizeInUsd = 1000,
                            StopLoss = 61990,
                            TradeReason = "Strong uptrend based on many factors",
                            ConfidenceLevel = 9,
                            Profitabile = true,
                            PriceAtExit = 3900,
                            ClosedReason = "market looked topped",
                            TradeRating = 7,
                            Improvements = "None",
                            Observations = "None",
                            ProfitPercent = 10,
                            TargetReached = false

                        }

        );
        }

    }
}