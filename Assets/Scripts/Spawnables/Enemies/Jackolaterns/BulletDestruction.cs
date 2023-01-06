using LimboOfCeres.Scripts.AudioScripts;
using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Shared.Interfaces;
using UnityEngine;

namespace LimboOfCeres.Scripts.Spawnables.Enemies.Jackolanterns
{
    public class BulletDestruction : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(Constants.Tags.Player))
            {
                if(collision.gameObject.GetComponent<IDamageable>().ReceiveDamage(1) > 0)
                {
                    AudioPlayer.instance.PlaySoundEffect(SoundEffectsEnum.MALE_EVIL_LAUGH);
                }
            }

            if (!collision.gameObject.CompareTag(Constants.Tags.Projectile))
            {
                gameObject.SetActive(false);
            }
        }
    }
}
