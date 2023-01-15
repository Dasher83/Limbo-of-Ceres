using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Difficulty.Upgraders.CompositeCore;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders.LeafUpgraders.BulletUpgraders
{
    public class GravityScaleMinimumUpgrader : LeafUpgrader
    {
        [SerializeField]
        private BulletsDataScriptable bulletsData;

        protected override void UpgradeHook()
        {
            bulletsData.GravityScaleMinimum *= this.LevelUpFactor;
        }

        public override bool IsAtLimit => Mathf.Approximately(
            Constants.Projectiles.Bullet.GravityScaleMinimum.Maximum, bulletsData.GravityScaleMinimum);
    }
}