using NUnit.Framework;
using FluentAssertions;
using NSubstitute;
using System;
using System.IO;
using StringCalculator.Persistance;


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

        [Test]
        public void save_current_date() {
            var dateTime = Substitute.For<DatePicker>();
            var handler = new HistoryHandler(new HistoryStorer("./Files/test.txt"), dateTime);
            handler.Handle("1,3,5");
            dateTime.Received(1).GetDate();
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
