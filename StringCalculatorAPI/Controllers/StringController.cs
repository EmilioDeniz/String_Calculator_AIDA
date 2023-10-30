using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StringCalculator;

namespace StringCalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StringController : ControllerBase
    {

        HistoryHandler historySaver = new HistoryHandler(new HistoryStorer("../Files/History.txt"));

        [HttpGet("{sum}")]
        public string Get(string sum)
        {
            historySaver.setDate(DateTime.Now.ToString());
            historySaver.Handle(sum);
            return StringCalculatorClass.add(sum).ToString();
        }

    }
}
