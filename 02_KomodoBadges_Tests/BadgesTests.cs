using _02_KomodoBadges_Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _02_KomodoBadges_Tests
{
    [TestClass]
    public class BadgesTests
    {
        private BadgeRepo _repo;
        private Badge _badge;

        [TestInitialize]
        public void Arrange()
        {
            List<string> _doors = new List<string>();
            _doors.Add("A7");
            _doors.Add("B6");
            _doors.Add("J8");
            _repo = new BadgeRepo();
            _badge = new Badge(12345, _doors) ;
        }
        [TestMethod]
        public void Test_AddBadge()
        {
            bool wasAdded = _repo.AddBadge(_badge);
            Assert.IsTrue(wasAdded);
        }
        [TestMethod]
        public void Test_DeleteBadge()
        {
            _repo.AddBadge(_badge);
            bool wasDeleted =_repo.DeleteBadge(_badge);
            Assert.IsTrue(wasDeleted);
        }
        [TestMethod]
        public void Test_UpdateBadge()
        {
            _repo.AddBadge(_badge);
            _badge.Doors = _repo.UpdateExistingBadge(12345,);
        }
        [TestMethod]
        public void Test_GetABadgeByID()
        {

        }
        [TestMethod]
        public void Test_GetAllBadges()
        {

        }
    }
}
