using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Telephony;
using Android.Widget;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using Microsoft.Maui.Controls.Compatibility;
using MobileSecurityMonitor.Models.Rest;
using MobileSecurityMonitor.Pages;
using Newtonsoft.Json;
using Plugin.CurrentActivity;
using Plugin.Permissions;

namespace MobileSecurityMonitor
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            // Inicializandor do Plugin para Permissões/IMEI
            CrossCurrentActivity.Current.Init(this, savedInstanceState);

            // Permissões do DISPOSITIVO
            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.ReadPhoneState) != (int)Permission.Granted)
            {
                ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.ReadPhoneState }, 0);
            }

            // Permissões de LOCALIZAÇÃO
            var accessLocation = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (accessLocation != PermissionStatus.Granted)
            {
                accessLocation = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            }

            var device_id = Android.Provider.Settings.Secure.GetString(Android.App.Application.Context.ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            await SecureStorage.SetAsync("IMEI", device_id);

        }
    }
}
