
using NUnit.Framework;
using Interfaces;


namespace NUnitTest
{
    //TestFixture permite que la classe sea para prueba
    [TestFixture]
    public class PointTest // la convencion de nombre es el nombre de la clase que se va a probar mas la palabra TESTS
    {

        [Test]
        [TestCase(1,1,2)]
        [TestCase(1,-1,0)]
        [TestCase(-5, -1, -6)]
        public void ShouldSumTwoNumbers(int a, int b, int expectedResult)
        { 
            //Arrange
            var sut = new Point();

            //Act
            var result = sut.Suma(a, b);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));

            
        }


    }
}
