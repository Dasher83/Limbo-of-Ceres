using UnityEngine;

namespace QuarkAcademyJam1Team1.PlayerScritps
{
    public class PlayerMovement : MonoBehaviour
    {
        private float _movementSpeed;
        private Touch _touch;
        private Rigidbody2D _rb;

        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.gravityScale = Constants.Player.gravityScale;
            _movementSpeed = Constants.Player.movementSpeed;
        }

        void Update()
        {
            if(Input.touchCount > 0){
                _touch = Input.GetTouch(0);
                if (_touch.phase == TouchPhase.Ended) {
                    _rb.AddForce(Vector2.up * _movementSpeed);
                }
            }
        }
    }
}
