using System.Linq;
using Monopoly;
using NUnit.Framework;

namespace MonopolyTests
{
    [TestFixture]
    public class PlayerRepositoryTests
    {
        private IPlayerRepository playerRepository;
        private IPlayer horse;
        private IPlayer car;

        [SetUp]
        public void SetUp()
        {
            horse = new Player("Horse", 2000);
            car = new Player("Car", 2000);
            playerRepository = new PlayerRepository(new IPlayer[] { horse, car });
        }

        [Test]
        public void TestCreatePlayerRepositoryWithTwoPlayersGetCountReturnsTwo()
        {
            Assert.That(playerRepository.GetPlayers().Count(), Is.EqualTo(2));
        }
        
        [Test]
        public void TestGetPlayerWithHorseIdReturnsHorsePlayer()
        {
            Assert.That(playerRepository.GetPlayer(horse.Id), Is.EqualTo(horse));
        }

        [Test]
        public void TestRemoveHorseRemovesHorseFromRepository()
        {
            playerRepository.RemovePlayer(horse.Id);

            Assert.That(playerRepository.GetPlayers().Count(), Is.EqualTo(1));
        }

        [Test]
        public void TestShufflePlayersReordersPlayers()
        {
            var dog = new Player("Dog", 2000);
            var thimble = new Player("Thimble", 2000);
            var shoe = new Player("Shoe", 2000);
            playerRepository = new PlayerRepository(new IPlayer[] { horse, car, dog, thimble, shoe });
            var orderedPlayers = playerRepository.GetPlayers();
            playerRepository.ShufflePlayers();
            var shuffledPlayers = playerRepository.GetPlayers();

            Assert.That(orderedPlayers.Equals(shuffledPlayers), Is.False);
        }
    }
}
