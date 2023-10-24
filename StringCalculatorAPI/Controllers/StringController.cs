using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StringCalculator;

namespace StringCalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StringController : ControllerBase
    {

        StringCalculatorClass calculator = new StringCalculatorClass();
        HistoryHandler historyHandler = new HistoryHandler();

        [HttpGet("{sum}")]
        public string Get(string sum)
        {
            DateTime now = DateTime.Now;
            var res= calculator.add(sum).ToString();
            historyHandler.handle("Request done at "+now+" with the numbers "+sum+ " with result "+res);
            return res; 
        }

    }
}
