using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Badges;
using System.Collections.Generic;

namespace Badges_TestMethods
{
    [TestClass]
    public class BadgeRepoTests
    {

        private BadgesRepo _repo;
        private Badge _content;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgesRepo();

            List<string> doors1 = new List<string>();
            doors1.Add("A1");
            doors1.Add("A2");
            doors1.Add("A3");

            _content = new Badge(5001, doors1);

            _repo.AddToAccessList(_content);
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
