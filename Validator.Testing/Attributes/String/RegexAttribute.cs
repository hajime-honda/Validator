using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validator.Extensions;

namespace Validator.Testing.Attributes.String
{
    /// <summary>
    /// RegexAttributeのテスティングクラスです。
    /// </summary>
    [TestClass]
    public class RegexAttributeTest
    {
        [TestMethod]
        public void 正規表現にヒットする場合()
        {
            Model13 target = new();

            var errors = target.Validate(false);

            var count = errors.Count();

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void 正規表現にヒットしない場合()
        {
            Model14 target = new();

            var errors = target.Validate(false);

            var count = errors.Count();

            Assert.AreEqual(1, count);
        }
    }
}
