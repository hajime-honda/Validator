using Validator.Extensions;

namespace Validator.Testing.Attributes.String
{
    /// <summary>
    /// MinLengthAttributeのテスティングクラスです。
    /// </summary>
    [TestClass]
    public class MinLengthAttributeTest
    {
        [TestMethod]
        public void 最小値以上の場合()
        {
            Model7 target = new();

            var errors = target.Validate();

            var count = errors.Count();

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void 最小値より小さい場合()
        {
            Model8 target = new();

            var errors = target.Validate();

            var count = errors.Count();

            Assert.AreEqual(1, count);
        }
    }
}
