namespace Validator.Attributes.Number
{
    /// <summary>
    /// 数値が整数値であるかを検証する属性クラスです。
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public sealed class IntegerAttribute : Attribute, IValidatorAttribute
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
        /// <see cref="IntegerAttribute" /> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="message">エラーメッセージ。</param>
        public IntegerAttribute(
            string? message = null)
        {
            Message = message ?? $"整数値を設定してください。";
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

            return instance is int;
        }
    }
}
