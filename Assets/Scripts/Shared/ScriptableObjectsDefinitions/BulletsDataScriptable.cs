using UnityEngine;

namespace LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions
{
    [CreateAssetMenu(fileName = "BulletsDataScriptable", menuName = "ScriptableObjects/BulletsDataScriptable", order = 5)]
    public class BulletsDataScriptable : ScriptableObject
    {
        private float curvedProbability;
        private float bounciness;
        private float gravityScaleMinimum;

        public float CurvedProbability { get { return curvedProbability; } set { curvedProbability = value; } }
        public float Bounciness { get { return bounciness; } set { bounciness = value; } }

        public float GravityScaleMinimum { get { return gravityScaleMinimum; } set { gravityScaleMinimum = value; } }

        public void Initialize()
        {
            this.curvedProbability = Constants.Projectiles.Bullet.CurvedProbability.Minimum;
            this.bounciness = Constants.Projectiles.Bullet.Bounciness.Minimum;
            this.gravityScaleMinimum = Constants.Projectiles.Bullet.GravityScaleMinimum.Minimum;
        }
    }
}
