using Validator.Extensions;

namespace Validator.Testing.Attributes.Number
{
    /// <summary>
    /// IntegerAttributeのテスティングクラスです。
    /// </summary>
    [TestClass]
    public class IntegerAttributeTest
    {
        [TestMethod]
        public void 整数の場合()
        {
            Model target = new();

            var errors = target.Validate();

            var count = errors.Count();

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void 整数ではない場合()
        {
            Model2 target = new();

            var errors = target.Validate();

            var count = errors.Count();

            Assert.AreEqual(1, count);
        }
    }
}
