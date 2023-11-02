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
        private readonly IConfigurationRoot persistance;
        private string path;
        private HistoryHandler historySaver;

        public StringController()
        {
            var persistBuilder = new ConfigurationBuilder();
            persistBuilder.AddJsonFile("./persistancesettings.json");
            persistance = persistBuilder.Build();
            path = persistance["Path"];
            historySaver = new HistoryHandler(new HistoryStorer(path), new APIDatePicker());
        }

        [HttpGet("{sum}")]
        public string Get(string sum)
        {
            historySaver.Handle(sum);
            return StringCalculatorClass.add(sum).ToString();
        }

    }
}
