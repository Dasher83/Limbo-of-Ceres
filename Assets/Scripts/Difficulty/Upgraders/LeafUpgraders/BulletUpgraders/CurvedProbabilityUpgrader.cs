using LimboOfCeres.Scripts.Difficulty.Upgraders.CompositeCore;
using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders.LeafUpgraders.BulletUpgraders
{
    public class CurvedProbabilityUpgrader : LeafUpgrader
    {
        [SerializeField] private BulletsScriptable _bulletsData;

        protected override void OnUpgradeHook()
        {
            _bulletsData.CurvedProbability.LimitedValue *= Constants.Difficulty.DefaultLevelUpFactor;
        }

        public override bool IsAtLimit => Mathf.Approximately(
            _bulletsData.CurvedProbability.Maximum,
            _bulletsData.CurvedProbability.LimitedValue);
    }
}
