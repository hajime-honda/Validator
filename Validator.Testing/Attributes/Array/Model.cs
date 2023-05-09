using Validator.Attributes.Array;

namespace Validator.Testing.Attributes.Array
{
    /// <summary>
    /// 設定した属性を満たす用
    /// </summary>
    public class Model
    {
        [Length(length: 2)]
        [MaxLength(max: 2)]
        [MinLength(min: 2)]
        public string[] Friends = new string[]
        {
            "taro",
            "jiro"
        };
    }

    /// <summary>
    /// 設定した属性を満たさない用
    /// </summary>
    public class Model2
    {
        [Length(length: 2)]
        [MinLength(min: 2)]
        public string[] Items = new string[]
        {
        };
    }

    /// <summary>
    /// nullプロパティ用
    /// </summary>
    public class Model3
    {
        [Length(length: 2)]
        [MaxLength(max: 2)]
        [MinLength(min: 2)]
        private string[] ThisPropertyIsNull = null;
    }

    /// <summary>
    /// 配列ではないフィールド用
    /// </summary>
    public class Model4
    {
        [Length(length: 2)]
        [MaxLength(max: 2)]
        [MinLength(min: 2)]
        public string Name
        {
            get;
            set;
        } = "taro";
    }

    public class Model5
    {
        [MaxLength(max: 1)]
        public string[] Items = new string[]
        {
            "taro",
            "jiro"
        };
    }
}
