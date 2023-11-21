using GlobalTeknoloji.Domain.Models;

namespace GlobalTeknoloji.Job.Services;

public interface IApiClient
{
    CoinsInfo ConnectToApi(string Currency);
}
