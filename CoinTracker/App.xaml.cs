using CoinTracker.Services;
using CoinTracker.ViewModels;
using CoinTracker.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;

namespace CoinTracker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }

        public App()
        {
            string apiUrl = ConfigurationManager.AppSettings["api"]!;

            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((histContext, services) =>
                {
                    services.AddSingleton(serviceProvider =>
                    {
                        var httpClient = new HttpClient();
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
                        httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));

                        return httpClient;
                    });

                    services.AddSingleton<ICoinCapService, CoinCapService>(serviceProvider =>
                    {
                        var httpClient = serviceProvider.GetRequiredService<HttpClient>();
                        return new CoinCapService(httpClient, apiUrl);
                    });

                    services.AddSingleton<INavigationService, NavigationService>();

                    services.AddSingleton<MainWindowViewModel>();
                    services.AddSingleton<AssetsViewModel>();
                    services.AddSingleton<Func<string, AssetMarketsDataViewModel>>(serviceProvider => id =>
                    {
                        var coinCapService = serviceProvider.GetRequiredService<ICoinCapService>();
                        return new AssetMarketsDataViewModel(coinCapService, id);
                    });
                    services.AddSingleton<RatesViewModel>();
                    services.AddSingleton<ExchangesViewModel>();
                    services.AddSingleton<MarketsViewModel>();

                    services.AddSingleton<MainWindow>(serviceProvider =>
                    {
                        var viewModel = serviceProvider.GetRequiredService<MainWindowViewModel>();
                        var mainWindow = new MainWindow
                        {
                            DataContext = viewModel
                        };
                        return mainWindow;
                    });

                    services.AddSingleton<Func<Type, string, ViewModelBase>>(serviceProvider => (viewModelType, id) =>
                    {
                        if (viewModelType == typeof(AssetMarketsDataViewModel))
                        {
                            var factory = serviceProvider.GetRequiredService<Func<string, AssetMarketsDataViewModel>>();
                            return factory(id!);
                        }

                        return (ViewModelBase)serviceProvider.GetRequiredService(viewModelType);
                    });
                })
                .Build();
        }
        
        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();

            var startupForm = AppHost.Services.GetRequiredService<MainWindow>();
            startupForm.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();

            base.OnExit(e);
        }
    }

}
