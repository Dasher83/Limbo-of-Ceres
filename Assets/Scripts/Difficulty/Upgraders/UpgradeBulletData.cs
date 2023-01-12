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
        private float decisionNumber;

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

        public float Bounciness
        {
            get { return bulletsData.Bounciness; }

            private set
            {
                if(value > Constants.Projectiles.Bullet.Bounciness.Maximum)
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
                return UpgradeStatus.FAILED;
            }

            decisionNumber = Random.Range(0, 2);

            if (decisionNumber < 1 && !BouncinessIsAtLimit)
            {
                Bounciness *= this.LevelUpFactor;
                return UpgradeStatus.SUCCESSFUL;
            }
            if (decisionNumber > 1 && !CurvedProbabilityIsAtLimit)
            {
                CurvedProbability *= this.LevelUpFactor;
                return UpgradeStatus.SUCCESSFUL;
            }

            return UpgradeStatus.FAILED;
        }

        public bool IsAtLimit => CurvedProbabilityIsAtLimit && BouncinessIsAtLimit;

        private bool CurvedProbabilityIsAtLimit => Mathf.Approximately(Constants.Projectiles.Bullet.CurvedProbability.Maximum, bulletsData.CurvedProbability);

        private bool BouncinessIsAtLimit => Mathf.Approximately(Constants.Projectiles.Bullet.Bounciness.Maximum, bulletsData.Bounciness);
    }
}
