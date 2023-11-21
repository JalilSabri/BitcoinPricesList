using Microsoft.Extensions.Options;
using GlobalTeknoloji.Job.Configuration;
using RestSharp;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Net;
using GlobalTeknoloji.Domain.Models;
using Microsoft.Extensions.Configuration;

namespace GlobalTeknoloji.Job.Services;
public class ApiClient : IApiClient
{
    //private readonly ServiceSettings _settings;

    //public ApiClient(IOptions<ServiceSettings> settings)
    //{
    //    _settings = settings.Value;
    //}

    //private readonly IConfigurationSection _settings;

    //public ApiClient(IConfigurationSection settings)
    //public ApiClient()
    //{
    //    _settings = settings;
    //    IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    //    var _settings = configuration.GetSection("ServiceSettings");
    //}

    IConfiguration _configuration;
    public ApiClient(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public CoinsInfo ConnectToApi(string currency)
    {
        _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        var client = new RestClient($"{_configuration["ServiceSettings:CoinsPriceUrl"]}/ticker");//CoinsPriceUrl

        var request = new RestRequest();
        request.Method = Method.Get;

        request.RequestFormat = DataFormat.Json;

        request.AddParameter("key", _configuration["ServiceSettings:ApiKey"], ParameterType.GetOrPost);// _settings.ApiKey
        request.AddParameter("label", "ethbtc-ltcbtc-btcbtc", ParameterType.GetOrPost);
        request.AddParameter("fiat", currency, ParameterType.GetOrPost);

        var response = client.Get(request);

        var markets = JsonSerializer.Deserialize<CoinsInfo>(response.Content);

        return markets;
    }

}
