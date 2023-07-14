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
        List<QuizDB> quiz = DBConnection.LoadDataFromDB();
        List<QuizDB> quizCopy = new List<QuizDB>();
        public Home()
        {
            InitializeComponent();


            LosujPytania(10);
        }

        public void LosujPytania(int howMuch)
        {

            if(quiz.Count > 0)
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
                        MyGroupName = "odp" + i.ToString(),
                    };


                    quizCopy.Add(quiz[j]);
                    quiz.Remove(quiz.ElementAt(j));


                    StackPanel.Children.Add(quizDataBase);
                }

                Button button = new Button()
                {
                    Content = "Sprawdz odpowiedzi",
                    Width = Content.ToString().Length + 200,
                    Margin = new Thickness(5, 5, 5, 25),
                    FontSize = 20,
                };
                button.Click += new RoutedEventHandler(Sprawdz);

                StackPanel.Children.Add(button);
            }
            else
            {
                MessageBox.Show("Baza danych jest pusta.");
            }
            
        }
        public void Sprawdz(object sender, RoutedEventArgs e)
        {
            var radioButtons = FindVisualChildren<RadioButton>(StackPanel);
            int i = 0;
            int score = 0;
            bool isGood = false;

            foreach (var radioButton in radioButtons)
            {
                if (radioButton.IsChecked == true)
                {
                    string selectedAnswer = radioButton.Content.ToString();
                    string correctAnswer = quizCopy[i].PoprawnaOdpowiedz;

                    if (selectedAnswer == correctAnswer)
                    {
                        score++;
                        //MessageBox.Show($"Poprawna odpowiedź na pytanie \n{quizCopy[i].Pytanie}");
                    }
                    else
                    {
                        //MessageBox.Show($"Wybrana przez ciebie odpowiedz nie jest poprawna do pytania \n{quizCopy[i].Pytanie}");
                    }
                    i++;
                }
            }

            //końcowo będzie otwierać się nowa strona z podsumowaniem
            MessageBox.Show($"Ilość zdobytych punktów to: \n{score}");
        }
        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject parent) where T : DependencyObject
        {
            var count = VisualTreeHelper.GetChildrenCount(parent);
            for (var i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is T t)
                {
                    yield return t;
                }

                foreach (var childOfChild in FindVisualChildren<T>(child))
                {
                    yield return childOfChild;
                }
            }
        }
    }
}
