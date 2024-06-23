using Darker.DarkKiller.Models;

namespace Darker.DarkKiller.Test.BusinessLogic.GameState;

internal static class TestData
{
    public static Guid _player1Id = Guid.Parse("758345C9-C841-46F2-AD66-0C8071196875");

    public static Player _player1 = new Player
    {
        Id = _player1Id,
        DisplayName = "Player 1",
        Lives = 2,
        Order = 1,
        TargetNumber = 1,
    };

    public static Player _player2 = new Player
    {
        Id = Guid.NewGuid(),
        DisplayName = "Player 2",
        Lives = 1,
        Order = 2,
        TargetNumber = 17,
    };

    public static Player ValidPlayer => new()
    {
        Id = Guid.NewGuid(),
        DisplayName = "Test",
        Order = 1,
        Lives = default!,
        TargetNumber = 17,
    };
}
