using System.IO;
using System;

namespace StringCalculator
{
    public class HistoryStorer:Save
    {
        private string folder;
        private string path;


        public HistoryStorer(string pathGiven) {
            path = pathGiven;
            folder = Path.GetDirectoryName(path);
        }

        public void toFile(string request)
        {
            initFile();
            using (StreamWriter writer = new StreamWriter(path,true))
            {
                writer.Write(request+"\n");  
            }
        }

        //Podría ser útil, pero no creo que sea necesario para lo que se nos pide inicialmente
        public void loadHistory(string request)
        {

        }
        
        private void initFile()
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
                File.Create(path).Close();
            }
            else
            {
                if (!File.Exists(path))
                {
                    File.Create(path).Close();
                }
            }
        }
    }
}
