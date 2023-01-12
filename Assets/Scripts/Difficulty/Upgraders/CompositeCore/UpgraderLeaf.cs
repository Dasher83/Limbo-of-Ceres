using LimboOfCeres.Scripts.Shared.Enums;

namespace LimboOfCeres.Scripts.Difficulty.Upgraders.CompositeCore
{
    public abstract class UpgraderLeaf : Upgrader
    {
        protected override bool IsComposite => false;

        public override bool IsAtLimit => false;

        public override UpgradeStatus Upgrade()
        {
            return UpgradeStatus.FAILED;
        }
    }
}
