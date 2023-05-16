using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validator.Extensions;

namespace Validator.Testing.Attributes.String
{
    /// <summary>
    /// UrlAttributeのテスティングクラスです。
    /// </summary>
    [TestClass]
    public class UrlAttributeTest
    {
        [TestMethod]
        public void Urlの場合()
        {
            Model9 target = new();

            var errors = target.Validate(false);

            var count = errors.Count();

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void Urlではない場合()
        {
            Model10 target = new();

            var errors = target.Validate(false);

            var count = errors.Count();

            Assert.AreEqual(1, count);
        }
    }
}
