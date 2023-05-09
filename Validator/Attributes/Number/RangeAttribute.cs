namespace Validator.Attributes.Number
{
    using global::Validator.Extensions;

    /// <summary>
    /// 数値が範囲内かを検証する属性クラスです。
    /// </summary>
    /// <typeparam name="T">数値型。</typeparam>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public sealed class RangeAttribute<T> : Attribute, IValidatorAttribute where T : struct, IComparable
    {
        /// <summary>
        /// バリデーターの名前を取得します。
        /// </summary>
        public string Name
        {
            get;
        } = "NumberRange";

        /// <summary>
        /// 最小値を取得します。
        /// </summary>
        public T Min
        {
            get;
            private set;
        }

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
        /// <see cref="RangeAttribute{T}" /> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="min">最小値。</param>
        /// <param name="max">最大値。</param>
        /// <param name="message">エラーメッセージ。</param>
        public RangeAttribute(
            T min,
            T max,
            string message)
        {
            Max = max;
            Min = min;
            Message = message ?? $"{Min} から {Max}までの範囲を設定してください。";
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
                return target.IsWithin(Min, Max);
            }

            throw new NotSupportedException($"{nameof(instance)} は {nameof(T)}型で指定してください。");
        }
    }
}
