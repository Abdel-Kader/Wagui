using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace WaguiApp.Models
{
    public class Constants
    {
        public static bool isDev = true;

        public static Color BackgroundColor = Color.FromRgb(58, 153, 215);
        public static Color MainTextColor = Color.White;

        public static int LoginIconHeight = 70;


        public static string ApiUrl = "https://wagui.000webhostapp.com/V1/";

        public static string NoInternetText = "Vous n'êtes pas connecté à internet! Veuillez vérifier votre connexion";
        public static string settingsScreenTitle = "Paramètre";
    }
}
