using NuGet.Frameworks;
using Validator.Extensions;
using Validator.Models;

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
            Model target = new();

            var errors = GetErros(target.Validate(false));

            var count = errors.Count();

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void 配列数が満たされない場合()
        {
            Model2 target = new();

            var errors = GetErros(target.Validate(false));

            var count = errors.Count();

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void 配列プロパティはnullの場合()
        {
            Model3 target = new();

            var errors = GetErros(target.Validate(false));

            var count = errors.Count();

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void 属性を付け間違っている場合()
        {
            Model4 target = new();

            try
            {
                var errors = GetErros(target.Validate(false));
            }
            catch (NotSupportedException ex) 
            {
                return;
            }

            Assert.Fail();
        }

        private IEnumerable<Error> GetErros(IEnumerable<Error> errors)
        {
            return errors.Where(error => error.Type == "ArrayMinLength").ToArray();
        }
    }
}
