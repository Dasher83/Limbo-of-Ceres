using QuarkAcademyJam1Team1.Scripts.Utils;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.Enemies.Jackolanterns
{
    public class PumpkinBulletDespawn : MonoBehaviour
    {
        private float leftEdge;
        private SpriteRenderer spriteRenderer;

        private void Start()
        {
            leftEdge = CameraUtils.OrthographicBounds.min.x;
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            gameObject.SetActive(false);
        }

        private void Update()
        {
            if (gameObject.transform.position.x <= leftEdge - spriteRenderer.bounds.extents.x)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
