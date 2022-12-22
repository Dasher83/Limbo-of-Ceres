using QuarkAcademyJam1Team1.Scripts.Shared;
using QuarkAcademyJam1Team1.Scripts.Utils;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.Enemies.Jackolanterns
{
    public class DespawnJackolantern : MonoBehaviour
    {
        private bool OutOfHorizontalBounds
        {
            get
            {
                return gameObject.transform.position.x < CameraUtils.OrthographicBounds.min.x - gameObject.GetComponent<SpriteRenderer>().bounds.size.x / 2;
            }
        }

        private bool OutOfVerticalBounds
        {
            get
            {
                if(gameObject.transform.position.y > CameraUtils.OrthographicBounds.max.y + gameObject.GetComponent<SpriteRenderer>().bounds.size.y / 2)
                {
                    return true;
                }

                if (gameObject.transform.position.y < CameraUtils.OrthographicBounds.min.y - gameObject.GetComponent<SpriteRenderer>().bounds.size.y / 2)
                {
                    return true;
                }

                return false;
            }
        }

        private void Start()
        {
            gameObject.SetActive(false);
        }

        private void Update()
        {
            if (OutOfHorizontalBounds || OutOfVerticalBounds)
            {
                gameObject.SetActive(false);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(Constants.Tags.Enemy))
            {
                collision.otherCollider.gameObject.SetActive(false);
            }
        }
    }
}