using LimboOfCeres.Scripts.Shared.Enums;

namespace LimboOfCeres.Scripts.Shared.Interfaces
{
    public interface IUpgradable
    {
        UpgradeStatus Upgrade();
    }
}
