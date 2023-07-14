using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Core
{
    public class DBConnection
    {
        FileHandling fileHandling = new();
        static string dbPath = @"DataBase/QuizDB.db";
        public static SQLiteConnection SQLiteConnection = new SQLiteConnection("Data Source = " + dbPath);
        #region useles function
        public void OpenConnection()
        {
            if (SQLiteConnection.State != System.Data.ConnectionState.Open)
            {
                SQLiteConnection.Open();
            }
        }
        public void CloseConnection()
        {
            if (SQLiteConnection.State == System.Data.ConnectionState.Closed)
            {
                SQLiteConnection.Close();
            }
        }
        #endregion

        public static void SaveDataInDB(QuizDB quizDB)
        {
            var quarry = $"INSERT INTO \"main\".\"Quiz\"" +
                "(\"Pytanie\", \"Odpowiedz_A\", \"Odpowiedz_B\", \"Odpowiedz_C\", \"PoprawnaOdpowiedz\")" +
                $"VALUES ('{quizDB.Pytanie}', '{quizDB.A}', '{quizDB.B}', '{quizDB.C}', '{quizDB.PoprawnaOdpowiedz}');";


            SQLiteCommand liteCommand = new SQLiteCommand(quarry, SQLiteConnection);
            SQLiteConnection.Open();
            liteCommand.ExecuteNonQuery();
            SQLiteConnection.Close();
        }
        public static List<QuizDB> LoadDataFromDB()
        {
            List<QuizDB>? listOfQuestions = new List<QuizDB>();

            var quarry = "SELECT * FROM quiz";

            using (SQLiteCommand command = new SQLiteCommand(quarry, DBConnection.SQLiteConnection))
            {
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        //MessageBox.Show(dataTable.Rows[i]["Pytanie"].ToString());
                        QuizDB quiz = new(
                            dataTable.Rows[i]["Pytanie"].ToString(),
                            dataTable.Rows[i]["Odpowiedz_A"].ToString(),
                            dataTable.Rows[i]["Odpowiedz_B"].ToString(),
                            dataTable.Rows[i]["Odpowiedz_C"].ToString(),
                            dataTable.Rows[i]["PoprawnaOdpowiedz"].ToString()
                            );
                        listOfQuestions.Add(quiz);

                    }
                }
            }

            return listOfQuestions;
        }
    }
}
