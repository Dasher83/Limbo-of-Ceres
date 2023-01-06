using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty
{
    public class UpgradeBulletData : LimitedUpgradable
    {
        [SerializeField]
        private BulletsDataScriptable bulletsData;
        private const float LevelUpFactor = 1.1f;

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

        private void Start()
        {
            bulletsData.Initialize(Constants.Projectiles.Bullet.CurvedProbability.Minimum);
        }

        public override void Upgrade()
        {
            base.Upgrade();
            CurvedProbability *= LevelUpFactor; 
        }

        protected override bool IsAtLimit => Mathf.Approximately(Constants.Projectiles.Bullet.CurvedProbability.Maximum, bulletsData.CurvedProbability);
    }
}
