using System;
using Monopoly.Locations;

namespace Monopoly.Players
{
    public class Player : IPlayer
    {
        public Int32 Id { get; private set; }
        public String Name { get; private set; }

        public Player(Int32 id, String name)
        {
            Id = id;
            Name = name;
        }

        public override Boolean Equals(object other)
        {
            if (other.GetType() != typeof(Player))
                return false;
            else
                return Equals((Player)other);
        }

        public Boolean Equals(Player other)
        {
            return Name == other.Name && Id == other.Id;
        }

        public override Int32 GetHashCode()
        {
            return (Name.GetHashCode() ^ 2) + (Id.GetHashCode() ^ 2) * 17;
        }
    }
}
