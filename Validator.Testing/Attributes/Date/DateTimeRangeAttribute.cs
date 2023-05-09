using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validator.Extensions;

namespace Validator.Testing.Attributes.Date
{
    /// <summary>
    /// LengthAttributeのテスティングクラスです。
    /// </summary>
    [TestClass]
    public class DateTimeRangeAttributeTest
    {
        [TestMethod]
        public void 範囲を満たす指定の場合()
        {
            Model target = new();

            var errors = target.Validate(false);

            var count = errors.Count();

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void 範囲を満たさない指定の場合()
        {
            Model2 target = new();

            var errors = target.Validate(false);

            var count = errors.Count();

            Assert.AreEqual(3, count);
        }

        [TestMethod]
        public void スタートの日時文字列がおかしい場合()
        {
            Model4 target = new();

            try
            {
                var errors = target.Validate(false);
                var count = errors.Count(); 
            }
            catch (FormatException)
            {
                return;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void エンドの日時文字列がおかしい場合()
        {
            Model3 target = new();

            try
            {
                var errors = target.Validate(false);
                var count = errors.Count();
            }
            catch (FormatException)
            {
                return;
            }


            Assert.Fail();
        }

        [TestMethod]
        public void 期間の指定がない場合()
        {
            Model5 target = new();

            try
            {
                var errors = target.Validate(false);
                var count = errors.Count();
            }
            catch (ArgumentNullException)
            {
                return;
            }

            Assert.Fail();
        }
    }
}
