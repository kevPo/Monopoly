using System;

namespace Monopoly
{
    public class LocationAssessor : ILocationAssessor
    {
        public MovementResult GetAssesmentFor(String location, Int32 playerBalance)
        {
            var currentLocation = location;
            var currencyGained = 0;
            if (location == "Go To Jail")
            {
                currentLocation = "Jail/ Just Visiting";
            }
            else if (location == "Luxury Tax")
            {
                currencyGained = -75;
            }
            else
            {
                if (location == "Income Tax")
                {
                    if (playerBalance > 2000)
                        currencyGained = -200;
                    else
                        currencyGained = Convert.ToInt32(playerBalance * -.1);
                }
            }

            return new MovementResult(currentLocation, playerBalance + currencyGained);
        }
    }
}
