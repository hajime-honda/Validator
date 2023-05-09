namespace Validator.Attributes.Date
{
    /// <summary>
    /// 未来日を禁止するための検証を行う属性クラスです。
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public sealed class DisallowFutureDateAttribute : Attribute, IValidatorAttribute
    {
        /// <summary>
        /// バリデーターの名前を取得します。
        /// </summary>
        public string Name
        {
            get;
        } = "DisallowFutureDate";

        /// <summary>
        /// 検証結果のメッセージを取得します。
        /// </summary>
        public string Message
        {
            get;
            private set;
        }

        /// <summary>
        /// <see cref="DisallowFutureDateAttribute"/>
        /// </summary>
        /// <param name="message">エラーメッセージ。</param>
        public DisallowFutureDateAttribute(
            string message = "未来日を設定することはできません。")
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
                return DateTime.Today >= target;
            }
            else
            {
                throw new NotSupportedException($"{nameof(instance)} は DateTime型で指定してください。");
            }
        }
    }
}
