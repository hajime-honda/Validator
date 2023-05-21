using Validator.Extensions;

namespace Validator.Testing.Attributes.String
{
    /// <summary>
    /// MaxLengthAttributeのテスティングクラスです。
    /// </summary>
    [TestClass]
    public class MaxLengthAttributeTest
    {
        [TestMethod]
        public void 最大値未満の場合()
        {
            Model5 target = new();

            var errors = target.Validate();

            var count = errors.Count();

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void 最大値より大きい場合()
        {
            Model6 target = new();

            var errors = target.Validate();

            var count = errors.Count();

            Assert.AreEqual(1, count);
        }
    }
}
