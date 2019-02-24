using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using SQLite;
using UIKit;
using WaguiApp.Data;
using WaguiApp.iOS.Data;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteIOS))]
namespace WaguiApp.iOS.Data
{
    public class SQLiteIOS : ISQLite
    {
        public SQLiteIOS() { }
        public SQLiteConnection GetConnection()
        {
            var fileName = "wagui.db3";
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var librairyPath = Path.Combine(documentPath, "..", "Librairy");
            var path = Path.Combine(librairyPath, fileName);
            var connection = new SQLite.SQLiteConnection(path);
            return connection;
        }
    }
}