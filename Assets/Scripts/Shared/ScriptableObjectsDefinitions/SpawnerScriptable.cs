using LimboOfCeres.Scripts.Shared.Interfaces;
using LimboOfCeres.Scripts.Utils;
using UnityEngine;


namespace LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions
{
    public abstract class SpawnerScriptable : ScriptableObject, IInitializable
    {
        public LimitedNumericProperty<float> SpawnTimeMinimum;
        public LimitedNumericProperty<float> SpawnTimeMaximum;

        public abstract void Initialize();

        public float SpawnTime => Random.Range(SpawnTimeMinimum.LimitedValue, SpawnTimeMaximum.LimitedValue);
    }
}
