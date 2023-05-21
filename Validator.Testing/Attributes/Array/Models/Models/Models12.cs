using Validator.Attributes.Array;

namespace Validator.Testing.Attributes.Array.Models.Models
{
    internal class Models12
    {
        [MinLength(min: 2)]
        public string Name
        {
            get;
            set;
        } = "taro";
    }
}
