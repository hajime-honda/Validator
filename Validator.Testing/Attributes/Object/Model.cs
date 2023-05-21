using Validator.Attributes.Object;
using Validator.Models;

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

    internal class Models2 : ICustomValidator
    {
        [Required]
        public string Name
        {
            get;
            set;
        } = "taro";

        public int Age
        {
            get;
            set;
        } = 15;

        public IEnumerable<Error> Validate()
        {
            var errors = new List<Error>();

            if (this.Name != "taro")
            {
                if (this.Age < 0 || this.Age >= 150)
                {
                    errors.Add(new Error(name: "Models2", message: "年齢は0から150才までに設定してください。"));
                }
            }

            return errors;
        }
    }
}
