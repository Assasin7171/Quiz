using Quiz.Core;
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
        public QuestionsAndAnswers()
        {
            InitializeComponent();

            dataGrid.ItemsSource =  quiz;

            SprawdzKtoraPoprawna();
        }

        public void SprawdzKtoraPoprawna()
        {
            //iteruje przez wszystkie poprawne odpowiedzi jednoczesnie
            //sprawdzajac ktora odpowiedz jest poprawna i zmieniając jej
            //kolor na zielony
            foreach(var item in quiz)
            {
                //MessageBox.Show(item.PoprawnaOdpowiedz);
                switch (item.PoprawnaOdpowiedz)
                {
                    case "A":
                        this.odpA.Foreground = Brushes.Red;
                        break;
                    case "B":
                        this.odpB.Foreground = Brushes.Red;
                        break;
                    case "C":
                        this.odpC.Foreground = Brushes.Red;
                        break;
                    default:
                        break;
                }
            }
            
        }

        private void DataGridTextColumn_Selected(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello World");
        }
    }
}
