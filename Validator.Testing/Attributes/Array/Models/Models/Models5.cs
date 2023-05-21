using Validator.Attributes.Array;

namespace Validator.Testing.Attributes.Array.Models.Models
{
    internal class Models5
    {
        [MaxLength(max: 2)]
        public string[] Friends = new string[]
        {
            "taro",
            "jiro"
        };
    }
}
