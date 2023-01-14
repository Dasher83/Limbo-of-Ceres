using LimboOfCeres.Scripts.Difficulty.Upgraders.CompositeCore;
using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders.LeafUpgraders.BulletUpgraders
{
    public class GravityScaleMaximumUpgrader : LeafUpgrader
    {
        [SerializeField]
        private BulletsDataScriptable bulletsData;

        protected override void UpgradeHook()
        {
            bulletsData.GravityScaleMaximum *= this.LevelUpFactor;
        }

        public override bool IsAtLimit => Mathf.Approximately(
            Constants.Projectiles.Bullet.GravityScaleMaximum.Maximum, bulletsData.GravityScaleMaximum);
    }
}
