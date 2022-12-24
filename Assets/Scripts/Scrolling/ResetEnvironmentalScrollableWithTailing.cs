using LimboOfCeres.Scripts.Utils;
using UnityEngine;

namespace LimboOfCeres.Scripts.Scrolling
{
    public class ResetEnvironmentalScrollableWithTailing : MonoBehaviour
    {
        [SerializeField]
        private GameObject tail;
        private SpriteRenderer tailSpriteRenderer;
        private Vector3 newPosition;

        private void Start()
        {
            tailSpriteRenderer = tail.GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if (gameObject.transform.position.x <= CameraUtils.OrthographicBounds.min.x - CameraUtils.OrthographicBounds.extents.x)
            {
                newPosition = gameObject.transform.position;
                newPosition.x = tail.transform.position.x + tailSpriteRenderer.bounds.size.x;
                gameObject.transform.position = newPosition;
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(new Vector3(CameraUtils.OrthographicBounds.max.x, 1000, 0), new Vector3(CameraUtils.OrthographicBounds.max.x, -1000, 0));
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(new Vector3(CameraUtils.OrthographicBounds.min.x, 1000, 0), new Vector3(CameraUtils.OrthographicBounds.min.x, -1000, 0));
        }
    }
}
