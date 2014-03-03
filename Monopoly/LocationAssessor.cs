using System;

namespace Monopoly
{
    public class LocationAssessor : ILocationAssessor
    {
        public Int32 GetAssesmentFor(String location, Int32 playerBalance)
        {
            if (location == "Income Tax")
                return Convert.ToInt32(playerBalance * -.1);

            return 0;
        }
    }
}
