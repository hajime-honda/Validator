using Validator.Extensions;

namespace Validator.Testing.Attributes.Number
{
    /// <summary>
    ///  MinAttributeのテスティングクラスです。
    /// </summary>
    [TestClass]
    public class MinAttributeTest
    {
        [TestMethod]
        public void 最小値を満たす場合()
        {
            Model7 target = new();

            var errors = target.Validate();

            var count = errors.Count();

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void 最小値を満たさない場合()
        {
            Model8 target = new();

            var errors = target.Validate();

            var count = errors.Count();

            Assert.AreEqual(1, count);
        }
    }
}
