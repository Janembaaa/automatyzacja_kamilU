using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Automaty1
{
    public class MathematicsTests
    {
        [Fact]
        public void Method_add_returns_sum_of_given_values()
        {
            // arrange
            var math = new Mathematics();

            // act
            var result = math.Add(10, 20);

            // assert
            Assert.Equal(30, result);
        }

        [Fact]
        public void Method_add_returns_sum_of_positive_and_negative_numbers()
        {
            // arrange
            var math = new Mathematics();

            // act
            var result = math.Add(10, -20);

            // assert
            Assert.Equal(-10, result);
        }

        [Fact]
        public void Method_substract_returns_substract_of_given_values()
        {
            // arrange
            var math = new Mathematics();

            // act
            var result = math.Substract(20, 10);

            // assert
            Assert.Equal(10, result);
        }

        [Fact]
        public void Method_substruct_returns_substract_of_positive_and_negative_numbers()
        {
            // arrange
            var math = new Mathematics();

            // act
            var result = math.Substract(10, -20);

            // assert
            Assert.Equal(30, result);
        }

        [Fact]
        public void Method_multiply_return_multiplication_of_given_values()
        {
            // arrange
            var math = new Mathematics();

            // act
            var result = math.Multiply(10, 10);

            // assert
            Assert.Equal(100, result);
        }

        [Fact]
        public void Method_multiply_return_multiplication_positive_and_negative_numbers()
        {
            // arrange
            var math = new Mathematics();

            // act
            var result = math.Multiply(10, -5);

            // assert
            Assert.Equal(-50, result);
        }

        [Fact]
        public void Method_divide_return_division_result_of_given_values()
        {
            // arrange
            var math = new Mathematics();

            // act
            var result = math.Divide(10, 5);

            // assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void Method_divide_return_division_result_of_positive_and_negative_numbers()
        {
            // arrange
            var math = new Mathematics();

            // act
            var result = math.Divide(10, -2);

            // assert
            Assert.Equal(-5, result);
        }
    }
}
