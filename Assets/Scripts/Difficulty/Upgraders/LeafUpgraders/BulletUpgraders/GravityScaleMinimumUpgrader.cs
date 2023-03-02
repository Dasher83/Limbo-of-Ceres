using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Difficulty.Upgraders.CompositeCore;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders.LeafUpgraders.BulletUpgraders
{
    public class GravityScaleMinimumUpgrader : LeafUpgrader
    {
        [SerializeField] private BulletsScriptable _bulletsData;

        protected override void OnUpgradeHook()
        {
            _bulletsData.GravityScaleMinimum.LimitedValue *= Constants.Difficulty.DefaultInverseLevelUpFactor;
        }

        public override bool IsAtLimit => Mathf.Approximately(
            _bulletsData.GravityScaleMinimum.Maximum,
            _bulletsData.GravityScaleMinimum.LimitedValue);
    }
}
