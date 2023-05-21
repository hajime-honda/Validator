using Validator.Extensions;
using Validator.Testing.Attributes.Array.Models.Models;

namespace Validator.Testing.Attributes.Array
{
    /// <summary>
    /// LengthAttributeのテスティングクラスです。
    /// </summary>
    [TestClass]
    public class MinLengthAttributeTest
    {
        [TestMethod]
        public void 配列数が満たす場合()
        {
            Models9 target = new();

            var errors = target.Validate();

            var count = errors.Count();

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void 配列数が満たされない場合()
        {
            Models10 target = new();

            var errors = target.Validate();

            var count = errors.Count();

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void 配列プロパティはnullの場合()
        {
            Models11 target = new();

            var errors = target.Validate();

            var count = errors.Count();

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void 属性を付け間違っている場合()
        {
            Models12 target = new();

            try
            {
                var errors = target.Validate();
            }
            catch (NotSupportedException ex) 
            {
                return;
            }

            Assert.Fail();
        }
    }
}
