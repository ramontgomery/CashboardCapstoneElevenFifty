using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cashboard3._5.Data.Entities;
using Models.TradeModels;
using Models.WatchlistModels;

namespace Models.Configurations
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration() 
        {
            CreateMap<TradeEntity, NewClosedTrade>().ReverseMap();
            CreateMap<TradeEntity, NewTrade>().ReverseMap();
            CreateMap<TradeEntity, NewOpenTrade>().ReverseMap();
            CreateMap<TradeEntity, CloseTrade>().ReverseMap();
            CreateMap<TradeEntity, EditClosedTrade>().ReverseMap();
            CreateMap<TradeEntity, EditTrade>().ReverseMap();
            CreateMap<EditTrade, TradeDetail>().ReverseMap();
            CreateMap<TradeEntity, TradeDetail>().ReverseMap();
            CreateMap<StockWatchlistEntity, AddWatchlistItemStock>().ReverseMap();
            CreateMap<CryptoWatchlistEntity, AddWatchlistItem>().ReverseMap();
            CreateMap<StockWatchlistEntity, UpdateStockWatchlistItem>().ReverseMap();
            CreateMap<CryptoWatchlistEntity, UpdateCryptoWatchlistItem>().ReverseMap();
            CreateMap<StockWatchlistEntity, RemoveWatchlistItem>().ReverseMap();
            CreateMap<CryptoWatchlistEntity, RemoveWatchlistItem>().ReverseMap();
            CreateMap<StockWatchlistEntity, StockWatchlistDetail>().ReverseMap();
            CreateMap<CryptoWatchlistEntity, CryptoWatchlistDetail>().ReverseMap();
            CreateMap<CryptoWatchlistEntity, GenericWatchlistDetail>().ReverseMap();
            CreateMap<StockWatchlistEntity, GenericWatchlistDetail>().ReverseMap();


        }
    }
}
