using Validator.Attributes.Object;

namespace Validator.Testing.Attributes.Object
{
    internal class Model
    {
        [Required(message: "Custom Message.")]
        public string Name
        {
            get;
            set;
        } = string.Empty;

        [Required]
        public int? Age
        {
            get;
            set;
        } = null;

        [Required]
        public IEnumerable<object> Storages
        {
            get;
            set;
        } = Enumerable.Empty<object>();

        [Required]
        public List<string> Friends
        {
            get;
            set;
        } = new List<string>();
    }
}
