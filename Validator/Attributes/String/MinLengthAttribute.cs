namespace Validator.Attributes.String
{
    using global::Validator.Extensions;

    /// <summary>
    /// 最小文字数の検証を行うクラスです。
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public sealed class MinLengthAttribute : Attribute, IValidatorAttribute
    {
        /// <summary>
        /// バリデーターの名前を取得します。
        /// </summary>
        public string Name
        {
            get;
        } = "StringMinLength";

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
        /// <see cref="MinLengthAttribute"/>の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="length">最小文字数。</param>
        /// <param name="message">検証メッセージ。</param>
        public MinLengthAttribute(
            uint length,
            string message = "")
        {
            Length = length;
            Message = message ?? $"最小文字数({Length}文字)に達していません。";
        }

        /// <summary>
        /// 検証します。
        /// </summary>
        /// <param name="instance">インスタンス。</param>
        /// <returns>true: 妥当である。false: 妥当ではない。</returns>
        public bool Validate(object instance)
        {
            if (instance is null || Length == uint.MaxValue || instance.IsNullableAndNull())
            {
                return true;
            }

            if (instance is string target)
            {
                return target.Length >= Length;
            }
            else if (instance is IEnumerable<char> chars)
            {
                return chars.Count() >= Length;
            }
            else
            {
                throw new NotSupportedException($"{nameof(instance)} は string型 または IEnumerable<char>型で指定してください。");
            }
        }
    }
}
