using Validator.Extensions;

namespace Validator.Testing.Attributes.Object
{
    /// <summary>
    /// RequiredAttributeのテスティングクラスです。
    /// </summary>
    [TestClass]
    public class RequiredAttributeTest
    {
        [TestMethod]
        public void オブジェクトがNullの場合()
        {
            Model target = new();

            var errors = target.Validate(false);

            var count = errors.Count();

            Assert.AreEqual(4, count);
        }

        [TestMethod]
        public void オブジェクトがNullではない場合()
        {
            Model target = new();
            target.Name = "taro";
            target.Friends.Add("jiro");
            target.Age = 20;
            target.Storages = target.Storages.Append("somethings...");

            var errors = target.Validate(false);

            var count = errors.Count();

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void カスタムメッセージを設定()
        {
            Model target = new();

            var errors = target.Validate(false);

            Assert.AreEqual(errors.First(error => error.Name == "Name").Message, "Custom Message.");
        }
    }
}