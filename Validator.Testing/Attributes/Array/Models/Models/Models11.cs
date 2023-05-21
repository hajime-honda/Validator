using Validator.Attributes.Array;

namespace Validator.Testing.Attributes.Array.Models.Models
{
    internal class Models11
    {
        [MinLength(min: 2)]
        private string[] ThisPropertyIsNull = null;
    }
}
