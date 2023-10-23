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

        [HttpGet("{sum}")]
        public string Get(string sum)
        {
            return calculator.add(sum).ToString(); ;
        }

    }
}
