using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Shared.Enums;
using LimboOfCeres.Scripts.Shared.Interfaces;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders.CompositeCore
{
    public abstract class Upgrader : MonoBehaviour
    {
        public abstract bool IsAtLimit { get; }

        protected abstract bool IsComposite { get; }

        public UpgradeStatus Upgrade()
        {
            if (IsAtLimit)
            {
                OnLimitReachedHook();
                return UpgradeStatus.FAILED;
            }

            OnUpgradeHook();
            return UpgradeStatus.SUCCESSFUL;
        }

        protected virtual void OnUpgradeHook() { }

        protected virtual void OnLimitReachedHook()
        {
            gameObject.SetActive(false);
        }
    }
}
