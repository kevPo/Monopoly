using System;
using Monopoly;
using NUnit.Framework;

namespace MonopolyTests
{
    [TestFixture]
    public class PlayerServiceTests
    {
        private PlayerService playerService;
        private PlayerRepository playerRepository;

        [SetUp]
        public void SetUp()
        {
            var players = new[]
                {
                    new Player(0, "Horse", 1500),
                    new Player(1, "Car", 1500),
                    new Player(2, "Dog", 1500)
                };
            playerRepository = new PlayerRepository(players);
            playerService = new PlayerService(playerRepository);
        }

        [Test]
        public void TestRemove100FromHorseRemoves100FromBalance()
        {
            playerService.RemoveMoneyFrom(0, 100);
            var player = playerRepository.GetPlayer(0);

            Assert.That(player.Balance, Is.EqualTo(1400));
        }

        [Test]
        public void TestAdd100ToHorseAdds100ToBalance()
        {
            playerService.AddMoneyTo(0, 100);
            var player = playerRepository.GetPlayer(0);

            Assert.That(player.Balance, Is.EqualTo(1600));
        }

        [Test]
        public void TestChargeTenDollarTaxFunctionChargesRemovesTenFromBalance()
        {
            playerService.ChargeTaxesTo(0, TaxEquation);
            var player = playerRepository.GetPlayer(0);

            Assert.That(player.Balance, Is.EqualTo(1490));
        }

        private Int32 TaxEquation(Int32 balance)
        {
            return 10;
        }

        [Test]
        public void TestTransfer100FromHorseToCarTransfersSuccessfully()
        {
            playerService.TransferMoney(0, 1, 100);
            var givingPlayer = playerRepository.GetPlayer(0);
            var receivingPlayer = playerRepository.GetPlayer(1);

            Assert.That(givingPlayer.Balance, Is.EqualTo(1400));
            Assert.That(receivingPlayer.Balance, Is.EqualTo(1600));
        }
    }
}
