using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly;
using Monopoly.TraditionalMonopoly;
using NUnit.Framework;

namespace MonopolyTests.TraditionalMonopolyTests
{
    [TestFixture]
    public class TraditionalGameDriverTests
    {
        private IGameDriver gameDriver;

        [SetUp]
        public void SetUp()
        {
            gameDriver = new TraditionalGameDriver();
        }

        [Test]
        public void TestCreateGameWithOnePlayerFails()
        {
            Assert.Throws<InvalidOperationException>(() => gameDriver.PlayGameWith(new[] { new Player("Horse", 0) }));
        }

        [Test]
        public void TestCreateGameWithNinePlayersFails()
        {
            var players = new[] 
            { 
                new Player("Horse", 0),
                new Player("Cat", 0),
                new Player("Wheelbarrow", 0),
                new Player("Battleship", 0),
                new Player("Thimble", 0),
                new Player("Top Hat", 0),
                new Player("Boot", 0),
                new Player("Scottie dog", 0),
                new Player("Racecar", 0)
            };
            Assert.Throws<InvalidOperationException>(() => gameDriver.PlayGameWith(players));
        }
    }
}
