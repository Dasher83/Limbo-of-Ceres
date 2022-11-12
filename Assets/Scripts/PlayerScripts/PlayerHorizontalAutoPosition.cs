using QuarkAcademyJam1Team1.Scripts.Shared;
using QuarkAcademyJam1Team1.Scripts.Utils;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.PlayerScritps
{
    public class PlayerHorizontalAutoPosition : MonoBehaviour
    {
        [SerializeField]
        private Transform _transform;

        private void Start()
        {
            Vector2 newPosition = _transform.position;
            newPosition.x = CameraUtils.OrthographicBounds.min.x + (CameraUtils.OrthographicBounds.size.x * Constants.Player.HorizontalPositionOffsetFactor);
            _transform.position = newPosition;
        }
    }
}
