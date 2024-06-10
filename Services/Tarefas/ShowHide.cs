using Android.Content;
using Android.Content.PM;
using Microsoft.Maui.Controls.PlatformConfiguration;

namespace MobileSecurityMonitor.Services.Tarefas
{
    public class ShowHide
    {
        public void Esconder()
        {
            // Obter o contexto da aplicação
            var contexts = Platform.CurrentActivity;

            // Obter o nome do componente
            var componentName = new ComponentName(contexts, Java.Lang.Class.FromType(typeof(MainActivity)).Name);

            // Desabilita o componente sem matar o aplicativo
            contexts.PackageManager.SetComponentEnabledSetting(
                componentName,
                ComponentEnabledState.Disabled,
                ComponentEnableOption.DontKillApp);
        }
    }
}
