using ConsoleApp1;
using System;
using Xunit;

namespace Lab01.Tests
{
    public class UserTests
    {
        [Fact]
        public void TestNameLastnameEmailId()
        {
            //Arrange
            var user1 = new User(1,"John", "Doe", "hello@world.com");
            user1.FirstName = "John";
            user1.LastName = "Doe";
            user1.Email = "hello@world.com";
            var expected_name = "Doe, John";
            var expected_id = 1;
            var expected_email = "hello@world.com";

            //Act
            var actual_name = user1.FullName;
            var actual_id = user1.Id;
            var actual_email = user1.Email;

            //Assert
            Assert.Equal(expected_name, actual_name);
            Assert.Equal(expected_id, actual_id);
            Assert.Equal(expected_email, actual_email);
        }

        [Fact]
        public void TestFullnameNoFirstname()
        {
            //Arrange
            var customer = new User { LastName = "Doe" };

            var expected = "Doe";

            //Act
            var actual = customer.FullName;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FullNameNoLastNameTest()
        {
            //Arrange
            var customer = new User { FirstName = "John" };

            var expected = "John";

            //Act
            var actual = customer.FullName;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValidateValid()
        {
            //Arrange
            var customer = new User() { FirstName = "John", LastName = "Doe", Email = "hello@world.com" };

            //Act
            var actual = customer.Validate();

            //Assert
            Assert.True(actual);
        }

        [Fact]
        public void ValidateNoName()
        {
            //Arrange
            var customer = new User() { Email = "hello@world.com" };

            //Act
            var actual = customer.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ValidateNoEmail()
        {
            //Arrange
            var customer = new User() { FirstName = "John", LastName = "Doe" };

            //Act
            var actual = customer.Validate();

            //Assert
            Assert.False(actual);
        }
    }
}
