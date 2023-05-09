namespace Validator.Attributes.String
{
    /// <summary>
    /// 最大文字数の検証する属性クラスです。
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public sealed class MaxLengthAttribute : Attribute, IValidatorAttribute
    {
        /// <summary>
        /// バリデーターの名前を取得します。
        /// </summary>
        public string Name
        {
            get;
        } = "StringMaxLength";

        /// <summary>
        /// 確認する長さの値を取得します。
        /// </summary>
        public uint Length
        {
            get;
            private set;
        }

        /// <summary>
        /// 検証結果のメッセージを取得します。
        /// </summary>
        public string Message
        {
            get;
            private set;
        }

        /// <summary>
        /// <see cref="MaxLengthAttribute"/>の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="length">最大文字数。</param>
        /// <param name="message">検証メッセージ。</param>
        public MaxLengthAttribute(
            uint length,
            string message)
        {
            Length = length;
            Message = message ?? $"最大文字数({Length}文字)を超えています。";
        }

        /// <summary>
        /// 検証します。
        /// </summary>
        /// <param name="instance">インスタンス。</param>
        /// <returns>true: 妥当である。false: 妥当ではない。</returns>
        public bool Validate(object instance)
        {
            if (instance is null || Length == uint.MaxValue)
            {
                return true;
            }

            if (instance is string target)
            {
                return target.Length <= Length;
            }
            else if (instance is IEnumerable<char> chars)
            {
                return chars.Count() <= Length;
            }
            else
            {
                throw new NotSupportedException($"{nameof(instance)} は string型 または IEnumerable<char>型で指定してください。");
            }
        }
    }
}
