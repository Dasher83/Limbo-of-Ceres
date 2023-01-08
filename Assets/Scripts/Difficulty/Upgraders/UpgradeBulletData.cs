using LimboOfCeres.Scripts.Shared;
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

        public override bool Upgrade()
        {
            if (IsAtLimit)
            {
                return false;
            }
            CurvedProbability *= this.LevelUpFactor;
            return true;
        }

        public bool IsAtLimit => Mathf.Approximately(Constants.Projectiles.Bullet.CurvedProbability.Maximum, bulletsData.CurvedProbability);
    }
}
