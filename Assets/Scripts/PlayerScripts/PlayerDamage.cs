using QuarkAcademyJam1Team1.Scripts.Shared.Interfaces;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.PlayerScritps
{
    public class PlayerDamage : MonoBehaviour, IDamageable
    {
        private IDamageable damageable;

        private void Start()
        {
            damageable = gameObject.GetComponent<PlayerDataContainer>().PlayerData;
        }

        public void ReceiveDamage(int damage)
        {
            damageable.ReceiveDamage(damage);
        }
    }
}
