namespace Validator
{
    using Extensions;
    using global::Validator.Attributes;
    using Models;
    using System.Dynamic;
    using System.Xml;

    /// <summary>
    /// 検証を行うクラスです。
    /// </summary>
    public sealed class Validator
    {
        /// <summary>
        /// 検証します。
        /// </summary>
        /// <param name="instance">インスタンス。</param>
        /// <param name="required">必須であるか。</param>
        /// <param name="requiredMessage">必須時のメッセージ。</param>
        /// <typeparam name="TModel">対象となるモデルクラス。</typeparam>
        /// <returns>検証結果。</returns>
        public static IEnumerable<Error> Validate<TModel>(
            TModel instance,
            bool required = false,
            string requiredMessage = "この値は必須です")
        {
            if (instance is null)
            {
                if (required)
                {
                    yield return new Error(
                        name: nameof(TModel),
                        message: requiredMessage,
                        type: "required");
                }
                else
                {
                    yield break;
                }
            }

            foreach (var property in instance.GetProperties())
            {
                foreach (var attribute in property.GetCustomAttributes(true))
                {
                    if (attribute is IValidatorAttribute validator)
                    {
                        if (!validator.Validate(property.GetValue(instance)))
                        {
                            yield return new Error(
                                name: property.Name,
                                message: validator.Message,
                                type: validator.Name);
                        }
                    }
                }
            }

            foreach (var field in instance.GetFields())
            {
                foreach (var attribute in field.GetCustomAttributes(true))
                {
                    if (attribute is IValidatorAttribute validator)
                    {
                        if (!validator.Validate(field.GetValue(instance)))
                        {
                            yield return new Error(
                                name: field.Name,
                                message: validator.Message,
                                type: validator.Name);
                        }
                    }
                }
            }
        }
    }
}
