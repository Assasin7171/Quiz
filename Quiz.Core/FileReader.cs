using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Core
{
    public class FileReader
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
            StreamReader streamReader = new StreamReader(filePath);
            fileContent = streamReader.ReadToEnd();

            return fileContent;
        }
    }
}
