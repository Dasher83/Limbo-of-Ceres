using LimboOfCeres.Scripts.Shared.Interfaces;
using LimboOfCeres.Scripts.Utils;
using UnityEngine;


namespace LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions
{
    [CreateAssetMenu(fileName = "JackolanternData", menuName = "ScriptableObjects/JackolanternScriptable", order = 5)]
    public class JackolanternScriptable : ScriptableObject, IInitializable
    {
        public LimitedNumericProperty<float> FireForceMinimum;
        public LimitedNumericProperty<float> FireForceMaximum;
        public LimitedNumericProperty<int> AmmoRequestsMinimum;
        public LimitedNumericProperty<int> AmmoRequestsMaximum;
        public LimitedNumericProperty<float> AimRateMinimum;
        public LimitedNumericProperty<float> AimRateMaximum;
        public LimitedNumericProperty<float> FireRateMinimum;
        public LimitedNumericProperty<float> FireRateMaximum;

        public void Initialize()
        {
            FireForceMinimum = new LimitedNumericProperty<float>(
                initialValue: Constants.Enemies.Jackolanterns.FireForceMinimum.Minimum,
                minimum: Constants.Enemies.Jackolanterns.FireForceMinimum.Minimum,
                maximum: Constants.Enemies.Jackolanterns.FireForceMinimum.Maximum);

            FireForceMaximum = new LimitedNumericProperty<float>(
                initialValue: Constants.Enemies.Jackolanterns.FireForceMaximum.Minimum,
                minimum: Constants.Enemies.Jackolanterns.FireForceMaximum.Minimum,
                maximum: Constants.Enemies.Jackolanterns.FireForceMaximum.Maximum);

            AmmoRequestsMinimum = new LimitedNumericProperty<int>(
                initialValue: Constants.Enemies.Jackolanterns.AmmoRequestsMinimum.Minimum,
                minimum: Constants.Enemies.Jackolanterns.AmmoRequestsMinimum.Minimum,
                maximum: Constants.Enemies.Jackolanterns.AmmoRequestsMinimum.Maximum);

            AmmoRequestsMaximum = new LimitedNumericProperty<int>(
                initialValue: Constants.Enemies.Jackolanterns.AmmoRequestsMaximum.Minimum,
                minimum: Constants.Enemies.Jackolanterns.AmmoRequestsMaximum.Minimum,
                maximum: Constants.Enemies.Jackolanterns.AmmoRequestsMaximum.Maximum);

            AimRateMinimum = new LimitedNumericProperty<float>(
                initialValue: Constants.Enemies.Jackolanterns.AimRateMinimum.Maximum,
                minimum: Constants.Enemies.Jackolanterns.AimRateMinimum.Minimum,
                maximum: Constants.Enemies.Jackolanterns.AimRateMinimum.Maximum);

            AimRateMaximum = new LimitedNumericProperty<float>(
                initialValue: Constants.Enemies.Jackolanterns.AimRateMaximum.Maximum,
                minimum: Constants.Enemies.Jackolanterns.AimRateMaximum.Minimum,
                maximum: Constants.Enemies.Jackolanterns.AimRateMaximum.Maximum);

            FireRateMinimum = new LimitedNumericProperty<float>(
                initialValue: Constants.Enemies.Jackolanterns.FireRateMinimum.Maximum,
                minimum: Constants.Enemies.Jackolanterns.FireRateMinimum.Minimum,
                maximum: Constants.Enemies.Jackolanterns.FireRateMinimum.Maximum);

            FireRateMaximum = new LimitedNumericProperty<float>(
                initialValue: Constants.Enemies.Jackolanterns.FireRateMaximum.Maximum,
                minimum: Constants.Enemies.Jackolanterns.FireRateMaximum.Minimum,
                maximum: Constants.Enemies.Jackolanterns.FireRateMaximum.Maximum);
        }

        public float FireForceRandom => Random.Range(FireForceMinimum.LimitedValue, FireForceMaximum.LimitedValue);

        public int AmmoRequests => Random.Range(AmmoRequestsMinimum.LimitedValue, AmmoRequestsMaximum.LimitedValue + 1);

        public float AimRate => Random.Range(AimRateMinimum.LimitedValue, AimRateMaximum.LimitedValue);

        public float FireRate => Random.Range(FireRateMinimum.LimitedValue, FireRateMaximum.LimitedValue);
    }
}
