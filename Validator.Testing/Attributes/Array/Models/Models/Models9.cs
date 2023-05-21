using Validator.Attributes.Array;

namespace Validator.Testing.Attributes.Array.Models.Models
{
    internal class Models9
    {
        [MinLength(min: 2)]
        public string[] Friends = new string[]
        {
            "taro",
            "jiro"
        };
    }
}
