using LogisticService.Utility;

namespace LogisticService.Requests
{
    public class UserRequest
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public bool IsRunning { get; set; }
        public bool IsClosed { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public bool IsIncluded { get; set; }


        private int _dayCount;
        public int DayCount
        {
            get
            {
                return _dayCount;
            }
            set
            {
                if(value == 2 || 
                    value == 7 || 
                    value == 15 ||
                    value == 30)
                {
                    _dayCount = value;
                }
                else
                {
                    if(value < 2)
                    {
                        _dayCount = 2;
                    }
                    else if(value > 2 && value < 7)
                    {
                        _dayCount = 7;
                    }
                    else if(value > 7 && value < 15)
                    {
                        _dayCount = 15;
                    }
                    else
                    {
                        _dayCount = 30;
                    }
                }

            }
        }

        public UserRequest(
            string mark,
            string model,
            int year,
            bool isRunning,
            bool isClosed,
            string from,
            string to,
            bool isIncluded,
            int dayCount)
        {
            Id = IdGenerator.Generate<UserRequest>();
            Mark = mark;
            Model = model;
            Year = year;
            IsRunning = isRunning;
            IsClosed = isClosed;
            FromLocation = from;
            ToLocation = to;
            IsIncluded = isIncluded;
            DayCount = dayCount;
        }

        public UserRequest()
        {
        }
    }
}
