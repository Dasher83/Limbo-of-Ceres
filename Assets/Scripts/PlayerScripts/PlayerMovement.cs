using UnityEngine;

namespace QuarkAcademyJam1Team1.PlayerScritps
{
    public class PlayerMovement : MonoBehaviour
    {
        private float _movementSpeed;
        private float _decelerationSpeed;
        private Touch _touch;
        private Rigidbody2D _rb;

        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.gravityScale = Constants.Player.GravityScale;
            _movementSpeed = Constants.Player.InitialMovementSpeed;
            _decelerationSpeed = Constants.Player.DecelerationSpeed;
        }

        void FixedUpdate()
        {
            if(Input.touchCount > 0){
                _touch = Input.GetTouch(0);
                if (_touch.phase == TouchPhase.Moved || _touch.phase == TouchPhase.Stationary) {
                    _rb.AddForce(Vector2.up * _movementSpeed);
                }
                else if(_touch.phase == TouchPhase.Ended)
                {
                    _rb.velocity *= _decelerationSpeed;
                }
            }
        }
    }
}
