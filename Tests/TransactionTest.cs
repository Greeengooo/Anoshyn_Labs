using ConsoleApp1;
using ConsoleApp1;
using System;
using Xunit;

namespace Tests
{
    public class TransactionTest
    {
        [Fact]
        public void TestAllFields()
        {
            //Arrange
            Transaction tr1 = new Transaction(1, 25000, CurrencyType.Dollar, "text", DateTime.Now);
            Category cat = new Category("Test", "test", "blue");
            tr1.Category = cat;
            var expected_id = 1;
            var expected_sum = 25000;
            var expected_currency = CurrencyType.Dollar;
            var expected_description = "text";
            var expected_date = DateTime.Now.Year;
            var expected_category = cat;

            //Act
            var actual_id = tr1.Id;
            var actual_sum = tr1.Sum;
            var actual_currency = tr1.Currency;
            var actual_description = tr1.Description;
            var actual_date = tr1.Date.Year;
            var actual_category = tr1.Category;

            //Assert
            Assert.Equal(expected_id, actual_id);
            Assert.Equal(expected_sum, actual_sum);
            Assert.Equal(expected_currency, actual_currency);
            Assert.Equal(expected_description, actual_description);
            Assert.Equal(expected_date, actual_date);
            Assert.Equal(expected_category, actual_category);
        }
    }
}
