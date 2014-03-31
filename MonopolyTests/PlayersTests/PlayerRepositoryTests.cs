using System.Linq;
using Monopoly.Players;
using NUnit.Framework;

namespace MonopolyTests.PlayersTests
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
            horse = new Player(0, "Horse");
            car = new Player(1, "Car");
            playerRepository = new PlayerRepository(new IPlayer[] { horse, car });
        }

        [Test]
        public void TestCreatePlayerRepositoryWithTwoPlayersGetCountReturnsTwo()
        {
            Assert.That(playerRepository.GetPlayerIds().Count(), Is.EqualTo(2));
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

            Assert.That(playerRepository.GetPlayerIds().Count(), Is.EqualTo(1));
        }

        [Test]
        public void TestShufflePlayersReordersPlayers()
        {
            var dog = new Player(2, "Dog");
            var thimble = new Player(3, "Thimble");
            var shoe = new Player(4, "Shoe");
            playerRepository = new PlayerRepository(new IPlayer[] { horse, car, dog, thimble, shoe });
            var orderedPlayers = playerRepository.GetPlayerIds();
            playerRepository.ShufflePlayers();
            var shuffledPlayers = playerRepository.GetPlayerIds();

            Assert.That(orderedPlayers.Equals(shuffledPlayers), Is.False);
        }
    }
}
