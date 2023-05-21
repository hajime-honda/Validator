namespace Validator
{
    using Extensions;
    using global::Validator.Attributes;
    using Models;
    using System.Reflection;

    /// <summary>
    /// 検証を行うクラスです。
    /// </summary>
    public sealed class Validator
    {
        /// <summary>
        /// 検証します。
        /// </summary>
        /// <param name="instance">インスタンス。</param>
        /// <typeparam name="TModel">対象となるモデルクラス。</typeparam>
        /// <returns>検証結果。</returns>
        public static IEnumerable<Error> Validate<TModel>(TModel instance)
        {
            var errors = new List<Error>();

            ValidateOfProperties(instance, ref errors);

            ValidateOfField(instance, ref errors);

            if (instance is ICustomValidator customValidator)
            {
                foreach (var error in customValidator.Validate())
                {
                    errors.Add(error);
                }
            }

            return errors;
        }

        /// <summary>
        /// プロパティに付与されている属性を呼び出します。
        /// </summary>
        /// <param name="instance">インスタンス。</param>
        /// <param name="errors">エラーオブジェクト。</param>
        private static void ValidateOfProperties(object instance, ref List<Error> errors)
        {
            foreach (var property in instance.GetProperties())
            {
                foreach (var attribute in property.GetCustomAttributes(true))
                {
                    if (attribute is IValidatorAttribute validator)
                    {
                        if (!validator.Validate(property.GetValue(instance)))
                        {
                            errors.Add(new Error(
                                name: property.Name,
                                message: validator.Message));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// フィールドに付与されている属性を呼び出します。
        /// </summary>
        /// <param name="instance">インスタンス。</param>
        /// <param name="errors">エラーオブジェクト。</param>
        private static void ValidateOfField(object instance, ref List<Error> errors)
        {
            foreach (var field in instance.GetFields())
            {
                foreach (var attribute in field.GetCustomAttributes(true))
                {
                    if (attribute is IValidatorAttribute validator)
                    {
                        if (!validator.Validate(field.GetValue(instance)))
                        {
                            errors.Add(new Error(
                                name: field.Name,
                                message: validator.Message));
                        }
                    }
                }
            }
        }
    }
}
