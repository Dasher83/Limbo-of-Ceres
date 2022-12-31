using UnityEngine;

namespace LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions
{
    [CreateAssetMenu(fileName = "SpawningDataScriptable", menuName = "ScriptableObjects/SpawningDataScriptable", order = 4)]
    public class SpawningDataScriptable : ScriptableObject
    {
        [SerializeField]
        private float minimumRespawnTime;
        [SerializeField]
        private float maximumRespawnTime;

        public float MinimumRespawnTime { get { return minimumRespawnTime; } }
        public float MaximumRespawnTime { get { return maximumRespawnTime; } }
    }
}
