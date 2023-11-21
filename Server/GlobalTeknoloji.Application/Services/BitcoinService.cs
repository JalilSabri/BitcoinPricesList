using GlobalTeknoloji.Application.Contracts.IServices;
using GlobalTeknoloji.Data.Repositories;
using GlobalTeknoloji.Domain.Models.Bitcoin;
using GlobalTeknoloji.Domain.Models.user;
using GlobalTeknoloji.Infrastructure.Utilities;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTeknoloji.Application.Services;

public class BitcoinService : IBitcoinService
{
    IBaseRepository<MarketInfo> _baseRepository;
    GTHelper? gtHelper;

    public BitcoinService(IBaseRepository<MarketInfo> baseRepository)
    {
        _baseRepository = baseRepository;
    }

    GTHelper CreateGTHelper(Exception ex)
    {
        gtHelper = new GTHelper(ex);
        return gtHelper;
    }

    public string AddBitcoinPrices(List<MarketInfo> marketInfos)
    {

        bool CheckGetBusinessRules()
        {
            //check Rules and error handeling
            return true;
        }

        try
        {
            if (CheckGetBusinessRules())
            {
                _baseRepository.Add(marketInfos);
                _baseRepository.Commit();
            }
        }
        catch (GTCustomeException GTEx)
        {
            CreateGTHelper(GTEx).SendMessage(GTEx.Message);
        }
        catch (Exception ex)
        {
            CreateGTHelper(ex).DoLog(ex.Message).SendMessage(ex.Message);
        }
        return "Row effected...";
    }

    public async Task<List<MarketInfo>> GetAllCoinsPrices()
    {
        List<MarketInfo> lstMarketInfo = null;
        bool CheckGetBusinessRules()
        {
            //check Rules and error handeling
            return true;
        }

        try
        {
            if (CheckGetBusinessRules())
            {
                //lstTrading = new List<TradingViewModel>();
                lstMarketInfo = await _baseRepository.GetAllAsync();
            }
        }
        catch (GTCustomeException GTEx)
        {
            CreateGTHelper(GTEx).SendMessage(GTEx.Message);
        }
        catch (Exception ex)
        {
            CreateGTHelper(ex).DoLog(ex.Message).SendMessage(ex.Message);
        }
        return lstMarketInfo;
    }
}
