using Validator.Extensions;

namespace Validator.Testing.Attributes.Number
{
    /// <summary>
    /// PositiveAttributのテスティングクラスです。
    /// </summary>
    [TestClass]
    public class PositiveAttributeTest
    {
        [TestMethod]
        public void プラスの場合()
        {
            Model11 target = new();

            var errors = target.Validate();

            var count = errors.Count();

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void マイナスの場合()
        {
            Model12 target = new();

            var errors = target.Validate();

            var count = errors.Count();

            Assert.AreEqual(1, count);
        }
    }
}
