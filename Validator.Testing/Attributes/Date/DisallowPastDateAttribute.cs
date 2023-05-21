using Validator.Extensions;

namespace Validator.Testing.Attributes.Date
{
    /// <summary>
    /// DisallowPastDateAttributeのテスティングクラスです。
    /// </summary>
    [TestClass]
    public class DisallowPastDateAttributeTest
    {
        [TestMethod]
        public void 範囲を満たす指定の場合()
        {
            Model8 target = new();

            var errors = target.Validate();

            var count = errors.Count();

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void 範囲を満たさない指定の場合()
        {
            Model9 target = new();

            var errors = target.Validate();

            var count = errors.Count();

            Assert.AreEqual(1, count);
        }
    }
}
