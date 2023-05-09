namespace Validator.Attributes.String
{
    /// <summary>
    /// 正規表現での検証を行う属性クラスです。
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class RegexAttribute : Attribute, IValidatorAttribute
    {
        /// <summary>
        /// バリデーターの名前を取得します。
        /// </summary>
        public string Name
        {
            get;
        } = "StringRegex";

        /// <summary>
        /// 正規表現を取得します。
        /// </summary>
        public string Pattern
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
        /// <see cref="RegexAttribute"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="pattern">正規表現。</param>
        /// <param name="message">エラーメッセージ。</param>
        public RegexAttribute(
            string pattern,
            string message = "形式が違います")
        {
            Pattern = pattern;
            Message = message;
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
                return System.Text.RegularExpressions.Regex.IsMatch(target, Pattern);
            }
            else
            {
                throw new NotSupportedException($"{nameof(instance)} は string型で指定してください。");
            }
        }
    }
}
