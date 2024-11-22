using Runtime.Data.ValueObjects;
using Runtime.Managers;

namespace Runtime.Commands.Player
{
    public class ForceBallsToPoolCommand
    {
        private PlayerManager _manager;
        private PlayerForceData _data;
        
        
        public ForceBallsToPoolCommand(PlayerManager manager, PlayerForceData forceData)
        {
            _manager = manager;
            _data = forceData;
        }

        internal void Execute()
        {
            
        }
    }
}