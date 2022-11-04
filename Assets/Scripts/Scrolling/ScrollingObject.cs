
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.Scrolling
{
    public class ScrollingObject : MonoBehaviour
    {
        private Rigidbody2D _rb;
        [SerializeField]
        private float _scrollSpeed;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.velocity = new Vector2(_scrollSpeed, 0);
        }
    }
}
