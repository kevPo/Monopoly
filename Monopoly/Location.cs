using System;

namespace Monopoly
{
    public class Location
    {
        public Int32 Id { get; private set; }
        public String Name { get; private set; }

        public Location(Int32 id, String name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
