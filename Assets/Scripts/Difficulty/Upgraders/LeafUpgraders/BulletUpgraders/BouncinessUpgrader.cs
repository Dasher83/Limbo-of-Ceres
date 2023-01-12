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

        protected override void Start()
        {
            base.Start();
            bulletsData.Initialize();
        }

        public override UpgradeStatus Upgrade()
        {
            if (IsAtLimit)
            {
                Debug.LogError($"Bounciness capped at {Bounciness}");
                gameObject.SetActive(false);
                return UpgradeStatus.FAILED;
            }

            float x = Bounciness * this.LevelUpFactor > Constants.Projectiles.Bullet.Bounciness.Maximum ? 
                Constants.Projectiles.Bullet.Bounciness.Maximum : Bounciness;
            Debug.LogError($"Bounciness leveld up from {Bounciness} to {x}");
            Bounciness *= this.LevelUpFactor;
            return UpgradeStatus.SUCCESSFUL;
        }

        public override bool IsAtLimit => Mathf.Approximately(
            Constants.Projectiles.Bullet.Bounciness.Maximum, bulletsData.Bounciness);
    }
}
