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
            horse = new Player(0, "Horse", 2000);
            car = new Player(1, "Car", 2000);
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
            var dog = new Player(2, "Dog", 2000);
            var thimble = new Player(3, "Thimble", 2000);
            var shoe = new Player(4, "Shoe", 2000);
            playerRepository = new PlayerRepository(new IPlayer[] { horse, car, dog, thimble, shoe });
            var orderedPlayers = playerRepository.GetPlayers();
            playerRepository.ShufflePlayers();
            var shuffledPlayers = playerRepository.GetPlayers();

            Assert.That(orderedPlayers.Equals(shuffledPlayers), Is.False);
        }

        [Test]
        public void TestSetAllPlayerLocationsToZeroSetsAllPlayersLocationsToZero()
        {
            playerRepository.SetAllPlayerLocationsTo(0);
            var players = playerRepository.GetPlayers();

            foreach (var player in players)
                Assert.That(player.LocationIndex, Is.EqualTo(0));
        }

        [Test]
        public void TestGetLocationIndexForPlayerAtThreeReturnsThree()
        {
            playerRepository.SetAllPlayerLocationsTo(3);

            Assert.That(playerRepository.GetPlayer(0).LocationIndex, Is.EqualTo(3));
        }
    }
}
