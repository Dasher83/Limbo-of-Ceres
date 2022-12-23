
using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using UnityEngine;

namespace LimboOfCeres.Scripts.Scrolling
{
    public class ScrollingObject : MonoBehaviour
    {
        private Rigidbody2D _rb;
        [SerializeField]
        private ScrollingSpeedScriptableObject scrollingSpeedData;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.velocity = new Vector2(scrollingSpeedData.ScrollingSpeed, 0);
        }
    }
}
