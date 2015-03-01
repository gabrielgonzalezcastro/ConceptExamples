using Interfaces;
using Moq;
using NUnit.Framework;

namespace NUnitTest
{
    [TestFixture]
    public class CalculatorTest
    {
        //needs to be avaible
        Calculator sut;

        //Metodo donde inicializo todos los valores necesarios para las pruebas.
        //Es el primer metodo que se corre antes de cada prueba unitaria.
        [TestFixtureSetUp]
        public void Setup()
        {
            sut = new Calculator();
        }


        [Test]
        public void ShouldValidateAdd()
        {
            Assert.That(sut.Add(1, 1), Is.EqualTo(2));
        }

        //con TestCase puedo probar varios valores la misma prueba unitaria.
        [Test]
        [TestCase(2, 1, 1)]
        [TestCase(10, 5, 5)]
        public void ShouldValidateSubstract(int a, int b, int c)
        {
            Assert.That(sut.Subtract(a, b), Is.EqualTo(c));
        }

        [Test]
        public void ShouldDeclinePrimeNumber()
        {
            //Uso de Mock con framework llamado "MOQ"
            var fakeGateway = new Mock<ICheckPrimeNumberGateway>();
            sut = new Calculator(fakeGateway.Object);
            Assert.That(sut.IsPrimeNumber(7), Is.False);
        }

        [Test]
        public void ShouldAcceptPrimeNumber()
        {
            //Uso de Mock con framework llamado "MOQ"
            var fakeGateway = new Mock<ICheckPrimeNumberGateway>();
            //configuro el mock para cuando se llame al metodo IsPrimeNumber con cualquier
            //numero retorne true
            fakeGateway.Setup(x => x.IsPrimeNumber(It.IsAny<int>())).Returns(true);

            sut = new Calculator(fakeGateway.Object);
            Assert.That(sut.IsPrimeNumber(30), Is.True);
        }

        //Metodo donde libero todo lo que se necesite. 
        //Es el metodo que se corre despues de ejecutar cada prueba unitaria.
        [TestFixtureTearDown]
        public void TearDown()
        {
            sut = null;



        }


    }
}
