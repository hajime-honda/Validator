namespace Validator.Attributes.Array
{
    using System.Collections;

    /// <summary>
    /// 配列の長さを検証する属性クラスです。
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public sealed class LengthAttribute : Attribute, IValidatorAttribute
    {
        /// <summary>
        /// 確認する長さを取得します。
        /// </summary>
        public uint Length
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
        /// <see cref="LengthAttribute" /> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="length">配列の長さ。</param>
        /// <param name="message">エラーメッセージ。</param>
        public LengthAttribute(
            uint length,
            string? message = null)
        {
            Length = length;
            Message = message ?? $"{Length}個の項目を設定してください。";
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

            if (instance is string)
            {
                throw new NotSupportedException($"{nameof(instance)} は 配列型またはICollection、IList、IEnumerable型のどれかで指定してください。");
            }

            if (instance.GetType().IsArray)
            {
                object[] array = (object[])instance;

                return array.Length == Length;
            }

            if (instance is ICollection collection)
            {
                return collection.Count == Length;
            }

            if (instance is IList list)
            {
                return list.Count == Length;
            }

            if (instance is IEnumerable enumerable)
            {
                uint count = 0;

                foreach (var item in enumerable)
                {
                    count++;
                }

                return count == Length;
            }

            throw new NotSupportedException($"{nameof(instance)} は 配列型またはICollection、IList、IEnumerable型のどれかで指定してください。");
        }
    }
}
