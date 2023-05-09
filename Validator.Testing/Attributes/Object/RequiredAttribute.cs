using Validator.Extensions;

namespace Validator.Testing.Attributes.Object
{
    /// <summary>
    /// RequiredAttribute�̃e�X�e�B���O�N���X�ł��B
    /// </summary>
    [TestClass]
    public class RequiredAttributeTest
    {
        [TestMethod]
        public void �I�u�W�F�N�g��Null�̏ꍇ()
        {
            Model target = new();

            var errors = target.Validate(false);

            var count = errors.Count();

            Assert.AreEqual(4, count);
        }

        [TestMethod]
        public void �I�u�W�F�N�g��Null�ł͂Ȃ��ꍇ()
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
        public void �J�X�^�����b�Z�[�W��ݒ�()
        {
            Model target = new();

            var errors = target.Validate(false);

            Assert.AreEqual(errors.First(error => error.Name == "Name").Message, "Custom Message.");
        }
    }
}