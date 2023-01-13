using LimboOfCeres.Scripts.Difficulty.Upgraders.CompositeCore;
using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders.LeafUpgraders.BulletUpgraders
{
    public class BouncinessUpgrader : UpgraderLeaf
    {
        [SerializeField]
        private BulletsDataScriptable bulletsData;

        protected override void UpgradeHook()
        {
            bulletsData.Bounciness *= this.LevelUpFactor;
        }

        public override bool IsAtLimit => Mathf.Approximately(
            Constants.Projectiles.Bullet.Bounciness.Maximum, bulletsData.Bounciness);
    }
}
