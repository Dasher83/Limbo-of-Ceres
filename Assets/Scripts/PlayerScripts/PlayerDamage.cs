using LimboOfCeres.Scripts.Shared.Interfaces;
using LimboOfCeres.Scripts.TimeScripts;
using UnityEngine;

namespace LimboOfCeres.Scripts.PlayerScritps
{
    public class PlayerDamage : MonoBehaviour, IDamageable
    {
        private IDamageable damageable;
        private PlayerFlicker playerFlicker;
        private PlayerRespawnSafely playerRespawnSafely;
        private int damagedCaused;

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

        public int ReceiveDamage(int damage)
        {
            if (!playerRespawnSafely.IsPlayerProtected)
            {
                damagedCaused = damageable.ReceiveDamage(damage);
                playerFlicker.StartFlickering();
                playerRespawnSafely.GetToSafety();
            }
            else
            {
                return 0;
            }
            return damagedCaused;
        }
    }
}
