using System;
using Monopoly.JailRoster;
namespace Monopoly.Cards.Commands
{
    public class GetOutOfJailFreeCommand : ICommand
    {
        private IJailRoster jailRoster;
        
        public GetOutOfJailFreeCommand(IJailRoster jailRoster)
        {
            this.jailRoster = jailRoster;
        }

        public void PerformOn(Int32 playerId)
        {
            jailRoster.Remove(playerId);
        }
    }
}
