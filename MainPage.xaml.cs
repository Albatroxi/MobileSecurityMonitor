using MobileSecurityMonitor.Services;

namespace MobileSecurityMonitor
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            //BindingContext = new ViewModel.MainViewModel();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            var teste = new Services.Tarefas.ProprietariosServices();

            await teste.carregaProprietarios();
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);

        }
    }

}
