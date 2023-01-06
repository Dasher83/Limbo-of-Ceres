using UnityEngine;

namespace LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions
{
    [CreateAssetMenu(fileName = "BulletsDataScriptable", menuName = "ScriptableObjects/BulletsDataScriptable", order = 5)]
    public class BulletsDataScriptable : ScriptableObject
    {
        private float curvedProbability;

        public float CurvedProbability { get { return curvedProbability; } set { curvedProbability = value; } }

        public void Initialize(float curvedProbability)
        {
            this.curvedProbability = curvedProbability;
        }
    }
}
