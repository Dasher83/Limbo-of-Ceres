using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Shared.Enums;
using LimboOfCeres.Scripts.Shared.Interfaces;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders
{
    public abstract class Upgrader : MonoBehaviour, IUpgradable
    {
        private float levelUpFactor;

        protected float LevelUpFactor => levelUpFactor;

        public abstract UpgradeStatus Upgrade();
        
        protected virtual void Start()
        {
            levelUpFactor = Constants.Difficulty.LevelUpFactor;
        }
    }
}
