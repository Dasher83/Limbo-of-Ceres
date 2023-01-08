using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Shared.Enums;
using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders
{
    public class UpgradeBulletData : Upgradable, ILimited
    {
        [SerializeField]
        private BulletsDataScriptable bulletsData;

        public float CurvedProbability
        {
            get { return bulletsData.CurvedProbability; }

            private set
            {
                if(value > Constants.Projectiles.Bullet.CurvedProbability.Maximum)
                {
                    bulletsData.CurvedProbability = Constants.Projectiles.Bullet.CurvedProbability.Maximum;
                    return;
                }

                bulletsData.CurvedProbability = value;
            }
        }

        protected override void Start()
        {
            base.Start();
            bulletsData.Initialize(Constants.Projectiles.Bullet.CurvedProbability.Minimum);
        }

        public override UpgradeStatus Upgrade()
        {
            if (IsAtLimit)
            {
                return UpgradeStatus.FAILED;
            }
            CurvedProbability *= this.LevelUpFactor;
            return UpgradeStatus.SUCCESSFUL;
        }

        public bool IsAtLimit => Mathf.Approximately(Constants.Projectiles.Bullet.CurvedProbability.Maximum, bulletsData.CurvedProbability);
    }
}
