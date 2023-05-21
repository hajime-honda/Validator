using Validator.Attributes.Number;

namespace Validator.Testing.Attributes.Number
{
    public class Model
    {
        [Integer()]
        public int SomethingNumber
        {
            get;
            set;
        } = 1;
    }

    public class Model2
    {
        [Integer()]
        public double SomethingNumber
        {
            get;
            set;
        } = 1.23;
    }

    public class Model3
    {
        [LessThan<int>(value: 9)]
        public int SomethingNumber
        {
            get;
            set;
        } = 10;
    }

    public class Model4
    {
        [LessThan<int>(value: 11)]
        public int SomethingNumber
        {
            get;
            set;
        } = 10;
    }

    public class Model5
    {
        [Max<int>(max: 11)]
        public int SomethingNumber
        {
            get;
            set;
        } = 10;
    }

    public class Model6
    {
        [Max<int>(max: 11)]
        public int SomethingNumber
        {
            get;
            set;
        } = 12;
    }

    public class Model7
    {
        [Min<int>(min: 11)]
        public int SomethingNumber
        {
            get;
            set;
        } = 12;
    }

    public class Model8
    {
        [Min<int>(min: 11)]
        public int SomethingNumber
        {
            get;
            set;
        } = 9;
    }

    public class Model9
    {
        [Negative<int>()]
        public int SomethingNumber
        {
            get;
            set;
        } = -9;
    }

    public class Model10
    {
        [Negative<int>()]
        public int SomethingNumber
        {
            get;
            set;
        } = 9;
    }

    public class Model11
    {
        [Positive<int>()]
        public int SomethingNumber
        {
            get;
            set;
        } = 9;
    }

    public class Model12
    {
        [Positive<int>()]
        public int SomethingNumber
        {
            get;
            set;
        } = -9;
    }

    public class Model13
    {
        [Range<int>(min: 0, max: 10)]
        public int SomethingNumber
        {
            get;
            set;
        } = 5;
    }

    public class Model14
    {
        [Range<int>(min: 0, max: 10)]
        public int SomethingNumber
        {
            get;
            set;
        } = -1;
    }

    public class Model15
    {
        [Range<int>(min: 0, max: 10)]
        public int SomethingNumber
        {
            get;
            set;
        } = 11;
    }
}
