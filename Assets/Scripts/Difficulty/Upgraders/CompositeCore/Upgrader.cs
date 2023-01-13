using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Shared.Enums;
using LimboOfCeres.Scripts.Shared.Interfaces;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders.CompositeCore
{
    public abstract class Upgrader : MonoBehaviour
    {
        private float levelUpFactor;

        protected float LevelUpFactor => levelUpFactor;

        public abstract bool IsAtLimit { get; }

        protected abstract bool IsComposite { get; }

        public UpgradeStatus Upgrade()
        {
            if (IsAtLimit)
            {
                gameObject.SetActive(false);
                return UpgradeStatus.FAILED;
            }

            UpgradeHook();
            return UpgradeStatus.SUCCESSFUL;
        }

        protected virtual void UpgradeHook() { }
        
        protected virtual void Start()
        {
            levelUpFactor = Constants.Difficulty.LevelUpFactor;
        }
    }
}
