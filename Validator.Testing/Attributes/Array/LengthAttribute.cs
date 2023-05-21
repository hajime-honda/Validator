using Validator.Extensions;
using Validator.Testing.Attributes.Array.Models.Length;

namespace Validator.Testing.Attributes.Array
{
    /// <summary>
    /// LengthAttributeのテスティングクラスです。
    /// </summary>
    [TestClass]
    public class LengthAttributeTest
    {
        [TestMethod]
        public void 配列数が満たす場合()
        {
            Models1 target = new();

            var errors = target.Validate();

            var count = errors.Count();

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void 配列数が満たされない場合()
        {
            Models2 target = new();

            var errors = target.Validate();

            var count = errors.Count();

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void 配列プロパティはnullの場合()
        {
            Models3 target = new();

            var errors = target.Validate();

            var count = errors.Count();

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void 属性を付け間違っている場合()
        {
            Models4 target = new();

            try
            {
                var errors = target.Validate();
            }
            catch
            {
                return;
            }

            Assert.Fail();
        }
    }
}
