namespace Validator.Extensions
{
    /// <summary>
    /// 検証を行うクラスの拡張メソッドです。
    /// </summary>
    public static class ValidatorExtension
    {
        /// <summary>
        /// 検証します。
        /// </summary>
        /// <param name="instance">インスタンス。</param>
        /// <param name="required">必須であるか。</param>
        /// <param name="requiredMessage">必須時のメッセージ。</param>
        /// <typeparam name="TModel">対象となるモデルクラス。</typeparam>
        /// <returns>検証結果。</returns>
        public static IEnumerable<Models.Error> Validate<TModel>(
            this TModel instance,
            bool required = false,
            string requiredMessage = "")
        {
            return Validator.Validate(instance, required, requiredMessage);
        }
    }
}
