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
        private string path;
        private HistoryHandler historySaver;

        public StringController(HistoryHandler handler)
        {
            historySaver = handler;
        }

        [HttpGet("{sum}")]
        public string Get(string sum)
        {
            historySaver.Handle(sum);
            return StringCalculatorClass.add(sum).ToString();
        }

    }
}
