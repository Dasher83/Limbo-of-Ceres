using LimboOfCeres.Scripts.Shared.Interfaces;
using LimboOfCeres.Scripts.Utils;
using UnityEngine;


namespace LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions
{
    [CreateAssetMenu(fileName = "BulletsData", menuName = "ScriptableObjects/BulletsScriptable", order = 5)]
    public class BulletsScriptable : ScriptableObject, IInitializable
    {
        public LimitedNumericProperty<float> Bounciness;
        public LimitedNumericProperty<float> CurvedProbability;
        public LimitedNumericProperty<float> GravityScaleMinimum;
        public LimitedNumericProperty<float> GravityScaleMaximum;

        public void Initialize()
        {
            CurvedProbability = new LimitedNumericProperty<float>(
                initialValue: Constants.Projectiles.Bullet.CurvedProbability.Minimum,
                minimum: Constants.Projectiles.Bullet.CurvedProbability.Minimum,
                maximum: Constants.Projectiles.Bullet.CurvedProbability.Maximum);

            Bounciness = new LimitedNumericProperty<float>(
                initialValue: Constants.Projectiles.Bullet.Bounciness.Minimum,
                minimum: Constants.Projectiles.Bullet.Bounciness.Minimum,
                maximum: Constants.Projectiles.Bullet.Bounciness.Maximum);

            GravityScaleMinimum = new LimitedNumericProperty<float>(
                initialValue: Constants.Projectiles.Bullet.GravityScaleMinimum.Minimum,
                minimum: Constants.Projectiles.Bullet.GravityScaleMinimum.Minimum,
                maximum: Constants.Projectiles.Bullet.GravityScaleMinimum.Maximum);

            GravityScaleMaximum = new LimitedNumericProperty<float>(
                initialValue: Constants.Projectiles.Bullet.GravityScaleMaximum.Minimum,
                minimum: Constants.Projectiles.Bullet.GravityScaleMaximum.Minimum,
                maximum: Constants.Projectiles.Bullet.GravityScaleMaximum.Maximum);
        }

        public float GravityScale => Random.Range(GravityScaleMinimum.LimitedValue, GravityScaleMaximum.LimitedValue);
    }
}
