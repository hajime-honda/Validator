using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validator.Extensions;

namespace Validator.Testing.Attributes.String
{
    /// <summary>
    /// LengthAttributeのテスティングクラスです。
    /// </summary>
    [TestClass]
    public class LengthAttributeTest
    {
        [TestMethod]
        public void 指定の文字数である場合()
        {
            Model3 target = new();

            var errors = target.Validate(false);

            var count = errors.Count();

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void 指定の文字数ではない場合()
        {
            Model4 target = new();

            var errors = target.Validate(false);

            var count = errors.Count();

            Assert.AreEqual(1, count);
        }
    }
}
