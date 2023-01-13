using LimboOfCeres.Scripts.Difficulty.Upgraders.CompositeCore;
using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Shared.Enums;
using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders.LeafUpgraders.BulletUpgraders
{
    public class BouncinessUpgrader : UpgraderLeaf
    {
        [SerializeField]
        private BulletsDataScriptable bulletsData;

        public float Bounciness
        {
            get { return bulletsData.Bounciness; }

            private set
            {
                if (value > Constants.Projectiles.Bullet.Bounciness.Maximum)
                {
                    bulletsData.Bounciness = Constants.Projectiles.Bullet.Bounciness.Maximum;
                    return;
                }

                bulletsData.Bounciness = value;
            }
        }

        protected override void UpgradeHook()
        {
            Bounciness *= this.LevelUpFactor;
        }

        public override bool IsAtLimit => Mathf.Approximately(
            Constants.Projectiles.Bullet.Bounciness.Maximum, bulletsData.Bounciness);
    }
}
