using QuarkAcademyJam1Team1.Scripts.Shared.Interfaces;
using QuarkAcademyJam1Team1.Scripts.TimeScripts;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.PlayerScritps
{
    public class PlayerDamage : MonoBehaviour, IDamageable
    {
        private IDamageable damageable;
        private PlayerFlicker playerFlicker;
        private PlayerRespawnSafely playerRespawnSafely;

        private void Start()
        {
            damageable = gameObject.GetComponent<PlayerDataContainer>().PlayerData;
            playerFlicker = gameObject.GetComponent<PlayerFlicker>();
            playerRespawnSafely = gameObject.GetComponent<PlayerRespawnSafely>();
        }

        private void Update()
        {
            if(!playerRespawnSafely.IsPlayerProtected && playerFlicker.IsFlickering)
            {
                playerFlicker.StopFlickering();
            }
        }

        public void ReceiveDamage(int damage)
        {
            if (!playerRespawnSafely.IsPlayerProtected)
            {
                damageable.ReceiveDamage(damage);
                playerFlicker.StartFlickering();
                playerRespawnSafely.GetToSafety();
            }
        }
    }
}
