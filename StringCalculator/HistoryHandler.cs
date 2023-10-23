using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class HistoryHandler
    {
        private History history = new History();

        public void handle(string request) {
            history.saveHistory(request);
        }

        public string getRequest(string id)
        {
            var response = history.getRequest(id);
            return response.ToString();
        }
    }
}
