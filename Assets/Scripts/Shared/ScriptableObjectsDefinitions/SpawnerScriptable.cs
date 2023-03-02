using LimboOfCeres.Scripts.Shared.Interfaces;
using LimboOfCeres.Scripts.Utils;
using UnityEngine;


namespace LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions
{
    public abstract class SpawnerScriptable : ScriptableObject, IInitializable
    {
        public LimitedNumericProperty<float> SpawnRateMinimum;
        public LimitedNumericProperty<float> SpawnRateMaximum;

        public abstract void Initialize();

        public float SpawnRate => Random.Range(SpawnRateMinimum.LimitedValue, SpawnRateMaximum.LimitedValue);
    }
}
