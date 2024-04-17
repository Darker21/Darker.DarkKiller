using Darker.DarkKiller.Models;

namespace Darker.DarkKiller.State
{
    public class GameState
    {
        private List<Player> _players = new List<Player>();

        public List<Player> Players { get => _players; }

        public void AddPlayer(Player player)
        {
            _players.Add(player);
            NotifyStateChanged();
        }

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
