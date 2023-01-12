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
        private int attributeIndex;

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

        public float GravityScaleMinimum
        {
            get { return bulletsData.GravityScaleMinimum; }

            private set
            {
                if (value * -1 > Constants.Projectiles.Bullet.GravityScaleMinimum.Maximum * -1)
                {
                    bulletsData.GravityScaleMinimum = Constants.Projectiles.Bullet.GravityScaleMinimum.Maximum;
                    return;
                }

                bulletsData.GravityScaleMinimum = value;
            }
        }

        public float GravityScaleMaximum
        {
            get { return bulletsData.GravityScaleMaximum; }

            private set
            {
                if (value > Constants.Projectiles.Bullet.GravityScaleMaximum.Maximum)
                {
                    bulletsData.GravityScaleMaximum = Constants.Projectiles.Bullet.GravityScaleMaximum.Maximum;
                    return;
                }

                bulletsData.GravityScaleMaximum = value;
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

            attributeIndex = Random.Range(1, 5);

            switch (attributeIndex)
            {
                case 1:
                    if (!BouncinessIsAtLimit)
                    {
                        Bounciness *= this.LevelUpFactor;
                        return UpgradeStatus.SUCCESSFUL;
                    }
                    break;
                case 2:
                    if (!CurvedProbabilityIsAtLimit)
                    {
                        CurvedProbability *= this.LevelUpFactor;
                        return UpgradeStatus.SUCCESSFUL;
                    }
                    break;
                case 3:
                    if (!GravityScaleMinimumIsAtLimit)
                    {
                        GravityScaleMinimum *= this.LevelUpFactor;
                        return UpgradeStatus.SUCCESSFUL;
                    }
                    break;
                case 4:
                    if (!GravityScaleMaximumIsAtLimit)
                    {
                        Debug.LogError($"GravityScaleMaximum level up from {GravityScaleMaximum} to {GravityScaleMaximum * this.LevelUpFactor}");
                        GravityScaleMaximum *= this.LevelUpFactor;
                        return UpgradeStatus.SUCCESSFUL;
                    }
                    else
                    {
                        Debug.LogError($"GravityScaleMaximum capped at {GravityScaleMaximum}");
                    }
                    break;
            }

            return UpgradeStatus.FAILED;
        }

        public bool IsAtLimit =>
            CurvedProbabilityIsAtLimit && BouncinessIsAtLimit &&
            GravityScaleMinimumIsAtLimit && GravityScaleMaximumIsAtLimit;

        private bool CurvedProbabilityIsAtLimit => Mathf.Approximately(
            Constants.Projectiles.Bullet.CurvedProbability.Maximum, bulletsData.CurvedProbability);

        private bool BouncinessIsAtLimit => Mathf.Approximately(
            Constants.Projectiles.Bullet.Bounciness.Maximum, bulletsData.Bounciness);

        private bool GravityScaleMinimumIsAtLimit => Mathf.Approximately(
            Constants.Projectiles.Bullet.GravityScaleMinimum.Maximum, bulletsData.GravityScaleMinimum);

        private bool GravityScaleMaximumIsAtLimit => Mathf.Approximately(
            Constants.Projectiles.Bullet.GravityScaleMaximum.Maximum, bulletsData.GravityScaleMaximum);
    }
}
