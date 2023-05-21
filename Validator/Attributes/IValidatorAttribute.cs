namespace Validator.Attributes
{
    /// <summary>
    /// バリデーター属性のインターフェースです。
    /// </summary>
    public interface IValidatorAttribute
    {
        /// <summary>
        /// 検証結果のメッセージを表します。
        /// </summary>
        string Message
        {
            get;
        }

        /// <summary>
        /// 検証します。
        /// </summary>
        /// <param name="instance">インスタンス。</param>
        /// <returns>true: 妥当である。false: 妥当ではない。</returns>
        bool Validate(object instance);
    }
}
