using LimboOfCeres.Scripts.Difficulty.Upgraders.CompositeCore;
using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders.LeafUpgraders.BulletUpgraders
{
    public class BouncinessUpgrader : LeafUpgrader
    {
        [SerializeField]
        private BulletsScriptable bulletsData;

        protected override void OnUpgradeHook()
        {
            bulletsData.Bounciness.LimitedValue *= 1.8f;
        }

        public override bool IsAtLimit => Mathf.Approximately(
            Constants.Projectiles.Bullet.Bounciness.Maximum, bulletsData.Bounciness.LimitedValue);
    }
}
