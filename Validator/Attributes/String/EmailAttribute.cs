namespace Validator.Attributes.String
{
    /// <summary>
    /// メールアドレスの検証する属性クラスです。
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public sealed class EmailAttribute : Attribute, IValidatorAttribute
    {
        /// <summary>
        /// 検証結果のメッセージを取得します。
        /// </summary>
        public string Message
        {
            get;
            private set;
        }

        /// <summary>
        /// <see cref="EmailAttribute"/>の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="message">検証メッセージ。</param>
        public EmailAttribute(
            string message = "メールアドレスの形式ではありません")
        {
            this.Message = message;
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
                try
                {
                    var address = new System.Net.Mail.MailAddress(target);
                    return true;
                }
                catch (FormatException)
                {
                    return false;
                }
            }
            else
            {
                throw new NotSupportedException($"{nameof(instance)} は string型で指定してください。");
            }
        }
    }
}
