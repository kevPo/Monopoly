using System;

namespace Monopoly.Assessors
{
    public class IncomeTaxAssessor : LocationAssessor
    {
        public override void HandleLocationStopFor(IPlayer player)
        {
            if (player.Balance > 2000)
                player.PayTax(200);
            else
                player.PayTax(Convert.ToInt32(player.Balance * .1));
        }
    }
}
