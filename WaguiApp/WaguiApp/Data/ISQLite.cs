using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WaguiApp.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
    
}
