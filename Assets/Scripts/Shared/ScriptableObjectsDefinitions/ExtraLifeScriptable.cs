using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Shared.Interfaces;
using LimboOfCeres.Scripts.Utils;
using UnityEngine;


namespace LimboOfCeres
{
    [CreateAssetMenu(fileName = "ExtraLifeData", menuName = "ScriptableObjects/ExtraLifeScriptable", order = 6)]
    public class ExtraLifeScriptable : ScriptableObject, IInitializable
    {
        public LimitedNumericProperty<float> SpawnRateMinimum;
        public LimitedNumericProperty<float> SpawnRateMaximum;
        public LimitedNumericProperty<float> MovementSpeed;

        public void Initialize()
        {
            SpawnRateMinimum = new LimitedNumericProperty<float>(
                initialValue: Constants.ExtraLife.SpawnRateMinimum.Minimum,
                minimum: Constants.ExtraLife.SpawnRateMinimum.Minimum,
                maximum: Constants.ExtraLife.SpawnRateMinimum.Maximum);

            SpawnRateMaximum = new LimitedNumericProperty<float>(
                initialValue: Constants.ExtraLife.SpawnRateMaximum.Minimum,
                minimum: Constants.ExtraLife.SpawnRateMaximum.Minimum,
                maximum: Constants.ExtraLife.SpawnRateMaximum.Maximum);

            MovementSpeed = new LimitedNumericProperty<float>(
                initialValue: Constants.ExtraLife.MovementSpeed.Minimum,
                minimum: Constants.ExtraLife.MovementSpeed.Minimum,
                maximum: Constants.ExtraLife.MovementSpeed.Maximum);
        }

        public float SpawnRate => Random.Range(SpawnRateMinimum.LimitedValue, SpawnRateMaximum.LimitedValue);

    }
}
