using QuarkAcademyJam1Team1.Scripts.Shared;
using QuarkAcademyJam1Team1.Scripts.Utils;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.PlayerScritps
{
    public class PlayerPositionReseter : MonoBehaviour
    {
        Vector3 newPosition;

        private void Awake()
        {
            newPosition = Vector3.zero;
        }

        private void Start()
        {
            Reset();
        }

        public void Reset()
        {
            newPosition.x = CameraUtils.OrthographicBounds.min.x;
            newPosition.x += (CameraUtils.OrthographicBounds.size.x * Constants.Player.HorizontalPositionOffsetFactor);
            transform.position = newPosition;
        }
    }
}
