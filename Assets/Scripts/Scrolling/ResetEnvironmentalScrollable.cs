using LimboOfCeres.Scripts.Utils;
using UnityEngine;

namespace LimboOfCeres.Scripts.Scrolling
{
    public class ResetEnvironmentalScrollable : MonoBehaviour
    {
        private float leftEdge;
        private float rightEdge;
        private Vector3 newPosition;

        private void Start()
        {
            leftEdge = CameraUtils.OrthographicBounds.min.x;
            rightEdge = CameraUtils.OrthographicBounds.max.x;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(new Vector3(rightEdge, 1000, 0), new Vector3(rightEdge, -1000, 0));
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(new Vector3(leftEdge, 1000, 0), new Vector3(leftEdge, -1000, 0));
        }

        private void Update()
        {
            if (gameObject.transform.position.x <= leftEdge - CameraUtils.OrthographicBounds.extents.x)
            {
                newPosition = gameObject.transform.position;
                newPosition.x = rightEdge + CameraUtils.OrthographicBounds.extents.x;
                gameObject.transform.position = newPosition;
            }
        }
    }
}
