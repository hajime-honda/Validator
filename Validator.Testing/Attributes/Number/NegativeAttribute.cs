using Validator.Extensions;

namespace Validator.Testing.Attributes.Number
{
    /// <summary>
    /// NegativeAttributeのテスティングクラスです。
    /// </summary>
    [TestClass]
    public class NegativeAttributeTest
    {
        [TestMethod]
        public void マイナスの場合()
        {
            Model9 target = new();

            var errors = target.Validate(false);

            var count = errors.Count();

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void マイナスではない場合()
        {
            Model10 target = new();

            var errors = target.Validate(false);

            var count = errors.Count();

            Assert.AreEqual(1, count);
        }
    }
}
