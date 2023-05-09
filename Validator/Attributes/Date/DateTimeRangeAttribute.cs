namespace Validator.Attributes.Date
{
    /// <summary>
    /// 時間範囲の検証を行う属性クラスです。
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
    public sealed class DateTimeRangeAttribute : Attribute, IValidatorAttribute
    {
        /// <summary>
        /// バリデーターの名前を取得します。
        /// </summary>
        public string Name
        {
            get;
        } = "DateTimeRange";

        /// <summary>
        /// 開始日時を取得します。
        /// </summary>
        public DateTime? Start
        {
            get;
            private set;
        }

        /// <summary>
        /// 終了日時を取得します。
        /// </summary>
        public DateTime? End
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
        } = string.Empty;

        /// <summary>
        /// <see cref="DateTimeRangeAttribute"/>
        /// </summary>
        /// <param name="start">開始日時文字列。</param>
        /// <param name="end">終了日時文字列。</param>
        /// <param name="message">エラーメッセージ。</param>
        public DateTimeRangeAttribute(
            string? start = null,
            string? end = null,
            string? message = null)
        {
            if (start is null && end is null)
            {
                throw new ArgumentNullException();
            }

            if (start is not null)
            {
                Start = DateTime.Parse(start);
            }

            if (end is not null)
            {
                End = DateTime.Parse(end);
            }

            if (Start.HasValue && End.HasValue)
            {
                Message = message ?? $"{Start} から {End}までの範囲を設定してください。";
            }
            else if (Start.HasValue)
            {
                Message = message ?? $"{Start.Value.ToShortDateString()}からの範囲を設定してください。";
            }
            else if (End.HasValue)
            {
                Message = message ?? $"{End.Value.ToShortDateString()}までの範囲を設定してください。";
            }
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

            if (instance is DateTime target)
            {
                if (Start.HasValue && End.HasValue)
                {
                    return Start.Value <= target && target <= End.Value;
                }
                else if (Start.HasValue)
                {
                    return Start.Value <= target;
                }
                else if(End.HasValue)
                {
                    return target <= End.Value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            else
            {
                throw new NotSupportedException($"{nameof(instance)} は DateTime型で指定してください。");
            }
        }
    }
}
