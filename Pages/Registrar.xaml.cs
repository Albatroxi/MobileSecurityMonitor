
namespace MobileSecurityMonitor.Pages;

public partial class Registrar : ContentPage
{    
    int count = 0;
    public Registrar(string IMEi)
	{
		InitializeComponent();

        imeiEntry.Placeholder = IMEi;
    }

    private async void onClickReg(object sender, EventArgs e)
    {
        var goDispositivo = new Services.Tarefas.Dispositivo();

        var meuIMEI = await SecureStorage.GetAsync("IMEI");

        await SecureStorage.SetAsync("CPF", cpfEntry.Text);


        int.TryParse(cpfEntry.Text, out int cpfInt);

        //var TESTA = cpfEntry.Placeholder;

        //Console.WriteLine("testeIMEI: " + meuIMEI);
        //Console.WriteLine("PLACEHOLDER CPF: " + cpfEntry.Text);

        goDispositivo.checkAndRegister(meuIMEI, cpfInt);

    }
}