using System;

namespace StringCalculator.Persistance
{
    public interface DatePicker
    {
        public DateTime GetDate();
    }

    public class APIDatePicker : DatePicker
    {
        public DateTime GetDate()
        {
            return DateTime.Now;
        }
    }
}
