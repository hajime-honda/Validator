using Validator.Attributes.Date;

namespace Validator.Testing.Attributes.Date
{
    public class Model
    {
        [DateTimeRange(start: "2023/5/1")]
        [DateTimeRange(end: "2023/5/31")]
        [DateTimeRange(start: "2023/5/1", end: "2023/5/31")]
        public DateTime May
        {
            get;
            set;
        } = DateTime.Parse("2023/5/1");
    }

    public class Model2
    {
        [DateTimeRange(start: "2023/6/1")]
        [DateTimeRange(end: "2023/4/3")]
        [DateTimeRange(start: "2023/4/1", end: "2023/4/3")]
        public DateTime May
        {
            get;
            set;
        } = DateTime.Parse("2023/5/1");
    }

    public class Model3
    {
        [DateTimeRange(end: "2023/4/34")]
        public DateTime May
        {
            get;
            set;
        } = DateTime.Parse("2023/5/1");
    }

    public class Model4
    {
        [DateTimeRange(start: "2023/4/34")]
        public DateTime May
        {
            get;
            set;
        } = DateTime.Parse("2023/5/1");
    }

    public class Model5
    {
        [DateTimeRange()]
        public DateTime May
        {
            get;
            set;
        } = DateTime.Parse("2023/5/1");
    }

    public class Model6
    {
        [DisallowFutureDate()]
        public DateTime Future
        {
            get;
            set;
        } = DateTime.Parse("1900/12/31");
    }

    public class Model7
    {
        [DisallowFutureDate()]
        public DateTime Future
        {
            get;
            set;
        } = DateTime.Parse("9999/12/31");
    }

    public class Model8
    {
        [DisallowPastDate()]
        public DateTime Future
        {
            get;
            set;
        } = DateTime.Parse("9999/12/31");
    }

    public class Model9
    {
        [DisallowPastDate()]
        public DateTime Future
        {
            get;
            set;
        } = DateTime.Parse("1900/12/31");
    }
}
