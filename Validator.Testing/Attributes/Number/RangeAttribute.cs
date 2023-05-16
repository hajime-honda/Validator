using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validator.Extensions;

namespace Validator.Testing.Attributes.Number
{
    /// <summary>
    /// RangeAttributeのテスティングクラスです。
    /// </summary>
    [TestClass]
    public class RangeAttributeTest
    {
        [TestMethod]
        public void 満たす範囲の場合()
        {
            Model13 target = new();

            var errors = target.Validate(false);

            var count = errors.Count();

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void 満たさない範囲の場合1()
        {
            Model14 target = new();

            var errors = target.Validate(false);

            var count = errors.Count();

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void 満たさない範囲の場合2()
        {
            Model15 target = new();

            var errors = target.Validate(false);

            var count = errors.Count();

            Assert.AreEqual(1, count);
        }
    }
}
