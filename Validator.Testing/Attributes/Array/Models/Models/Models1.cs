using Validator.Attributes.Array;

namespace Validator.Testing.Attributes.Array.Models.Length
{
    /// <summary>
    /// 設定した属性を満たす用
    /// </summary>
    public class Models1
    {
        [Length(length: 2)]
        public string[] Friends = new string[]
        {
            "taro",
            "jiro"
        };
    }
}
