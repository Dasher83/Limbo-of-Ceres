using UnityEngine;

namespace LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions
{
    [CreateAssetMenu(fileName = "ObstacleData", menuName = "ScriptableObjects/ObstacleDataScriptableObject", order = 2)]
    public class ObstacleDataScriptableObject : ScriptableObject
    {
        [SerializeField]
        private float minimumRespawnTime;
        [SerializeField]
        private float maximumRespawnTime;

        public float MinimumRespawnTime { get { return minimumRespawnTime; } }
        public float MaximumRespawnTime { get { return maximumRespawnTime; } }
    }
}
