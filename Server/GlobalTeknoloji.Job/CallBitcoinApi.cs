using GlobalTeknoloji.Application.Contracts.IServices;
using GlobalTeknoloji.Application.Services;
using GlobalTeknoloji.Data.Repositories;
using GlobalTeknoloji.Domain.Models;
using GlobalTeknoloji.Domain.Models.Bitcoin;
using GlobalTeknoloji.Domain.Models.user;
using GlobalTeknoloji.Job.Services;
using System.Threading;

namespace GlobalTeknoloji.Job;
public class CallBitcoinApi : BackgroundService
{
    IApiClient _apiClient;
    IServiceProvider _serviceProvider;

    public CallBitcoinApi(IApiClient apiClient , IServiceProvider serviceProvider )
    {
        _apiClient = apiClient;
        //_bitcoinService = bitcoinService;
        _serviceProvider = serviceProvider;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            List<MarketInfo> marketInfos = new List<MarketInfo>();
            var Result = _apiClient.ConnectToApi("usd");

            foreach (Market coin in Result.Markets)
            {
                marketInfos.Add(new MarketInfo
                {
                    CoinLabel = coin.Label,
                    CoinName = coin.Name,
                    CoinPrice = coin.Price
                });
            }

            using (var scope = _serviceProvider.CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<IBitcoinService>().AddBitcoinPrices(marketInfos);
            }

            await Task.Delay(10000, stoppingToken);
        }
    }
}




//protected override async Task ExecuteAsync(CancellationToken stoppingToken)
//{
//    using (StreamWriter writer = new StreamWriter($"{Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent}\\APICoinFiles\\BitCoin.txt", true))
//    {
//        //ApiClient apiClient = new ApiClient();
//        writer.AutoFlush = true;
//        writer.WriteLine("============================ START ======================================");
//        while (!stoppingToken.IsCancellationRequested)
//        {
//            var Result = _apiClient.ConnectToApi("usd");
//            writer.WriteLine(Result.Markets[0]);
//            writer.WriteLine("=========================================================");
//            await Task.Delay(2000, stoppingToken);
//        }
//    }
//}
//writer.WriteLine($"Worker running at: {DateTimeOffset.Now}");
