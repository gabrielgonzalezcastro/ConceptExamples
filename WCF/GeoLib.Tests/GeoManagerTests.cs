﻿using GeoLib.Contracts;
using GeoLib.Data;
using GeoLib.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GeoLib.Tests
{
    [TestClass]
    public class GeoManagerTests
    {
        [TestMethod]
        public void test_zip_code_retrieval()
        {
            //Arrange
            var mockZipCodeRepository = new Mock<IZipCodeRepository>();

            var zipCode = new ZipCode
            {
                City = "Lincoln Park",
                State = new State{Abbreviation = "NJ"},
                Zip = "07035"
            };

            mockZipCodeRepository.Setup(x => x.GetByZip(It.IsAny<string>())).Returns(zipCode);
            IGeoService geoService = new GeoManager(mockZipCodeRepository.Object, null);
            
            //Act
            ZipCodeData actual = geoService.GetZipInfo("07035");

            //Assert
            Assert.AreEqual(actual.City.ToUpper(), "LINCOLN PARK");
        }
    }
}
