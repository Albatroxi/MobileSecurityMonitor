namespace MobileSecurityMonitor
{
    public partial class App : Application
    {
        private CancellationTokenSource _cts;
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            var impTarefas = new Services.TarefasPeriodicas();

            _cts = new CancellationTokenSource();
            Task.Run(() => impTarefas.IniciarTarefasPeriodicas(_cts.Token));

        }

        protected override void OnSleep()
        {
            // Para
            //BackgroundAggregatorService.StopBackgroundService();
        }

        protected override void OnResume()
        {
            // Inicia Novamente
            //BackgroundAggregatorService.StartBackgroundService();
        }
    }
}
