using System;
using Monopoly.Assessors;

namespace Monopoly
{
    public class Location
    {
        public String Name { get; private set; }
        private LocationAssessor assessor;

        public Location(String name, LocationAssessor assessor)
        {
            this.Name = name;
            this.assessor = assessor;
        }

        public void LandedOnBy(IPlayer player)
        {
            assessor.HandleLocationStopFor(player);
        }
    }
}
