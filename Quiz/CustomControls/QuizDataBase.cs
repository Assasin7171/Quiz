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

namespace Quiz.CustomControls
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Quiz.CustomControls"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Quiz.CustomControls;assembly=Quiz.CustomControls"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:QuizDataBase/>
    ///
    /// </summary>
    public class QuizDataBase : Control
    {
        static QuizDataBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(QuizDataBase), new FrameworkPropertyMetadata(typeof(QuizDataBase)));
        }



        public string PoprawnaOdpowiedz
        {
            get { return (string)GetValue(PoprawnaOdpowiedzProperty); }
            set { SetValue(PoprawnaOdpowiedzProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PoprawnaOdpowiedz.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PoprawnaOdpowiedzProperty =
            DependencyProperty.Register("PoprawnaOdpowiedz", typeof(string), typeof(QuizDataBase), new PropertyMetadata(string.Empty));



        public string Question
        {
            get { return (string)GetValue(QuestionProperty); }
            set { SetValue(QuestionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Question.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty QuestionProperty =
            DependencyProperty.Register("Question", typeof(string), typeof(QuizDataBase), new PropertyMetadata(string.Empty));



        public string AnswerA
        {
            get { return (string)GetValue(AnswerAProperty); }
            set { SetValue(AnswerAProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AnswerA.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AnswerAProperty =
            DependencyProperty.Register("AnswerA", typeof(string), typeof(QuizDataBase), new PropertyMetadata(string.Empty));


        public string AnswerB
        {
            get { return (string)GetValue(AnswerBProperty); }
            set { SetValue(AnswerBProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AnswerA.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AnswerBProperty =
            DependencyProperty.Register("AnswerB", typeof(string), typeof(QuizDataBase), new PropertyMetadata(string.Empty));


        public string AnswerC
        {
            get { return (string)GetValue(AnswerCProperty); }
            set { SetValue(AnswerCProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AnswerA.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AnswerCProperty =
            DependencyProperty.Register("AnswerC", typeof(string), typeof(QuizDataBase), new PropertyMetadata(string.Empty));






        public Brush ForgroundColorA
        {
            get { return (Brush)GetValue(ForgroundColorAProperty); }
            set { SetValue(ForgroundColorAProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ForgroundColorA.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ForgroundColorAProperty =
            DependencyProperty.Register("ForgroundColorA", typeof(Brush), typeof(QuizDataBase), new PropertyMetadata(Brushes.White));


        public Brush ForgroundColorB
        {
            get { return (Brush)GetValue(ForgroundColorBProperty); }
            set { SetValue(ForgroundColorBProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ForgroundColorB.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ForgroundColorBProperty =
            DependencyProperty.Register("ForgroundColorB", typeof(Brush), typeof(QuizDataBase), new PropertyMetadata(Brushes.White));



        public Brush ForgroundColorC
        {
            get { return (Brush)GetValue(ForgroundColorCProperty); }
            set { SetValue(ForgroundColorCProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ForgroundColorC.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ForgroundColorCProperty =
            DependencyProperty.Register("ForgroundColorC", typeof(Brush), typeof(QuizDataBase), new PropertyMetadata(Brushes.White));



    }
}
