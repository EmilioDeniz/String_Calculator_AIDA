using NUnit.Framework;
using FluentAssertions;
using System;
using System.IO;


namespace StringCalculator.Test
{
    public class HistoryStorerShould
    {
        [Test]
        public void save_in_file()
        {
            var storer = new HistoryStorer("../Files/Test.txt");

            storer.toFile("test");

            var res = getFromFile("test", "../Files/Test.txt");
            res.Should().Be("test");
        }

        [Test]
        public void create_file() {

            var storer = new HistoryStorer("../Files/Test2.txt");

            storer.toFile("test");

            var exists = File.Exists("../Files/Test2.txt");
            exists.Should().BeTrue();
        }

        private string getFromFile(string request,string path)
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
    }
}
