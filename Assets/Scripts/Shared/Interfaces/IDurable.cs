namespace LimboOfCeres.Scripts.Shared.Interfaces
{
    public interface IDurable
    {
        int CurrentDurability { get; }
        int MaxDurability { get; }
        int InitialDurability { get; }
    }
}
