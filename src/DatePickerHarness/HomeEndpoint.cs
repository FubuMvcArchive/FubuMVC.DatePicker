using System;

namespace DatePickerHarness
{
    public class HomeEndpoint
    {
        public DateModel Index()
        {
            return new DateModel();
        }
    }

    public class DateModel
    {
        public DateTime SomeDate { get; set; }
    }
}