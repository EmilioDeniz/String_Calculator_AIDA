using NUnit.Framework;
using NSubstitute;
using FluentAssertions;
using System;

namespace StringCalculator.Test
{
    public class HistoryHandlerShould
    {
        [TestCase("3,5,7","15")]
        public void save_in_history_with_format(string sum, string res)
        {
            var action = Substitute.For<Save>();
            var historySaver = new StringCalculatorHandler(action);

            historySaver.Handle(sum);

            action.Received(1).toFile(sum+"-"+res);
        }
    }

    public class StringCalculatorHandler
    {
        public Save save;
        public StringCalculatorHandler(Save save)
        {
            this.save = save;
        }
        public void Handle(string data)
        {
            var res = StringCalculatorClass.add(data);
            save.toFile(data + "-" + res.ToString());
        }
    }
}
