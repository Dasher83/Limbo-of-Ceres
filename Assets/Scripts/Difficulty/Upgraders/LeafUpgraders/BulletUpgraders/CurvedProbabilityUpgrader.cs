using LimboOfCeres.Scripts.Difficulty.Upgraders.CompositeCore;
using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Shared.Enums;
using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders.LeafUpgraders.BulletUpgraders
{
    public class CurvedProbabilityUpgrader : UpgraderLeaf
    {
        [SerializeField]
        private BulletsDataScriptable bulletsData;

        protected override void UpgradeHook()
        {
            bulletsData.CurvedProbability *= this.LevelUpFactor;
        }

        public override bool IsAtLimit => Mathf.Approximately(
            Constants.Projectiles.Bullet.CurvedProbability.Maximum, bulletsData.CurvedProbability);
    }
}
