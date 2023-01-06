using LimboOfCeres.Scripts.Shared.Interfaces;


namespace LimboOfCeres.Scripts.Difficulty
{
    public abstract class LimitedUpgradable : Upgradable
    {
        protected abstract bool IsAtLimit { get; }

        public override void Upgrade()
        {
            if (IsAtLimit) return;
        }
    }
}
