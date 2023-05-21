namespace Validator.Attributes.String
{
    /// <summary>
    /// uuidの検証を行う属性クラスです。
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class UUIDAttribute : RegexAttribute
    {
        /// <summary>
        /// <see cref="UUIDAttribute"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="message">エラーメッセージ。</param>
        public UUIDAttribute(
            string message = "形式が違います")
            : base(
                  pattern: "^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$",
                  message)
        {
        }
    }
}
