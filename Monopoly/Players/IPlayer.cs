using System;
namespace Monopoly.Players
{
    public interface IPlayer
    {
        Int32 Id { get; }
        String Token { get; }
    }
}
