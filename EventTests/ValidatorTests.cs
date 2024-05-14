using WpfApp5;
using Xunit;
using Assert = Xunit.Assert;

namespace EventTests
{
    public class ValidatorTests
    {
        [Fact]
        public void EmailTestValid()
        {
            const string email = "valid.email@gmail.com";
            Assert.True(Validator.ValidateEmail(email));
        }
        [Fact]
        public void EmailTestInvalid()
        {
            const string email = "d";
            Assert.False(Validator.ValidateEmail(email));
        }  
        [Fact]
        public void EmailTestEmpty()
        {
            var email = string.Empty;
            Assert.False(Validator.ValidateEmail(email));
        }
        [Fact]
        public void PhoneTestValid()
        {
            const string phone = "88005553535";
            Assert.True(Validator.ValidateNumber(phone));
        }
        [Fact]
        public void PhoneTestInvalid()
        {
            const string phone = "d";
            Assert.False(Validator.ValidateNumber(phone));
        }  
        [Fact]
        public void PhoneTestEmpty()
        {
            var phone = string.Empty;
            Assert.False(Validator.ValidateNumber(phone));
        }

        [Fact]
        public void NameTestValid()
        {
            const string name = "Иванов Иван Иванович";
            Assert.True(Validator.ValidateName(name));
        }
        [Fact]
        public void NameTestInvalid()
        {
            const string name = "3";
            Assert.False(Validator.ValidateName(name));
        }  
        [Fact]
        public void NameTestEmpty()
        {
            var name = string.Empty;
            Assert.False(Validator.ValidateName(name));
        }
    }
}