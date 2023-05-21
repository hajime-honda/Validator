using Validator.Attributes.Array;

namespace Validator.Testing.Attributes.Array.Models.Models
{
    internal class Models10
    {
        [MinLength(min: 2)]
        public string[] Items = System.Array.Empty<string>();
    }
}
