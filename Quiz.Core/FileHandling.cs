using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Quiz.Core
{
    public class FileHandling
    {
        string filePath = string.Empty;
        string fileContent = string.Empty;

        /// <summary>
        /// Ta Funkcja pobiera z wskazanego folderu plik/pliki.
        /// </summary>
        /// <returns>Zawartość pobranych plików</returns>
        public string LoadDataFromFileToDB()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "*.csv|*.csv";
            ofd.RestoreDirectory = true;

            bool? result = ofd.ShowDialog();
            if (result == true)
            {
                filePath = ofd.FileName;
            }

            if(filePath != string.Empty)
            {
                try
                {
                    StreamReader streamReader = new StreamReader(filePath);
                    fileContent = streamReader.ReadToEnd();
                }
                catch { }
            }

            return fileContent;
        }
        public List<QuizDB> PrepareDataForUse(string fileName)
        {
            var data = fileName.Split("\n");
            List<QuizDB> newesQuizData = new List<QuizDB>();
            //MessageBox.Show(data[0].ToString());
            for (int i = 1; i <= data.Length-1; i++)
            {
                var _ = data[i].Split(',');
                
                if(_.Length >= 6)
                {
                    //MessageBox.Show(item);
                    QuizDB quiz = new QuizDB
                    {
                        Pytanie = _[1].ToString(),
                        A = _[2].ToString(),
                        B = _[3].ToString(),
                        C = _[4].ToString(),
                        PoprawnaOdpowiedz = _[5].ToString().Replace("\r", "")
                    };

                    newesQuizData.Add(quiz);
                }
                
            }
            return newesQuizData;
            
        }

    }
}
