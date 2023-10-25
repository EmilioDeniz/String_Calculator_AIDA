using FluentAssertions;
using NUnit.Framework;
using System;

namespace StringCalculator.Test
{
    public class StringCalculatorShould{

        StringCalculatorClass calculator;
        HistoryHandler historyHandler;

        [SetUp]
        public void Setup() {
            calculator = new StringCalculatorClass();
            historyHandler = new HistoryHandler();
        }

        [Test]
        public void return_0_on_empty_string(){
            
            int res = calculator.add("");

            res.Should().Be(0);
        }

        [Test]
        public void return_same_number_on_one_number(){

            int res = calculator.add("1");
            
            res.Should().Be(1);
        }

        [Test]
        public void return_sum_on_two_values(){

            int res = calculator.add("1,2");

            res.Should().Be(3);
        }

        [Test]
        public void return_sum_on_many_values(){
            
            int res = calculator.add("1,2,3,4,5");

            res.Should().Be(15);
        }

        [Test]
        public void ignore_new_Lines(){

            int res = calculator.add("1\n2\n3\n4\n5");

            res.Should().Be(15);
        }

        [Test]
        public void ignore_new_lines_and_see_commas(){
 
            int res = calculator.add("1\n2\n3,4,5");

            res.Should().Be(15);
        }

        [Test]
        public void return_sum_changing_delimiter(){

            int res = calculator.add("//;1\n2\n3;4;5");
            
            res.Should().Be(15);
        }

        [Test]
        public void throw_negative_number_exception(){

            Action action = () => calculator.add("-1,-2,-3");

            action.Should().Throw<Exception>().WithMessage("Negatives not allowed: -1 -2 -3");
        }

        [Test]
        public void ignore_numbres_over_one_thousand(){
    
            int res = calculator.add("100000,2");

            res.Should().Be(2);
        }

        [Test]
        public void save_in_history()
        {
            var now = DateTime.Now;
            var request = now + "-" + "1,3,5-9";
            historyHandler.handle(request);
            var res = historyHandler.getRequest(request);
            res.Should().Be(request); 
        }

        [Test]

        public void save_multiple_entrys_in_history()
        {
            var time_First = DateTime.Now;
            var request_First = time_First + "-" + "1,3,5-9";

            var time_Second = DateTime.Now;
            var request_Second = time_Second + "-" + "1,3,5-9";

            historyHandler.handle(request_First);
            historyHandler.handle(request_Second);

            var res_First = historyHandler.getRequest(request_First);
            var res_Second = historyHandler.getRequest(request_Second);

            res_First.Should().Be(request_First);
            res_Second.Should().Be(request_Second);
        }
    }
}