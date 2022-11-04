using QuarkAcademyJam1Team1.Scripts.Shared;
using QuarkJam1Team1.Utils;
using UnityEngine;

namespace QuarkJam1Team1.PlayerScritps
{
    public class PlayerHorizontalAutoPosition : MonoBehaviour
    {
        [SerializeField]
        private Transform _transform;

        private void Start()
        {
            Bounds bounds = CameraUtils.OrthographicBounds();
            Vector2 newPosition = _transform.position;
            newPosition.x = bounds.min.x + (bounds.size.x * Constants.Player.HorizontalPositionOffsetFactor);
            _transform.position = newPosition;
        }
    }
}
