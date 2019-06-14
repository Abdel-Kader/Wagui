using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Wagui.Droid
{
    [Activity(Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true)]
    class SplashActivity: Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

        }

        protected override void OnResume()
        {
            base.OnResume();
            Task startUpwork = new Task(() => { SimulateStartUp(); });
            startUpwork.Start();
        }

        async void SimulateStartUp()
        {
            await Task.Delay(1500);
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}