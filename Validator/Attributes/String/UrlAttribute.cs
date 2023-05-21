namespace Validator.Attributes.String
{
    /// <summary>
    /// Urlの検証を行う属性クラスです。
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public sealed class UrlAttribute : Attribute, IValidatorAttribute
    {
        /// <summary>
        /// Urlの種類を取得します。
        /// </summary>
        public UriKind Kind
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
        /// <see cref="UrlAttribute"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="kind">Uri種類。</param>
        /// <param name="message">エラーメッセージ。</param>
        public UrlAttribute(
            UriKind kind = UriKind.Absolute,
            string message = "Urlの形式ではありません")
        {
            Kind = kind;
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
                return Uri.IsWellFormedUriString(target, this.Kind);
            }
            else
            {
                throw new NotSupportedException($"{nameof(instance)} は string型で指定してください。");
            }
        }
    }
}
