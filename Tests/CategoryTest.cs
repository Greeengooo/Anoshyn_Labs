using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1;
using Xunit;

namespace Tests
{
    public class CategoryTest
    {
        [Fact]
        public void TestAllFields()
        {
            //Arrange
            Category cat = new Category("test1", "test2", "test3");
            var expected_name = "test1";
            var expected_description = "test2";
            var expected_colour = "test3";          

            //Act
            var actual_name = cat.Name;
            var actual_description = cat.Description;
            var actual_colour = cat.Colour;
           
            //Assert
            Assert.Equal(expected_name, actual_name);
            Assert.Equal(expected_description, actual_description);
            Assert.Equal(expected_colour, actual_colour);
        }
    }
}
