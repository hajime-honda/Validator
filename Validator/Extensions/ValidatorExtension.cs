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
        /// <typeparam name="TModel">対象となるモデルクラス。</typeparam>
        /// <returns>検証結果。</returns>
        public static IEnumerable<Models.Error> Validate<TModel>(
            this TModel instance)
        {
            return Validator.Validate(instance);
        }
    }
}
