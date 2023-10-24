using System.IO;
using System;

namespace StringCalculator
{
    internal class History
    {
        string folder = "../Files/";
        string path = "../Files/History.txt";

        internal void saveHistory(string request)
        {
            initFile();
            using (StreamWriter writer = new StreamWriter(path,true))
            {
                writer.Write(request+"\n");  
            }
        }

        //Podría ser útil, pero no creo que sea necesario para lo que se nos pide inicialmente
        internal void loadHistory(string request)
        {

        }
        public string getRequest(string request)
        {
            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line == request)
                        {
                            return line;
                        }
                    }
                }

                return "";
            }
            else
            {
                return "";
                throw new FileNotFoundException(path);
            }
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
