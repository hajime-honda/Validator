using Validator.Attributes.Array;

namespace Validator.Testing.Attributes.Array.Models.Length
{
    public class Models4
    {
        [Length(length: 2)]
        public string Name
        {
            get;
            set;
        } = "taro";
    }
}
