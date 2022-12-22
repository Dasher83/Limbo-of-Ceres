using QuarkAcademyJam1Team1.Scripts.Shared.Interfaces;
using QuarkAcademyJam1Team1.Scripts.Shared;
using QuarkAcademyJam1Team1.Scripts.AudioScripts;
using UnityEngine;


namespace QuarkAcademyJam1Team1.Scripts.Spawnables.Enemies.Jackolanterns
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
