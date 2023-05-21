using Validator.Attributes.Array;

namespace Validator.Testing.Attributes.Array.Models.Length
{
    /// <summary>
    /// 設定した属性を満たさない用
    /// </summary>
    internal class Models2
    {
        [Length(length: 2)]
        public string[] Items = System.Array.Empty<string>();
    }
}
