using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders
{
    public class UpgradeBulletData : Upgradable, ILimited
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
            Debug.LogError($"BulletLevelUp started at {CurvedProbability}");
        }

        public override bool Upgrade()
        {
            if (IsAtLimit)
            {
                Debug.LogError($"BulletLevelUp capped at {CurvedProbability}");
                return false;
            }
            CurvedProbability *= LevelUpFactor;
            Debug.LogError($"BulletLevelUp to {CurvedProbability}");
            return true;
        }

        public bool IsAtLimit => Mathf.Approximately(Constants.Projectiles.Bullet.CurvedProbability.Maximum, bulletsData.CurvedProbability);
    }
}
