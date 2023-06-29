using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Core
{
    public class DBConnection
    {
        static string dbPath = @"DataBase/QuizDB.db";
        public static SQLiteConnection SQLiteConnection = new SQLiteConnection("Data Source = " + dbPath);

        public void OpenConnection()
        {
            if(SQLiteConnection.State != System.Data.ConnectionState.Open)
            {
                SQLiteConnection.Open();
            }
        }
        public void CloseConnection()
        {
            if(SQLiteConnection.State == System.Data.ConnectionState.Closed)
            {
                SQLiteConnection.Close();
            }
        }
    }
}
