using LimboOfCeres.Scripts.Difficulty.Upgraders.CompositeCore;
using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders.LeafUpgraders.Bullets
{
    public class GravityScaleMaximumUpgrader : LeafUpgrader
    {
        [SerializeField] private BulletsScriptable _bulletsData;

        protected override void OnUpgradeHook()
        {
            _bulletsData.GravityScaleMaximum.LimitedValue *= Constants.Difficulty.DefaultLevelUpFactor;
        }

        public override bool IsAtLimit => Mathf.Approximately(
            _bulletsData.GravityScaleMaximum.Maximum,
            _bulletsData.GravityScaleMaximum.LimitedValue);
    }
}
