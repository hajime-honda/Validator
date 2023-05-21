using Validator.Attributes.Array;

namespace Validator.Testing.Attributes.Array.Models.Models
{
    internal class Models8
    {
        [MaxLength(max: 2)]
        public string Name
        {
            get;
            set;
        } = "taro";
    }
}
