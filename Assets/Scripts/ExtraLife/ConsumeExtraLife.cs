using LimboOfCeres.Scripts.AudioScripts;
using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Shared.Interfaces;
using UnityEngine;

namespace LimboOfCeres.Scripts.ExtraLife
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
