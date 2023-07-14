using Microsoft.Win32;
using Quiz.Core;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        QuizDB quizDB = new QuizDB();
        FileHandling fileReader = new FileHandling();
        public Admin()
        {
            InitializeComponent();
        }

        private void Btn_Add_Questions(object sender, RoutedEventArgs e)
        {
            List<QuizDB> data = fileReader.PrepareDataForUse(fileReader.LoadDataFromFileToDB());

            foreach(var item in data)
            {
                DBConnection.SaveDataInDB(item);
            }
        }

        private void Btn_Show_Questions_Click(object sender, RoutedEventArgs e)
        {
            QuestionsAndAnswers questions = new QuestionsAndAnswers();
            NavigationService.Navigate(questions);
        }
    }
}
