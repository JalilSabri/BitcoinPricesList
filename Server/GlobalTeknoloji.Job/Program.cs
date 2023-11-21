using GlobalTeknoloji.Job;
using GlobalTeknoloji.Job.Configuration;

IHost host = Host.CreateDefaultBuilder(args).ConfigureServices(services => { services.AddHostedService<CallBitcoinApi>(); }).Build();

host.Run();
