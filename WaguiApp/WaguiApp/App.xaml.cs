using System;
using WaguiApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading;
using System.Threading.Tasks;
using WaguiApp.Models;
using WaguiApp.Data;
using WaguiApp.Views.Agriculteur;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace WaguiApp
{
    public partial class App : Application
    {
        private static Label labelScreen;
        private static bool hasInternet;
        private static Page currentPage;
        private static Timer timer;
        private static bool noInterShow;
        //static UserDatabase userDatabase;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginView());
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

        //..................................................Internet connection................................

        public static void StartCheckIfInternet(Label label, Page page)
        {
            labelScreen = label;
            label.Text = Constants.NoInternetText;
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
        public static async Task<bool> CheckIfInternet()
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

       /* public static UserDatabase UserDatabase
        {
            get
            {
                if(userDatabase == null)
                {
                    userDatabase = new UserDatabase();
                }
                return userDatabase;
            }
        }*/
    }
}
