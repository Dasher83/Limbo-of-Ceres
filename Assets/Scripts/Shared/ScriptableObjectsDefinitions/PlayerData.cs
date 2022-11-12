using QuarkAcademyJam1Team1.Scripts.Shared.Interfaces;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.Shared.ScriptableObjectsDefinitions
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 2)]
    public class PlayerData : ScriptableObject, IDurable, IDamageable, IRestorable
    {
        [SerializeField] private int lives;
        [SerializeField] private ScrollingSpeedScriptableObject scrollingSpeed;
        private float meters;

        public float CurrentMeters => meters;

        public int CurrentDurability => lives;
        public int MaxDurability => Constants.Player.MaxLives;
        public int InitialDurability => Constants.Player.InitialLives; 

        public void ReceiveDamage(int damage)
        {
            if(damage <= 0)
            {
                return;
            }

            if(damage > CurrentDurability)
            {
                lives = 0;
                return;
            }

            lives -= damage;
        }

        public void ReceiveRestauration(int restauration)
        {
            if(restauration <= 0)
            {
                return;
            }

            if(restauration + CurrentDurability > MaxDurability)
            {
                lives = MaxDurability;
                return;
            }

            lives += restauration;
        }

        public void AddMeters()
        {
            meters += Mathf.Abs(scrollingSpeed.ScrollingSpeed) * Time.deltaTime/2;
        }

        public void Initialize()
        {
            lives = Constants.Player.InitialLives;
            meters = 0;
        }
    }
}
