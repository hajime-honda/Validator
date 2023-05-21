namespace Validator.Testing.Attributes.Object
{
    /// <summary>
    /// ICustomValidatorのテスティングクラスです。
    /// </summary>
    [TestClass]
    public class CustomTest
    {
        [TestMethod]
        public void カスタム検証が呼び出されエラーにならない()
        {
            Models2 models2 = new();
            models2.Age = 1000;

            var error = models2.Validate();

            Assert.AreEqual(error.Count(), 0);
        }

        [TestMethod]
        public void カスタム検証が呼び出されエラーなる()
        {
            Models2 models2 = new();

            models2.Name = "jiro";
            models2.Age = 180;

            var error = models2.Validate();

            Assert.AreEqual(error.Count(), 1);
        }
    }
}
