using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Utils;
using UnityEngine;

namespace LimboOfCeres.Scripts.Player
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
