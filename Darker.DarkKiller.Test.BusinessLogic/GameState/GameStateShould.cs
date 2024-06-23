using System.ComponentModel;
using static Darker.DarkKiller.Test.BusinessLogic.GameState.TestData;

namespace Darker.DarkKiller.Test.BusinessLogic.GameState;

[Category("BusinessLogic")]
public class GameStateShould
{
    [Theory]
    [InlineData(default(int))]
    [InlineData(32)]
    public void AddingNewPlayerShouldReindexThrowOrder(int initialOrderValue)
    {
        var state = new State.GameState();
        state.Players.Add(_player1);
        state.Players.Add(_player2);

        var playerAdding = ValidPlayer;
        playerAdding.Order = initialOrderValue;
        state.AddPlayer(playerAdding);

        Assert.Equal(3, state.Players.Count);
        Assert.Equal(playerAdding.Id, state.Players.Last().Id);
        Assert.Equal(state.Players.Count, state.Players.Last().Order);
    }

    [Fact]
    public void RemovingUnknownPlayerThrowsArgumentException()
    {
        var state = new State.GameState();

        Assert.Throws<ArgumentException>(() => state.RemovePlayer(_player1Id));
    }

    [Fact]
    public void RemovingPlayerShouldRemovePlayerFromGameState()
    {
        var state = new State.GameState();
        state.Players.Add(_player1);
        state.Players.Add(_player2);

        state.RemovePlayer(_player1Id);

        Assert.DoesNotContain(state.Players, p => p.Id == _player1Id);
    }

    [Fact]
    public void EnsureSwitchPlayersSwitchesIndexes()
    {
        var playerSwitchy = ValidPlayer;

        var state = new State.GameState();
        state.Players.Add(_player1);
        state.Players.Add(playerSwitchy);

        state.SwitchPlayers(_player1, playerSwitchy);

        Assert.True(state.Players.IndexOf(playerSwitchy) == 0);
        Assert.True(state.Players.IndexOf(_player1) == 1);
    }
}
