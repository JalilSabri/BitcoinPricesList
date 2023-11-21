using GlobalTeknoloji.Data.Repositories;
using GlobalTeknoloji.Application.Contracts.IServices;
using GlobalTeknoloji.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using GlobalTeknoloji.Job.Services;

namespace GlobalTeknoloji.IoC;
public class DependenciesInjection
{
    public static void InjectServices(IServiceCollection service)
    {

        #region .:| Data |:.

        service.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        #endregion

        #region .:| Application |:.

        service.AddScoped<IUserService, UserService>();
        service.AddScoped<IBitcoinService, BitcoinService>();

        #endregion

        #region .:| Job |:.

        service.AddSingleton<IApiClient, ApiClient>();

        #endregion

    }
}
