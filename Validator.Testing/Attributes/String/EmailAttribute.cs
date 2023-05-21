using Validator.Extensions;

namespace Validator.Testing.Attributes.String
{
    /// <summary>
    /// EmailAttributeのテスティングクラスです。
    /// </summary>
    [TestClass]
    public class EmailAttributeTest
    {
        [TestMethod]
        public void メールアドレスである場合()
        {
            Model1 target = new();

            var errors = target.Validate();

            var count = errors.Count();

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void メールアドレスではない場合()
        {
            Model2 target = new();

            var errors = target.Validate();

            var count = errors.Count();

            Assert.AreEqual(1, count);
        }
    }
}
