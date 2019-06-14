using System;
using Xamarin.Forms;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;
using Wagui.Views;
using Wagui.Views.Agriculteur;
using Wagui.Views.Agronome;
using Wagui.Views.Inscription;
using Wagui.Views.Agriculteur.VentePage;
using Wagui.Views.Agriculteur.AchatPage;

using Wagui.Services;

namespace Wagui
{
    public partial class App : Application
    {
        private static Label labelScreen;
        private static bool hasInternet;
        private static Page currentPage;
        private static Timer timer;
        private static bool noInterShow;

        public static bool IsUserLoggedIn { get; set; }
        public App()
        {
            InitializeComponent();

            if (!Current.Properties.ContainsKey("user_id"))
            {
                MainPage = new NavigationPage(new AgriculteurHome());
            }
            else
            {
                MainPage = new NavigationPage(new AgriculteurHome());
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
       
        public static void StartCheckIfInternet(Label label, Page page)
        {
            labelScreen = label;
            label.Text = Constantes.NoInternetText;
            label.IsVisible = false;
            hasInternet = true;
            currentPage = page;
            if (timer == null)
            {
                timer = new Timer((e) =>
                {
                    CheckIfInternetOvertime();
                }, null, 10, (int)TimeSpan.FromSeconds(3).TotalMilliseconds);
            }
        }

        private static void CheckIfInternetOvertime()
        {
            var networkConnnection = DependencyService.Get<INetworkConnection>();
            networkConnnection.CheckNetworkConnection();
            if (!networkConnnection.IsConnected)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    if (hasInternet)
                    {
                        if (!noInterShow)
                        {
                            hasInternet = false;
                            labelScreen.IsVisible = true;
                            await ShowDisplayAlert();
                        }
                    }
                });
            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    hasInternet = true;
                    labelScreen.IsVisible = false;
                });
            }
        }
        public static bool CheckIfInternet()
        {
            var networkConnnection = DependencyService.Get<INetworkConnection>();
            networkConnnection.CheckNetworkConnection();
            return networkConnnection.IsConnected;
        }

        public static async Task<bool> CheckIfInternetAlert()
        {
            var networkConnnection = DependencyService.Get<INetworkConnection>();
            networkConnnection.CheckNetworkConnection();
            if (!networkConnnection.IsConnected)
            {
                if (!noInterShow)
                {
                    await ShowDisplayAlert();
                }
                return false;
            }
            return true;
        }


        private static async Task ShowDisplayAlert()
        {
            noInterShow = false;
            await currentPage.DisplayAlert("Internet", "Vous n'êtes pas connectez à internet, veuillez ressayer", "Oke");
            noInterShow = false;
        }

    }
}
