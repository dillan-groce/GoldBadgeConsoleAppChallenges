using _01_KomodoClaims_Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _01_KomodoClaims_Tests
{
    [TestClass]
    public class ClaimsTests
    {
        [TestMethod]
        public void Test_AddClaim()
        {
            Claim claim = new Claim();
            ClaimsRepo repo = new ClaimsRepo();
            bool addClaim = repo.AddClaim(claim);
            Assert.IsTrue(addClaim);
        }
        [TestMethod]
        public void Test_GetClaims()
        {
            Claim claim = new Claim();
            ClaimsRepo repo = new ClaimsRepo();
            repo.AddClaim(claim);
            Queue<Claim> claims = repo.GetAllClaims();
            bool hasClaim = claims.Contains(claim);
            Assert.IsTrue(hasClaim);
        }
        [TestMethod]
        public void Test_PeekClaim()
        {
            Claim claim = new Claim();
            ClaimsRepo repo = new ClaimsRepo();
            repo.AddClaim(claim);
            Claim nextClaim = repo.PeekClaim();
            Assert.AreEqual(nextClaim, claim);
        }
        [TestMethod]
        public void Test_DequeueClaim()
        {
            Claim claim = new Claim();
            ClaimsRepo repo = new ClaimsRepo();
            repo.AddClaim(claim);
            bool dequeuedClaim = repo.DequeueClaim();
            Assert.IsTrue(dequeuedClaim);
        }
    }
}
