namespace Validator.Extensions
{
    using global::Validator.Attributes;
    using System.Reflection;

    /// <summary>
    /// 属性に関する拡張メソッドを提供するクラスです。
    /// </summary>
    internal static class AttributesExtension
    {
        /// <summary>
        /// インスタンスのプロパティを取得します。
        /// </summary>
        /// <param name="instance">インスタンス。</param>
        /// <returns><see cref="PropertyInfo"/>配列。</returns>
        public static PropertyInfo[] GetProperties(this object instance)
        {
            var t = instance.GetType();
            var tt = t.GetProperties();
            return instance.GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        }

        /// <summary>
        /// インスタンスのフィールドを取得します。
        /// </summary>
        /// <param name="instance">インスタンス。</param>
        /// <returns><see cref="FieldInfo"/>配列。</returns>
        public static FieldInfo[] GetFields(this object instance)
        {
            return instance.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        }

        /// <summary>
        /// <see cref="PropertyInfo"/>から<see cref="IValidatorAttribute"/>を実装した属性クラスを取得します。
        /// </summary>
        /// <param name="propertyInfo"><see cref="PropertyInfo"/>。</param>
        /// <returns><see cref="Attribute"/>配列。</returns>
        public static object[] GetValidatorAttributes<TModel>(this PropertyInfo propertyInfo)
        {
            return propertyInfo.GetType().GetCustomAttributes(typeof(IValidatorAttribute), false);
        }

        /// <summary>
        /// Null許容型であるかを確認します。
        /// </summary>
        /// <param name="type"><see cref="Type"/>。</param>
        /// <returns>true: Null許容型である。false: Null許容型ではない。</returns>
        public static bool IsNullable(this Type type)
        {
            return Nullable.GetUnderlyingType(type) != null;
        }

        /// <summary>
        /// インスタンスがNull許容型で値がnullであるか判定します。
        /// </summary>
        /// <param name="instance">インスタンス。</param>
        /// <returns>true: Null許容型で値がnullである。false: Null許容型で値がnullではない。</returns>
        public static bool IsNullableAndNull(this object instance)
        {
            if (instance == null || !instance.GetType().IsNullable())
            {
                return false;
            }

            return instance.Equals(null);
        }

        /// <summary>
        /// Null許容型に変換します。
        /// </summary>
        /// <typeparam name="T">型。</typeparam>
        /// <param name="instance">インスタンス。</param>
        /// <returns>Null許容型。</returns>
        public static T? ToNullable<T>(this object instance)
        {
            if (instance == null)
            {
                return default;
            }

            return typeof(T) == instance.GetType() 
                ? (T)instance 
                : (T)Convert.ChangeType(instance, typeof(T));
        }


        /// <summary>
        /// Null許容型でnullの場合はデフォルト値を、そうではない場合値を取得します。
        /// </summary>
        /// <typeparam name="T">型。</typeparam>
        /// <param name="instance">インスタンス。</param>
        /// <param name="defaultValue">デフォルト値。</param>
        /// <returns>nullまたは値。</returns>
        public static T GetValueOrDefault<T>(this T? instance, T defaultValue = default) where T : struct
        {
            return instance ?? defaultValue;
        }

        /// <summary>
        /// 範囲内であるか確認します。
        /// </summary>
        /// <typeparam name="T">整数型。</typeparam>
        /// <param name="value">値。</param>
        /// <param name="min">最大値。</param>
        /// <param name="max">最小値。</param>
        /// <returns>true: 範囲内。false: 範囲外</returns>
        public static bool IsWithin<T>(this T value, T min, T max) where T : struct, IComparable
        {
            if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// パスからオブジェクトの値を取得します。
        /// </summary>
        /// <param name="instance">インスタンス。</param>
        /// <param name="path">パス。</param>
        /// <returns>値。</returns>
        public static object GetPropertyValueByPath(this object instance, string path)
        {
            return
                ($"${instance.GetType().Name}.{path}").Split('.')
                    .Aggregate(
                        instance,
                        (current, property) =>
                            current?.GetType()
                                    .GetProperty(property)?.GetValue(current));
        }
    }
}
