using Quiz.Core;
using Quiz.CustomControls;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        List<QuizDB> quiz = QuizDB.LoadQuizFromDB();
        public Home()
        {
            InitializeComponent();


            LosujPytania(10);
        }

        public void LosujPytania(int howMuch)
        {
            var random = new Random();

            for (int i = 0; i < howMuch; i++)
            {
                int j = random.Next(quiz.Count);

                QuizDataHome quizDataBase = new QuizDataHome
                {
                    Question = quiz[j].Pytanie,
                    AnswerA = quiz[j].A,
                    AnswerB = quiz[j].B,
                    AnswerC = quiz[j].C,
                    MyGroupName = "odp" + j.ToString(),
                };
                quiz.Remove(quiz.ElementAt(j));
                StackPanel.Children.Add(quizDataBase);
            }

            Button button = new Button()
            {
                Content = "Sprawdz odpowiedzi",
                Width = Content.ToString().Length + 200,
                Margin = new Thickness(5,5,5,25),
                FontSize = 20,
            };

            StackPanel.Children.Add(button);
        }
    }
}
