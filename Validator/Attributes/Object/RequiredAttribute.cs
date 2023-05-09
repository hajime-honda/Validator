namespace Validator.Attributes.Object
{
    using System.Collections;

    /// <summary>
    /// 必須であるかを検証する属性クラスです。
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public sealed class RequiredAttribute : Attribute, IValidatorAttribute
    {
        /// <summary>
        /// バリデーターの名前を取得します。
        /// </summary>
        public string Name
        {
            get;
        } = "ObjectRequired";

        /// <summary>
        /// 検証結果のメッセージを取得します。
        /// </summary>
        public string Message
        {
            get;
            private set;
        }

        /// <summary>
        /// <see cref="RequiredAttribute"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="message">エラーメッセージ。</param>
        public RequiredAttribute(
            string message = "必須項目です。")
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
                return false;
            }

            if (instance is string strInstance)
            {
                return !string.IsNullOrEmpty(strInstance);
            }

            if (instance is ICollection collection)
            {
                return collection.Count > 0;
            }

            if (instance is IList list)
            {
                return list.Count > 0;
            }

            if (instance is IEnumerable enumerable)
            {
                uint count = 0;

                foreach (var item in enumerable)
                {
                    count++;
                }

                return count > 0;
            }

            return true;
        }
    }
}
