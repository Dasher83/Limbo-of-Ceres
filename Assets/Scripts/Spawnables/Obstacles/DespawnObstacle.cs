using LimboOfCeres.Scripts.Utils;
using UnityEngine;

namespace LimboOfCeres.Scripts.Spawnables.Obstacles
{
    public class DespawnObstacle : MonoBehaviour
    {
        private float leftEdge;

        private void Start()
        {
            leftEdge = CameraUtils.OrthographicBounds.min.x;
            gameObject.SetActive(false);
        }

        private void Update()
        {
            if (gameObject.transform.position.x <= leftEdge - gameObject.GetComponent<SpriteRenderer>().bounds.size.x / 2)
            {
                gameObject.SetActive(false);
            }
        }
    }
}