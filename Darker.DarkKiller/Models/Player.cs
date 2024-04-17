namespace Darker.DarkKiller.Models
{
    public class Player
    {
        public Guid Id {  get; set; } = Guid.NewGuid();

        public required string DisplayName { get; set; }

        public int TargetNumber { get; set; }

        public int Lives { get; set; }

        public int Order { get; set; }
    }
}
