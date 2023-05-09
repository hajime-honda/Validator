namespace Validator.Attributes.Array
{
    using System.Collections;

    /// <summary>
    /// 最小配列の長さを検証する属性クラスです。
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public sealed class MinLengthAttribute : Attribute, IValidatorAttribute
    {
        /// <summary>
        /// バリデーターの名前を取得します。
        /// </summary>
        public string Name
        {
            get;
        } = "ArrayMinLength";

        /// <summary>
        /// 確認する長さを取得します。
        /// </summary>
        public uint Min
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
        /// <see cref="MinLengthAttribute" /> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="min">配列の最小長さ。</param>
        /// <param name="message">エラーメッセージ。</param>
        public MinLengthAttribute(
            uint min,
            string? message = null)
        {
            Min = min;
            Message = message ?? $"{Min}個を満たす項目を設定してください。";
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

                return array.Length >= Min;
            }

            if (instance is ICollection collection)
            {
                return collection.Count >= Min;
            }

            if (instance is IList list)
            {
                return list.Count >= Min;
            }

            if (instance is IEnumerable enumerable)
            {
                uint count = 0;

                foreach (var item in enumerable)
                {
                    count++;
                }

                return count >= Min;
            }

            throw new NotSupportedException($"{nameof(instance)} は 配列型またはICollection、IList、IEnumerable型のどれかで指定してください。");
        }
    }
}
