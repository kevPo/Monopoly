namespace Monopoly.Assessors
{
    public class LuxuryTaxAssessor : LocationAssessor
    {
        public override void HandleLocationStopFor(IPlayer player)
        {
            player.PayTax(75);
        }
    }
}
