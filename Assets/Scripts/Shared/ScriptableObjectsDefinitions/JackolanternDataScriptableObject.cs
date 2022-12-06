using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.Shared.ScriptableObjectsDefinitions
{
    [CreateAssetMenu(fileName = "JackolanternData", menuName = "ScriptableObjects/JackolanternDataScriptableObject", order = 3)]
    public class JackolanternDataScriptableObject : ScriptableObject
    {
        [SerializeField]
        private float minimumRespawnTime;
        [SerializeField]
        private float maximumRespawnTime;

        public float MinimumRespawnTime { get { return minimumRespawnTime; } }
        public float MaximumRespawnTime { get { return maximumRespawnTime; } }
    }
}
