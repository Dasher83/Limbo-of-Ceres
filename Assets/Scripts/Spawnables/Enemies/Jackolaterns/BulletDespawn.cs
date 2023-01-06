using LimboOfCeres.Scripts.Utils;
using UnityEngine;

namespace LimboOfCeres.Scripts.Spawnables.Enemies.Jackolanterns
{
    public class BulletDespawn : MonoBehaviour
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
