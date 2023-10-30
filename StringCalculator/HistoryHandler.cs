using StringCalculator.Persistance;
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
        private DatePicker datePicker;

        public HistoryHandler(Save save, DatePicker pick)
        {
            history = save;
            datePicker = pick;
        }

        public void Handle(string request) {

            var res = StringCalculatorClass.add(request);
            history.toFile(datePicker.GetDate()+"-"+request+"-"+res);
        }

    }
}
