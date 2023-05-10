using Validator.Extensions;

namespace Validator.Testing.Attributes.Number
{
    /// <summary>
    /// LessThanAttributeのテスティングクラスです。
    /// </summary>
    [TestClass]
    public class LessThanAttributeTest
    {
        [TestMethod]
        public void 指定の数より小さい場合()
        {
            Model3 target = new();

            var errors = target.Validate(false);

            var count = errors.Count();

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void 指定の数より大きい場合()
        {
            Model4 target = new();

            var errors = target.Validate(false);

            var count = errors.Count();

            Assert.AreEqual(0, count);
        }
    }
}
