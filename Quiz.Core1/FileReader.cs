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

        public string LoadData()
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
