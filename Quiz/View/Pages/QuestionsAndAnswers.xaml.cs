using Quiz.Core;
using Quiz.CustomControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Quiz.View.Pages
{
    /// <summary>
    /// Interaction logic for QuestionsAndAnswers.xaml
    /// </summary>
    public partial class QuestionsAndAnswers : Page
    {

        QuizDB quizDB = new QuizDB();
        List<QuizDB> quiz = QuizDB.LoadQuizFromDB();

        //Custom Control
        
        public QuestionsAndAnswers()
        {
            InitializeComponent();


            WyswietlDane();
        }
        private void WyswietlDane()
        {
            foreach (var item in quiz)
            {
                var quizG = new QuizDataBase()
                {
                    AnswerA = item.A,
                    AnswerB = item.B,
                    AnswerC = item.C,
                    Question = item.Pytanie,
                    PoprawnaOdpowiedz = item.PoprawnaOdpowiedz
                };

                SprawdzKtoraPoprawna(quizG);
                quizG.BorderBrush = Brushes.Black;
                quizG.BorderThickness = new Thickness(0,0,0,1);
                quizG.Margin = new Thickness(0,0,0,3);
                

                stackPanelData.Children.Add(quizG);
            }
        }


        public void SprawdzKtoraPoprawna(QuizDataBase quiz)
        {
            //iteruje przez wszystkie poprawne odpowiedzi jednoczesnie
            //sprawdzajac ktora odpowiedz jest poprawna i zmieniając jej
            //kolor na zielony
            //MessageBox.Show(quiz.PoprawnaOdpowiedz);
            switch (quiz.PoprawnaOdpowiedz)
            {
                case "A":
                    quiz.ForgroundColorA = Brushes.DarkSeaGreen;
                    break;
                case "B":
                    quiz.ForgroundColorB = Brushes.DarkSeaGreen;
                    break;
                case "C":
                    quiz.ForgroundColorC = Brushes.DarkSeaGreen;
                    break;
                default:
                    break;
            }

        }


    }
}
