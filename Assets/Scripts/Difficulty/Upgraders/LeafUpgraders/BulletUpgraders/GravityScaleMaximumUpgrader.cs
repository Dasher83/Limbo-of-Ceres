using LimboOfCeres.Scripts.Difficulty.Upgraders.CompositeCore;
using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders.LeafUpgraders.BulletUpgraders
{
    public class GravityScaleMaximumUpgrader : LeafUpgrader
    {
        [SerializeField]
        private BulletsScriptable bulletsData;

        protected override void OnUpgradeHook()
        {
            bulletsData.GravityScaleMaximum *= Constants.Difficulty.DefaultLevelUpFactor;
        }

        public override bool IsAtLimit => Mathf.Approximately(
            Constants.Projectiles.Bullet.GravityScaleMaximum.Maximum, bulletsData.GravityScaleMaximum);
    }
}
