namespace Validator.Attributes.Date
{
    /// <summary>
    /// 過去日を禁止するための検証を行う属性クラスです。
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public sealed class DisallowPastDateAttribute : Attribute, IValidatorAttribute
    {
        /// <summary>
        /// バリデーターの名前を取得します。
        /// </summary>
        public string Name
        {
            get;
        } = "DisallowPastDate";

        /// <summary>
        /// 検証結果のメッセージを取得します。
        /// </summary>
        public string Message
        {
            get;
            private set;
        }

        /// <summary>
        /// <see cref="DisallowPastDateAttribute"/>
        /// </summary>
        /// <param name="message">エラーメッセージ。</param>
        public DisallowPastDateAttribute(
            string message = "過去日を設定する事はできません。")
        {
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

            if (instance is DateTime target)
            {
                return DateTime.Today <= target;
            }
            else
            {
                throw new NotSupportedException($"{nameof(instance)} は DateTime型で指定してください。");
            }
        }
    }
}
