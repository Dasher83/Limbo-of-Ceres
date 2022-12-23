using LimboOfCeres.Scripts.Shared.Interfaces;
using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.AudioScripts;
using UnityEngine;


namespace LimboOfCeres.Scripts.Spawnables.Enemies.Jackolanterns
{
    public class JackolanternDestruction : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(Constants.Tags.Player))
            {
                if(collision.gameObject.GetComponent<IDamageable>().ReceiveDamage(1) > 0)
                {
                    AudioPlayer.instance.PlaySoundEffect(SoundEffectsEnum.MALE_BOO_AND_EVIL_LAUGH);
                }
                gameObject.SetActive(false);
            }
        }
    }
}
