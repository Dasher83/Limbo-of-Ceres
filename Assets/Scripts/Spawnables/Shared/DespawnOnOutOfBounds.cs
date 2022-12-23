using LimboOfCeres.Scripts.Utils;
using UnityEngine;

namespace LimboOfCeres.Scripts.Spawnables.Shared
{
    public class DespawnOnOutOfBounds : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;

        private bool OutOfHorizontalBounds
        {
            get
            {
                return gameObject.transform.position.x < CameraUtils.OrthographicBounds.min.x - spriteRenderer.bounds.size.x / 2;
            }
        }

        private bool OutOfVerticalBounds
        {
            get
            {
                if (gameObject.transform.position.y > CameraUtils.OrthographicBounds.max.y + spriteRenderer.bounds.size.y / 2)
                {
                    return true;
                }

                if (gameObject.transform.position.y < CameraUtils.OrthographicBounds.min.y - spriteRenderer.bounds.size.y / 2)
                {
                    return true;
                }

                return false;
            }
        }

        private void Start()
        {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            gameObject.SetActive(false);
        }

        private void Update()
        {
            if (OutOfHorizontalBounds || OutOfVerticalBounds)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
