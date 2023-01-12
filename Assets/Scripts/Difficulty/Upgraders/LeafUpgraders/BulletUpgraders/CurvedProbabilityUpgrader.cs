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

        public float CurvedProbability
        {
            get { return bulletsData.CurvedProbability; }

            private set
            {
                if (value > Constants.Projectiles.Bullet.CurvedProbability.Maximum)
                {
                    bulletsData.CurvedProbability = Constants.Projectiles.Bullet.CurvedProbability.Maximum;
                    return;
                }

                bulletsData.CurvedProbability = value;
            }
        }

        public override UpgradeStatus Upgrade()
        {
            if (IsAtLimit)
            {
                Debug.LogError($"CurvedProbability capped at {CurvedProbability}");
                gameObject.SetActive(false);
                return UpgradeStatus.FAILED;
            }
            float x = CurvedProbability * this.LevelUpFactor > Constants.Projectiles.Bullet.CurvedProbability.Maximum ? Constants.Projectiles.Bullet.CurvedProbability.Maximum : CurvedProbability;
            Debug.LogError($"CurvedProbability leveld up from {CurvedProbability} to {x}");
            CurvedProbability *= this.LevelUpFactor;
            return UpgradeStatus.SUCCESSFUL;
        }

        public override bool IsAtLimit => Mathf.Approximately(
            Constants.Projectiles.Bullet.CurvedProbability.Maximum, bulletsData.CurvedProbability);
    }
}
