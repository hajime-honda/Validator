namespace Validator.Attributes.String
{
    /// <summary>
    /// uuidの検証を行う属性クラスです。
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    internal class UUIDAttribute : RegexAttribute
    {
        /// <summary>
        /// バリデーターの名前を取得します。
        /// </summary>
        public new string Name
        {
            get;
        } = "StringUUID";

        /// <summary>
        /// <see cref="UUIDAttribute"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="message">エラーメッセージ。</param>
        public UUIDAttribute(
            string message = "形式が違います")
            : base(
                  pattern: "^[0-9a-f]{8}-[0-9a-f]{4}-[0-5][0-9a-f]{3}-[089ab][0-9a-f]{3}-[0-9a-f]{12}$",
                  message)
        {
        }
    }
}
