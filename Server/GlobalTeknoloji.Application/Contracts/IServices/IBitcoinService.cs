using GlobalTeknoloji.Domain.Models.Bitcoin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTeknoloji.Application.Contracts.IServices;

public interface IBitcoinService
{
    public string AddBitcoinPrices(List<MarketInfo> marketInfos);

    public Task<List<MarketInfo>> GetAllCoinsPrices();
}
