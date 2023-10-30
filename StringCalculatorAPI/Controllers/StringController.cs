using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StringCalculator;
using StringCalculator.Persistance;

namespace StringCalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StringController : ControllerBase
    {

        HistoryHandler historySaver = new HistoryHandler(new HistoryStorer("../Files/History.txt"),new APIDatePicker());

        [HttpGet("{sum}")]
        public string Get(string sum)
        {
            historySaver.Handle(sum);
            return StringCalculatorClass.add(sum).ToString();
        }

    }
}
