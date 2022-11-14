using QuarkAcademyJam1Team1.Scripts.AudioScripts;
using QuarkAcademyJam1Team1.Scripts.Shared;
using QuarkAcademyJam1Team1.Scripts.Shared.Interfaces;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.Obstacles
{
    public class ObstacleDestruction : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(Constants.Tags.Obstacle) || collision.gameObject.CompareTag(Constants.Tags.Enemy))
            {
                collision.otherCollider.gameObject.SetActive(false);
                return;
            }

            if (collision.gameObject.CompareTag(Constants.Tags.Player))
            {
                AudioPlayer.instance.PlaySoundEffect(SoundEffectsEnum.WALL_HIT);
                collision.gameObject.GetComponent<IDamageable>().ReceiveDamage(1);
                gameObject.SetActive(false);
                return;
            }
        }
    }
}
