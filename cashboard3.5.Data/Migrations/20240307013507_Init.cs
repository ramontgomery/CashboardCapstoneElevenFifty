using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cashboard3._5.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CryptoWatchlist",
                columns: table => new
                {
                    CryptoWatchlistEntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateEntered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    AssetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thesis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetEntry = table.Column<float>(type: "real", nullable: true),
                    TargetExit = table.Column<float>(type: "real", nullable: true),
                    InvalidationOfThesis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptoWatchlist", x => x.CryptoWatchlistEntityId);
                });

            migrationBuilder.CreateTable(
                name: "PnlTable",
                columns: table => new
                {
                    PNLTableEntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPnlPercent = table.Column<double>(type: "float", nullable: true),
                    StockPnlPercent = table.Column<double>(type: "float", nullable: true),
                    WinRateStocks = table.Column<double>(type: "float", nullable: true),
                    WinRateCrypto = table.Column<double>(type: "float", nullable: true),
                    WinRateTotal = table.Column<double>(type: "float", nullable: true),
                    ProfitabilityPercent = table.Column<double>(type: "float", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PnlTable", x => x.PNLTableEntityId);
                });

            migrationBuilder.CreateTable(
                name: "StockWatchlist",
                columns: table => new
                {
                    StockWatchlistEntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateEntered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    AssetName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Thesis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetEntry = table.Column<float>(type: "real", nullable: true),
                    TargetExit = table.Column<float>(type: "real", nullable: true),
                    InvalidationOfThesis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockWatchlist", x => x.StockWatchlistEntityId);
                });

            migrationBuilder.CreateTable(
                name: "Trades",
                columns: table => new
                {
                    TradeEntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsCrypto = table.Column<bool>(type: "bit", nullable: false),
                    IsOpen = table.Column<bool>(type: "bit", nullable: false),
                    DateEntered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeOpened = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    AssetName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DirectionOpened = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceAtEntry = table.Column<double>(type: "float", nullable: false),
                    Target = table.Column<double>(type: "float", nullable: true),
                    SizeInUsd = table.Column<float>(type: "real", nullable: true),
                    StopLoss = table.Column<float>(type: "real", nullable: true),
                    TradeReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfidenceLevel = table.Column<int>(type: "int", nullable: false),
                    Profitabile = table.Column<bool>(type: "bit", nullable: true),
                    PriceAtExit = table.Column<float>(type: "real", nullable: true),
                    ClosedReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TradeRating = table.Column<int>(type: "int", nullable: true),
                    Improvements = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfitPercent = table.Column<double>(type: "float", nullable: true),
                    TargetReached = table.Column<bool>(type: "bit", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trades", x => x.TradeEntityId);
                });

            migrationBuilder.InsertData(
                table: "Trades",
                columns: new[] { "TradeEntityId", "ApplicationUserId", "AssetName", "ClosedReason", "ConfidenceLevel", "DateEntered", "DateTimeOpened", "DirectionOpened", "Improvements", "IsCrypto", "IsOpen", "Observations", "PriceAtEntry", "PriceAtExit", "ProfitPercent", "Profitabile", "SizeInUsd", "StopLoss", "Symbol", "Target", "TargetReached", "TradeRating", "TradeReason" },
                values: new object[,]
                {
                    { 1, null, "Bitcoin", "", 9, new DateTime(2024, 3, 7, 1, 35, 6, 654, DateTimeKind.Utc).AddTicks(2017), "03/01/2024", "Long", null, true, true, null, 65000.449999999997, null, null, null, 1000f, 61990f, "BTC", 70000.0, null, null, "Strong uptrend based on many factors" },
                    { 2, null, "Ethereum", "market looked topped", 9, new DateTime(2024, 3, 7, 1, 35, 6, 654, DateTimeKind.Utc).AddTicks(2025), "03/02/2024", "Long", "None", true, false, "None", 3510.4499999999998, 3900f, 10.0, true, 1000f, 3400f, "ETH", 4000.0, false, 7, "Very Strong uptrend based on many factors, ETF soon" },
                    { 3, null, "Bitcoin", "", 9, new DateTime(2024, 3, 7, 1, 35, 6, 654, DateTimeKind.Utc).AddTicks(2030), "03/01/2024", "Long", null, true, true, null, 65000.449999999997, null, null, null, 1000f, 61990f, "BTC", 70000.0, null, null, "Strong uptrend based on many factors" },
                    { 4, null, "Bitcoin", "market looked topped", 9, new DateTime(2024, 3, 7, 1, 35, 6, 654, DateTimeKind.Utc).AddTicks(2032), "03/01/2024", "Long", "None", true, true, "None", 65000.449999999997, 3900f, 10.0, true, 1000f, 61990f, "BTC", 70000.0, false, 7, "Strong uptrend based on many factors" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CryptoWatchlist");

            migrationBuilder.DropTable(
                name: "PnlTable");

            migrationBuilder.DropTable(
                name: "StockWatchlist");

            migrationBuilder.DropTable(
                name: "Trades");
        }
    }
}
