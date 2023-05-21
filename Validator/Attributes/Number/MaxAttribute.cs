namespace Validator.Attributes.Number
{
    /// <summary>
    /// 数値が最大値までの値かを検証する属性クラスです。
    /// </summary>
    /// <typeparam name="T">数値型。</typeparam>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public sealed class MaxAttribute<T> : Attribute, IValidatorAttribute where T : struct, IComparable
    {
        /// <summary>
        /// 最大値を取得します。
        /// </summary>
        public T Max
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
        /// <see cref="MaxAttribute{T}" /> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="max">最大値。</param>
        /// <param name="message">エラーメッセージ。</param>
        public MaxAttribute(
            T max,
            string? message = null)
        {
            Max = max;
            Message = message ?? $"{Max}までの数値を設定してください。";
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
                return target.CompareTo(this.Max) <= 0;
            }

            throw new NotSupportedException($"{nameof(instance)} は {nameof(T)}型で指定してください。");
        }
    }
}
