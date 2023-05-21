using Validator.Extensions;

namespace Validator.Testing.Attributes.Date
{
    /// <summary>
    /// DisallowFutureDateAttributeのテスティングクラスです。
    /// </summary>
    [TestClass]
    public class DisallowFutureDateAttributeTest
    {
        [TestMethod]
        public void 範囲を満たす指定の場合()
        {
            Model6 target = new();

            var errors = target.Validate();

            var count = errors.Count();

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void 範囲を満たさない指定の場合()
        {
            Model7 target = new();

            var errors = target.Validate();

            var count = errors.Count();

            Assert.AreEqual(1, count);
        }
    }
}
