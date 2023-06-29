using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Quiz.Core
{
    public class QuizDB
    {
        public int ID { get; set; }
        public string? Pytanie { get; set; }
        public string? A { get; set; }
        public string? B { get; set; }
        public string? C { get; set; }
        public string? PoprawnaOdpowiedz { get; set; }


        DBConnection DBConnection = new DBConnection();

        public QuizDB()
        {
            
        }
        public QuizDB(int id, string pytanie, string odpowiedz_A, string odpowiedz_B, string odpowiedz_C, string poprawnaOdpowiedz)
        {
            this.ID = id;
            this.Pytanie = pytanie;
            this.A = odpowiedz_A;
            this.B = odpowiedz_B;
            this.C = odpowiedz_C;
            this.PoprawnaOdpowiedz = poprawnaOdpowiedz;
        }

        public static List<QuizDB> LoadQuizFromDB()
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
                            Convert.ToInt32(dataTable.Rows[i]["ID"]),
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
