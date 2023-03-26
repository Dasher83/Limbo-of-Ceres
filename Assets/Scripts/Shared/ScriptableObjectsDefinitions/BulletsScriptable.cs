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
                initialValue: Constants.Bullet.CurvedProbability.Minimum,
                minimum: Constants.Bullet.CurvedProbability.Minimum,
                maximum: Constants.Bullet.CurvedProbability.Maximum);

            Bounciness = new LimitedNumericProperty<float>(
                initialValue: Constants.Bullet.Bounciness.Minimum,
                minimum: Constants.Bullet.Bounciness.Minimum,
                maximum: Constants.Bullet.Bounciness.Maximum);

            GravityScaleMinimum = new LimitedNumericProperty<float>(
                initialValue: Constants.Bullet.GravityScaleMinimum.Minimum,
                minimum: Constants.Bullet.GravityScaleMinimum.Minimum,
                maximum: Constants.Bullet.GravityScaleMinimum.Maximum);

            GravityScaleMaximum = new LimitedNumericProperty<float>(
                initialValue: Constants.Bullet.GravityScaleMaximum.Minimum,
                minimum: Constants.Bullet.GravityScaleMaximum.Minimum,
                maximum: Constants.Bullet.GravityScaleMaximum.Maximum);
        }

        public float GravityScale => Random.Range(GravityScaleMinimum.LimitedValue, GravityScaleMaximum.LimitedValue);
    }
}
