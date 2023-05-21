using Validator.Extensions;

namespace Validator.Testing.Attributes.Number
{
    /// <summary>
    /// MaxAttributeのテスティングクラスです。
    /// </summary>
    [TestClass]
    public class MaxAttributeTest
    {
        [TestMethod]
        public void 最大値の範囲内の場合()
        {
            Model5 target = new();

            var errors = target.Validate();

            var count = errors.Count();

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void 最大値の範囲外の場合()
        {
            Model6 target = new();

            var errors = target.Validate();

            var count = errors.Count();

            Assert.AreEqual(1, count);
        }
    }
}
