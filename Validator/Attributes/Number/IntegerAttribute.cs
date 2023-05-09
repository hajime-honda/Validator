namespace Validator.Attributes.Number
{
    /// <summary>
    /// 数値が整数値であるかを検証する属性クラスです。
    /// </summary>
    /// <typeparam name="T">数値型。</typeparam>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public sealed class IntegerAttribute<T> : Attribute, IValidatorAttribute where T : struct, IComparable
    {
        /// <summary>
        /// バリデーターの名前を取得します。
        /// </summary>
        public string Name
        {
            get;
        } = "NumberInteger";

        /// <summary>
        /// 検証結果のメッセージを取得します。
        /// </summary>
        public string Message
        {
            get;
            private set;
        }

        /// <summary>
        /// <see cref="IntegerAttribute{T}" /> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="message">エラーメッセージ。</param>
        public IntegerAttribute(
            string message)
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

            if (instance is T target)
            {
                return int.TryParse(target.ToString(), out _);
            }

            throw new NotSupportedException($"{nameof(instance)} は {nameof(T)}型で指定してください。");
        }
    }
}
