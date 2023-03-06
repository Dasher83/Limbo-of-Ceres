using LimboOfCeres.Scripts.AudioScripts;
using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Shared.Interfaces;
using UnityEngine;

namespace LimboOfCeres.Scripts.Spawnables.ExtraLife
{
    public class ConsumeExtraLife : MonoBehaviour
    {
        private bool wasConsumed;

        private void Start()
        {
            wasConsumed = false;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (wasConsumed) return;

            if (other.gameObject.CompareTag(Constants.Tags.Player))
            {
                wasConsumed = true;

                if (other.gameObject.GetComponent<IRestorable>().ReceiveRestauration(1) > 0)
                {
                    AudioPlayer.instance.PlaySoundEffect(SoundEffectsEnum.EXTRA_LIFE);
                }
                gameObject.SetActive(false);
            }
        }

        private void OnEnable()
        {
            wasConsumed = false;
        }
    }
}
