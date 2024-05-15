using Microsoft.Extensions.Logging;
using Moq;
using StringManipulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StringManipulationTest
{
    
    public class StringOperationTest
    {

        [Fact]
        public void ConcantenateString()
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.ConcatenateStrings("Hello", "Platzi");

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal("Hello Platzi", result);
        }

        [Fact(Skip = "Razón para omitir la prueba")]
        public void IsPalindrome_True()
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.IsPalindrome("ama");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsPalindrome_False()
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.IsPalindrome("hello");

            // Assert
            Assert.False(result);
        }


        [Fact]
        public void QuantintyInWords()
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.QuantintyInWords("cat", 10);

            //Assert
            Assert.StartsWith("ten", result);
            Assert.Contains("cat", result);

        }

        [Fact]
        public void GetStringLength_Exception()
        {
            var strOperations = new StringOperations();

            Assert.ThrowsAny<ArgumentNullException>(() => strOperations.GetStringLength(null));
        }

        [Fact]
        public void GetStringLength()
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.GetStringLength("dies");


            //Assert
            Assert.NotNull(result);
            Assert.Equal(4,result);
                

        }

        [Fact]
        public void TruncateString_Excetion() 
        {
           // Arrange
            var strOperations = new StringOperations();

            //Assert
            Assert.ThrowsAny<ArgumentOutOfRangeException>(() => strOperations.TruncateString("0", 0));
        }



        [Theory]
        [InlineData("V", 5)]
        [InlineData("III", 3)]
        [InlineData("X", 10)]
        public void FromRomanToNumber(string romanNumber, int expected)
        {
            var strOperations = new StringOperations();

            var result = strOperations.FromRomanToNumber(romanNumber);

            Assert.Equal(expected, result);
        }


        [Fact]
        public void CountOccurrences()
        {
            var mockLogger = new Mock<ILogger<StringOperations>>();
            var strOperations = new StringOperations(mockLogger.Object);

            var result = strOperations.CountOccurrences("Hello platzi", 'l');

            Assert.Equal(3, result);
        }

        [Fact]
        public void ReadFile()
        {
            var strOperations = new StringOperations();
            var mookReadFile = new Mock<IFileReaderConector>();
            //It.IsAny<string>()  Permite ue cualquier nombre archivo sea permito 
            mookReadFile.Setup(p => p.ReadString(It.IsAny<string>())).Returns("Estoy en moq de prueba");

            //Se simula un archivo con un nombre specificop. 
            //mookReadFile.Setup(p => p.ReadString("text2.txt")).Returns("Estoy en moq de prueba");

            var result = strOperations.ReadFile(mookReadFile.Object, "text2.txt");

            Assert.Equal("Estoy en moq de prueba", result);
        }

    }

}

