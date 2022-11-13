using QuarkAcademyJam1Team1.Scripts.Shared.Interfaces;
using QuarkAcademyJam1Team1.Scripts.TimeScripts;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.PlayerScritps
{
    public class PlayerDamage : MonoBehaviour, IDamageable
    {
        private IDamageable damageable;
        private ResettableTimer flickerTestTimer;
        private PlayerFlicker playerFlicker;

        private void Start()
        {
            damageable = gameObject.GetComponent<PlayerDataContainer>().PlayerData;
            playerFlicker = gameObject.GetComponent<PlayerFlicker>();
        }

        private void Update()
        {
            if (flickerTestTimer == null) return;
            flickerTestTimer.Countdown(Time.deltaTime);
            if (flickerTestTimer.OutOfTime)
            {
                playerFlicker.StopFlickering();
                flickerTestTimer.Reset();
            }
        }

        public void ReceiveDamage(int damage)
        {
            if (playerFlicker.IsFlickering) return;

            damageable.ReceiveDamage(damage);
            playerFlicker.StartFlickering();
            if (flickerTestTimer == null)
            {
                flickerTestTimer = new ResettableTimer(5f);
            }
        }
    }
}
