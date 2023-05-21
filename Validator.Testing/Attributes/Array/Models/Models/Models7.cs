using Validator.Attributes.Array;

namespace Validator.Testing.Attributes.Array.Models.Models
{
    internal class Models7
    {
        [MaxLength(max: 1)]
        public string[] Items = new string[]
        {
            "taro",
            "jiro"
        };
    }
}
