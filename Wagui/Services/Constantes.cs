using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Wagui.Services
{
    public class Constantes
    {
        public static bool isDev = true;

        public static Color BackgroundColor = Color.FromRgb(58, 153, 215);
        public static Color MainTextColor = Color.White;

        public static int LoginIconHeight = 70;

        /* ------------------------------------Api URL--------------------------------- */

        public static string accountApiUrl = "http://www.waguispace.com/mobile/account_api/";

        public static string agriApiUrl = "http://www.waguispace.com/mobile/agriculteur_api/";



        public static string NoInternetText = "Vous n'êtes pas connecté à internet! Veuillez vérifier votre connexion";
    }
}
