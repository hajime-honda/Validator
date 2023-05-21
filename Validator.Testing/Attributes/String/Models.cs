using Validator.Attributes.String;

namespace Validator.Testing.Attributes.String
{
    public class Model1
    {
        [Email]
        public string Something
        {
            get;
            set;
        } = "example@gmail.com";
    }

    public class Model2
    {
        [Email]
        public string Something
        {
            get;
            set;
        } = "examplecom";
    }

    public class Model3
    {
        [Length(length: 10)]
        public string Something
        {
            get;
            set;
        } = "examplecom";
    }

    public class Model4
    {
        [Length(length: 10)]
        public string Something
        {
            get;
            set;
        } = "examplecom234567";
    }

    public class Model5
    {
        [MaxLength(length: 10)]
        public string Something
        {
            get;
            set;
        } = "examplecom";
    }

    public class Model6
    {
        [MaxLength(length: 10)]
        public string Something
        {
            get;
            set;
        } = "examplecom1234";
    }

    public class Model7
    {
        [MinLength(length: 10)]
        public string Something
        {
            get;
            set;
        } = "examplecom1234";
    }

    public class Model8
    {
        [MinLength(length: 10)]
        public string Something
        {
            get;
            set;
        } = "e";
    }

    public class Model9
    {
        [Url()]
        public string Something
        {
            get;
            set;
        } = "https://www.youtube.com/";
    }

    public class Model10
    {
        [Url()]
        public string Something
        {
            get;
            set;
        } = "123";
    }

    public class Model11
    {
        [UUID()]
        public string Something
        {
            get;
            set;
        } = "29bc867d-7024-e305-84d8-e08239d624e5";
    }

    public class Model12
    {
        [UUID()]
        public string Something
        {
            get;
            set;
        } = "123";
    }

    public class Model13
    {
        [Regex(pattern: "^123$")]
        public string Something
        {
            get;
            set;
        } = "123";
    }

    public class Model14
    {
        [Regex("^123$")]
        public string Something
        {
            get;
            set;
        } = "456";
    }
}
