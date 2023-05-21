namespace Validator.Models
{
    using System.Diagnostics;

    /// <summary>
    /// エラーを表すクラスです。
    /// </summary>
    [Serializable]
    [DebuggerDisplay("Name:{Name}, Message:{Message}")]
    public sealed class Error
    {
        /// <summary>
        /// 検証したプロパティ名を取得または設定します。
        /// </summary>
        public string Name
        {
            get;
        }

        /// <summary>
        /// メッセージを取得または設定します。
        /// </summary>
        public string Message
        {
            get;
        }

        /// <summary>
        /// <see cref="Error"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="name">検証したプロパティ名。</param>
        /// <param name="message">メッセージ。</param>
        public Error(string name, string message)
        {
            Name = name;
            Message = message;
        }
    }
}
