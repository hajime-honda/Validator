using Validator.Attributes.Array;

namespace Validator.Testing.Attributes.Array.Models.Models
{
    internal class Models6
    {
        [MaxLength(max: 2)]
        private string[] ThisPropertyIsNull = null;
    }
}
