namespace Validator.Extensions
{
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
    }
}
