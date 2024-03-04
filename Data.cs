using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Collector_CSharp
{
    static class Data
    {
        /// <summary>
        /// Save data to a file
        /// </summary>
        /// <param name="data"></param>
        public static void SaveData(string data)
        {
            string[] lines = data.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            string? path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            System.IO.Directory.CreateDirectory(path + @"\Data");
            
            System.IO.File.WriteAllLines(path + @"\Data\data.txt", lines);
            //OpenData();
        }

        /// <summary>
        /// Open the data file
        /// </summary>
        public static void OpenData()
        {
            string? path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            System.Diagnostics.Process.Start(path + @"\Data\data.txt");
        }

    }
}
