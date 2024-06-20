using Darker.DarkKiller.Models;

namespace Darker.DarkKiller.State
{
    public class GameState
    {
        private List<Player> _players = new List<Player>();

        public List<Player> Players { get => _players; }

        public event Action? OnChange;

        public void AddPlayer(Player player)
        {
            _players.Add(player);
            ReorganiseThrowOrder();
            NotifyStateChanged();
        }

        public void RemovePlayer(Guid playerId)
        {
            var player = _players.Single(p => p.Id == playerId);
            _players.Remove(player);
            NotifyStateChanged();
        }

        public void SwitchPlayers(Player playerMoving, Player playerToSwitch)
        {
            var originalIndex = _players.IndexOf(playerMoving);
            var newIndex = _players.IndexOf(playerToSwitch);

            playerMoving.Order = newIndex + 1;
            playerToSwitch.Order = originalIndex + 1;

            var temp = _players[originalIndex];
            _players[originalIndex] = _players[newIndex];
            _players[newIndex] = temp;

            ReorganiseThrowOrder();
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();

        private void ReorganiseThrowOrder()
        {
            var fixedThrowOrder = new List<Player>();

            var sortedPlayers = _players.OrderBy(p => p.Order).ToList();
            for ( var i = 0; i < sortedPlayers.Count; i++ )
            {
                sortedPlayers[i].Order = i + 1;
                fixedThrowOrder.Add(sortedPlayers[i]);
            }

            _players = fixedThrowOrder;
        }
    }
}
