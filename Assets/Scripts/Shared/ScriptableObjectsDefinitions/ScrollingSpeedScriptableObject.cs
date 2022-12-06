using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.Shared.ScriptableObjectsDefinitions
{
    [CreateAssetMenu(fileName = "ScrollingSpeedData", menuName = "ScriptableObjects/ScrollingSpeedScriptableObject", order = 1)]
    public class ScrollingSpeedScriptableObject : ScriptableObject
    {
        [SerializeField]
        private float scrollingSpeed;
        public float ScrollingSpeed { get { return scrollingSpeed; } }
    }
}
