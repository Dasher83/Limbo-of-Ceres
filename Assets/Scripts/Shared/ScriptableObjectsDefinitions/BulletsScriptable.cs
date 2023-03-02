using LimboOfCeres.Scripts.Shared.Interfaces;
using UnityEngine;


namespace LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions
{
    [CreateAssetMenu(fileName = "BulletsData", menuName = "ScriptableObjects/BulletsScriptable", order = 5)]
    public class BulletsScriptable : ScriptableObject, IInitializable
    {
        [SerializeField] private float bounciness;
        [SerializeField] private float curvedProbability;
        [SerializeField] private float gravityScaleMaximum;
        [SerializeField] private float gravityScaleMinimum;

        public void Initialize()
        {
            this.curvedProbability = Constants.Projectiles.Bullet.CurvedProbability.Minimum;
            this.bounciness = Constants.Projectiles.Bullet.Bounciness.Minimum;
            this.gravityScaleMinimum = Constants.Projectiles.Bullet.GravityScaleMinimum.Minimum;
            this.gravityScaleMaximum = Constants.Projectiles.Bullet.GravityScaleMaximum.Minimum;
        }

        public float CurvedProbability
        {
            get { return curvedProbability; }

            set
            {
                if (value > Constants.Projectiles.Bullet.CurvedProbability.Maximum)
                {
                    curvedProbability = Constants.Projectiles.Bullet.CurvedProbability.Maximum;
                    return;
                }

                if(value < Constants.Projectiles.Bullet.CurvedProbability.Minimum)
                {
                    curvedProbability = Constants.Projectiles.Bullet.CurvedProbability.Minimum;
                    return;
                }

                curvedProbability = value;
            }
        }

        public float Bounciness
        {
            get { return bounciness; }

            set
            {
                if (value > Constants.Projectiles.Bullet.Bounciness.Maximum)
                {
                    bounciness = Constants.Projectiles.Bullet.Bounciness.Maximum;
                    return;
                }

                if (value < Constants.Projectiles.Bullet.Bounciness.Minimum)
                {
                    bounciness = Constants.Projectiles.Bullet.Bounciness.Minimum;
                    return;
                }

                bounciness = value;
            }
        }

        public float GravityScaleMinimum
        {
            get { return gravityScaleMinimum; }

            set
            {
                if (value * -1 > Constants.Projectiles.Bullet.GravityScaleMinimum.Maximum * -1)
                {
                    gravityScaleMinimum = Constants.Projectiles.Bullet.GravityScaleMinimum.Maximum;
                    return;
                }

                if (value * -1 < Constants.Projectiles.Bullet.GravityScaleMinimum.Minimum * -1)
                {
                    gravityScaleMinimum = Constants.Projectiles.Bullet.GravityScaleMinimum.Minimum;
                    return;
                }

                gravityScaleMinimum = value;
            }
        }

        public float GravityScaleMaximum
        {
            get { return gravityScaleMaximum; }

            set
            {
                if (value > Constants.Projectiles.Bullet.GravityScaleMaximum.Maximum)
                {
                    gravityScaleMaximum = Constants.Projectiles.Bullet.GravityScaleMaximum.Maximum;
                    return;
                }

                if (value < Constants.Projectiles.Bullet.GravityScaleMaximum.Minimum)
                {
                    gravityScaleMaximum = Constants.Projectiles.Bullet.GravityScaleMaximum.Minimum;
                    return;
                }

                gravityScaleMaximum = value;
            }
        }
    }
}
