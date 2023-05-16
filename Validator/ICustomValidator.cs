namespace Validator
{
    /// <summary>
    /// カスタムの検証を行うインターフェースを表します。
    /// </summary>
    public interface ICustomValidator
    {
        /// <summary>
        /// 検証します。
        /// </summary>
        /// <returns>エラー。</returns>
        IEnumerable<Models.Error> Validate();
    }
}
