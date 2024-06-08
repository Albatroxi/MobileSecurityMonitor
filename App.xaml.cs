using MobileSecurityMonitor.Models.Rest;
using Newtonsoft.Json;

namespace MobileSecurityMonitor
{
    public partial class App : Application
    {
        private CancellationTokenSource _cts;
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            // Chama o método assíncrono
            InitializeAppAsync();
        }

        private async void InitializeAppAsync()
        {
            var testeIMEI = await SecureStorage.GetAsync("IMEI");

            MainPage = new Pages.Registrar(testeIMEI);
        }
        protected override void OnStart()
        {
            var impTarefas = new Services.TarefasPeriodicas();

            _cts = new CancellationTokenSource();
            //Task.Run(() => impTarefas.IniciarTarefasPeriodicas(_cts.Token));

        }

        protected override void OnSleep()
        {
            // Para
            //BackgroundAggregatorService.StopBackgroundService();
        }

        protected override void OnResume()
        {
            var impTarefas = new Services.TarefasPeriodicas();

            _cts = new CancellationTokenSource();
            Task.Run(() => impTarefas.IniciarTarefasPeriodicas(_cts.Token));
        }
    }
}
