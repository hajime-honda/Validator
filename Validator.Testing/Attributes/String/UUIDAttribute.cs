using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validator.Extensions;

namespace Validator.Testing.Attributes.String
{
    /// <summary>
    /// UUIDAttributeのテスティングクラスです。
    /// </summary>
    [TestClass]
    public class UUIDAttributeTest
    {
        [TestMethod]
        public void UUIDの場合()
        {
            Model11 target = new();

            var errors = target.Validate(false);

            var count = errors.Count();

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void UUIDではない場合()
        {
            Model12 target = new();

            var errors = target.Validate(false);

            var count = errors.Count();

            Assert.AreEqual(1, count);
        }
    }
}
