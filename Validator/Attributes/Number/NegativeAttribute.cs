﻿namespace Validator.Attributes.Number
{
    /// <summary>
    /// 数値が負の値であるかを検証する属性クラスです。
    /// </summary>
    /// <typeparam name="T">数値型。</typeparam>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public sealed class NegativeAttribute<T> : Attribute, IValidatorAttribute where T : struct, IComparable
    {
        /// <summary>
        /// バリデーターの名前を取得します。
        /// </summary>
        public string Name
        {
            get;
        } = "NumberNegative";

        /// <summary>
        /// 検証結果のメッセージを取得します。
        /// </summary>
        public string Message
        {
            get;
            private set;
        }

        /// <summary>
        /// <see cref="NegativeAttribute{T}" /> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="message">エラーメッセージ。</param>
        public NegativeAttribute(
            string message)
        {
            Message = message ?? $"負の値を設定してください。";
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
                return target.CompareTo(0) < 0;
            }

            throw new NotSupportedException($"{nameof(instance)} は {nameof(T)}型で指定してください。");
        }
    }
}
