namespace Monopoly.Assessors
{
    public class GoToJailAssessor : LocationAssessor
    {
        public override void HandleLocationStopFor(IPlayer player)
        {
            player.GoDirectlyTo("Jail/ Just Visiting");
        }
    }
}
