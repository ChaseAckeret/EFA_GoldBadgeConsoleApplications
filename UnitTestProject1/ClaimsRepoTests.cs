using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Claims;

namespace Claims_TestMethods
{
    [TestClass]
    public class ClaimsRepoTests
    {
        private ClaimsRepo _repo;
        private Claim _content;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimsRepo();
            _content = new Claim(515, ClaimType.Car, "Fender Bender", 1000.00m,new DateTime(2020, 12, 1),new DateTime(2020, 12, 20), true);

            _repo.AddClaim(_content);
        }
        

        [TestMethod]
        public void AddToQueue_ShouldNotGetNull()
        {
            //Arrange
            //Act
            
        }
    }
}
