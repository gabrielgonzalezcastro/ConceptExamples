using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DependencyInjection_InConstructor
{
    [TestClass]
    public class ClientTests
    {
        private Mock<IService> _mockIservice;
        
        [TestInitialize]
        public void Setup()
        {
            _mockIservice = new Mock<IService>();
        }


        [TestMethod]
        public void ContarNombres_ShouldReturnTheCorrectNumberOfNames_WheAListOfNamesIsSpecified()
        {
            //Arrange
            var listaNombres = new List<string> { "nombre1", "nombre2", "nombre3" };
            _mockIservice.Setup(x => x.GetNames()).Returns(listaNombres);
            var sut = new Client(_mockIservice.Object);

            //Act
            var actual = sut.CountNames();
            //Assert
            Assert.AreEqual(3,actual);


        }
    }
}
