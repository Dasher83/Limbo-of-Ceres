using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Difficulty.Upgraders.CompositeCore;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders.LeafUpgraders.BulletUpgraders
{
    public class GravityScaleMinimumUpgrader : LeafUpgrader
    {
        [SerializeField]
        private BulletsScriptable bulletsData;

        protected override void OnUpgradeHook()
        {
            bulletsData.GravityScaleMinimum.LimitedValue *= Constants.Difficulty.DefaultInverseLevelUpFactor;
        }

        public override bool IsAtLimit => Mathf.Approximately(
            Constants.Projectiles.Bullet.GravityScaleMinimum.Maximum, bulletsData.GravityScaleMinimum.LimitedValue);
    }
}
