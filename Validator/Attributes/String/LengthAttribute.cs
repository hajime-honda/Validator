namespace Validator.Attributes.String
{
    /// <summary>
    /// 文字数の検証する属性クラスです。
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public sealed class LengthAttribute : Attribute, IValidatorAttribute
    {
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
        /// <see cref="LengthAttribute"/>の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="length">文字数。</param>
        /// <param name="message">検証メッセージ。</param>
        public LengthAttribute(
            uint length,
            string message = "")
        {
            Length = length;
            Message = message ?? $"文字数({Length}文字)をではありません。";
        }

        /// <summary>
        /// 検証します。
        /// </summary>
        /// <param name="instance">インスタンス。</param>
        /// <returns>true: 妥当である。false: 妥当ではない。</returns>
        public bool Validate(object instance)
        {
            if (instance is null)
            {
                return true;
            }

            if (instance is string target)
            {
                return target.Length == Length;
            }
            else if (instance is IEnumerable<char> chars)
            {
                return chars.Count() == Length;
            }
            else
            {
                throw new NotSupportedException($"{nameof(instance)} は string型 または IEnumerable<char>型で指定してください。");
            }
        }
    }
}
