using QuarkAcademyJam1Team1.Scripts.AudioScripts;
using QuarkAcademyJam1Team1.Scripts.Shared;
using QuarkAcademyJam1Team1.Scripts.Shared.Interfaces;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.ExtraLife
{
    public class ConsumeExtraLife : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Constants.Tags.Player))
            {
                if(other.gameObject.GetComponent<IRestorable>().ReceiveRestauration(1) > 0)
                {
                    AudioPlayer.instance.PlaySoundEffect(SoundEffectsEnum.EXTRA_LIFE);
                }
                gameObject.SetActive(false);
            }
        }
    }
}
