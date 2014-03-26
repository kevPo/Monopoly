using System;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly.Locations.Propertys
{
    public class Utility : Property
    {
        private IEnumerable<Utility> utilities;
        private IDice dice;

        public Utility(Int32 index, String name, Int32 cost, Int32 rent, IPlayerService playerService,
                       IEnumerable<Utility> utilities, IDice dice)
            : base(index, name, cost, rent, playerService)
        {
            this.utilities = utilities;
            this.dice = dice;
        }

        protected override Int32 CalculateRent()
        {
            var utilitiesOwned = utilities.Count(u => u.isOwned);

            if (utilitiesOwned == 1)
                return 4 * dice.GetCurrentRoll();

            return 10 * dice.GetCurrentRoll();
        }
    }
}
