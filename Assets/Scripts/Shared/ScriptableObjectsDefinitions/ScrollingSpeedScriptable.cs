using UnityEngine;

namespace LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions
{
    [CreateAssetMenu(fileName = "ScrollingSpeedData", menuName = "ScriptableObjects/ScrollingSpeedScriptable", order = 1)]
    public class ScrollingSpeedScriptable : ScriptableObject
    {
        [SerializeField]
        private float scrollingSpeed;
        public float ScrollingSpeed { get { return scrollingSpeed; } }
    }
}
