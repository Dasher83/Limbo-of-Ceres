using LimboOfCeres.Scripts.PowerUps;
using LimboOfCeres.Scripts.Shared.Interfaces;
using UnityEngine;


namespace LimboOfCeres.Scripts.Player
{
    public class PlayerDamage : MonoBehaviour, IDamageable
    {
        private IDamageable _damageable;
        private PlayerFlicker _playerFlicker;
        private PlayerRespawnSafely _playerRespawnSafely;
        private Shield _playerShield;
        private int _damagedCaused;

        private void Start()
        {
            _damageable = gameObject.GetComponent<PlayerDataContainer>().PlayerData;
            _playerFlicker = gameObject.GetComponent<PlayerFlicker>();
            _playerRespawnSafely = gameObject.GetComponent<PlayerRespawnSafely>();
            _playerShield = gameObject.GetComponentInChildren<Shield>();
            _playerShield.gameObject.SetActive(false);
        }

        private void Update()
        {
            if(!_playerRespawnSafely.IsPlayerProtected && _playerFlicker.IsFlickering)
            {
                _playerFlicker.StopFlickering();
            }
        }

        public int ReceiveDamage(int damage)
        {
            if (!_playerRespawnSafely.IsPlayerProtected && !_playerShield.gameObject.activeSelf)
            {
                _damagedCaused = _damageable.ReceiveDamage(damage);
                _playerFlicker.StartFlickering();
                _playerRespawnSafely.GetToSafety();
            }
            else
            {
                return 0;
            }
            return _damagedCaused;
        }
    }
}
