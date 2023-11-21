using GlobalTeknoloji.Application.Contracts.IServices;
using GlobalTeknoloji.Domain.Models.Bitcoin;
using GlobalTeknoloji.Job;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GlobalTeknoloji.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class BitcoinsController : ControllerBase
{
    IBitcoinService _bitcoinService;

    public BitcoinsController(IBitcoinService bitcoinService)
    {
        _bitcoinService = bitcoinService;
    }

    [ResponseCache(Duration = 10)]
    public async Task<List<MarketInfo>> Get()
    {
        return await _bitcoinService.GetAllCoinsPrices();
    }

}
