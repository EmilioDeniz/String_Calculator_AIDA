using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StringCalculator
{
    public class HistoryHandler
    {
        private Save history;
        private String date;

        public HistoryHandler(Save save)
        {
            history = save;
        }

        public void Handle(string request) {

            var res = StringCalculatorClass.add(request);
            history.toFile(this.date+"-"+request+"-"+res);
        }

        public void setDate(string date) {
            this.date = date;
        }
    }
}
