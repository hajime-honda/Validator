namespace Validator.Attributes.Number
{
    /// <summary>
    /// 数値が最小値を満たすかを検証する属性クラスです。
    /// </summary>
    /// <typeparam name="T">数値型。</typeparam>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public sealed class MinAttribute<T> : Attribute, IValidatorAttribute where T : struct, IComparable
    {
        /// <summary>
        /// バリデーターの名前を取得します。
        /// </summary>
        public string Name
        {
            get;
        } = "NumberMin";

        /// <summary>
        /// 最小値を取得します。
        /// </summary>
        public T Min
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
        /// <see cref="MinAttribute{T}" /> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="min">最大値。</param>
        /// <param name="message">エラーメッセージ。</param>
        public MinAttribute(
            T min,
            string? message = null)
        {
            Min = min;
            Message = message ?? $"{Min}を満たす数値を設定してください。";
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
                return target.CompareTo(this.Min) >= 0;
            }

            throw new NotSupportedException($"{nameof(instance)} は {nameof(T)}型で指定してください。");
        }
    }
}
