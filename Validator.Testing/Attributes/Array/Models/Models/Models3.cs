using Validator.Attributes.Array;

namespace Validator.Testing.Attributes.Array.Models.Length
{
    /// <summary>
    /// 配列ではないフィールド用
    /// </summary>
    public class Models3
    {
        [Length(length: 2)]
        private string[] ThisPropertyIsNull = null;
    }
}
