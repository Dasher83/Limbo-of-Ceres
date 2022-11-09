namespace QuarkAcademyJam1Team1.Scripts.Shared.Interfaces
{
    public interface IDurable
    {
        int CurrentDurability { get; }
        int MaxDurability { get; }
        int InitialDurability { get; }
    }
}
