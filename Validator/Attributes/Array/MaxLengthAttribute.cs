namespace Validator.Attributes.Array
{
    using System.Collections;

    /// <summary>
    /// 配列の最大数を検証する属性クラスです。
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public sealed class MaxLengthAttribute : Attribute, IValidatorAttribute
    {
        /// <summary>
        /// バリデーターの名前を取得します。
        /// </summary>
        public string Name
        {
            get;
        } = "ArrayMaxLength";

        /// <summary>
        /// 確認する最大数を取得します。
        /// </summary>
        public uint Max
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
        /// <see cref="MaxLengthAttribute" /> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="max">配列の最大数。</param>
        /// <param name="message">エラーメッセージ。</param>
        public MaxLengthAttribute(
            uint max,
            string? message = null)
        {
            Max = max;
            Message = message ?? $"{Max}個をまでの項目を設定してください。";
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

                return array.Length <= Max;
            }

            if (instance is ICollection collection)
            {
                return collection.Count <= Max;
            }

            if (instance is IList list)
            {
                return list.Count <= Max;
            }

            if (instance is IEnumerable enumerable)
            {
                uint count = 0;

                foreach (var item in enumerable)
                {
                    count++;
                }

                return count <= Max;
            }

            throw new NotSupportedException($"{nameof(instance)} は 配列型またはICollection、IList、IEnumerable型のどれかで指定してください。");
        }
    }
}
