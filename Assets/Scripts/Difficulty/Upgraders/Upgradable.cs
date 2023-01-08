using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Shared.Enums;
using LimboOfCeres.Scripts.Shared.Interfaces;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders
{
    public abstract class Upgradable : MonoBehaviour, IUpgradable
    {
        public abstract UpgradeStatus Upgrade();
        private float levelUpFactor;

        protected float LevelUpFactor => levelUpFactor;

        protected virtual void Start()
        {
            levelUpFactor = Constants.Difficulty.LevelUpFactor;
        }
    }
}
