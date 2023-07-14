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

        public QuizDB()
        {
            
        }
        public QuizDB(string pytanie, string odpowiedz_A, string odpowiedz_B, string odpowiedz_C, string poprawnaOdpowiedz)
        {
            this.Pytanie = pytanie;
            this.A = odpowiedz_A;
            this.B = odpowiedz_B;
            this.C = odpowiedz_C;
            this.PoprawnaOdpowiedz = poprawnaOdpowiedz;
        }


    }
}
