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
            var player = _players.SingleOrDefault(p => p.Id == playerId) ?? 
                throw new ArgumentException("Player not found", nameof(playerId));

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
            _players.Select(p =>
            {
                p.Order = p.Order is default(int) ? 999 : p.Order;
                return p;
            }).ToList()
            .Sort((p1, p2) => p1.Order.CompareTo(p2.Order));

            for ( int i = 0; i < _players.Count; i++ )
            {
                _players[i].Order = i + 1;
            }
        }
    }
}
