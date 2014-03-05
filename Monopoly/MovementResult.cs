using System;
using Monopoly.Locations;

namespace Monopoly
{
    public class MovementResult
    {
        public Location Location { get; private set; }
        public Int32 PassedStartCount { get; private set; }

        public MovementResult(Location location, Int32 passedStartCount)
        {
            this.Location = location;
            this.PassedStartCount = passedStartCount;
        }
    }
}
