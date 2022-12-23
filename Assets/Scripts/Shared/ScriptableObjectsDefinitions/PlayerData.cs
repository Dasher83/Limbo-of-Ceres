using LimboOfCeres.Scripts.Shared.Interfaces;
using UnityEngine;

namespace LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 2)]
    public class PlayerData : ScriptableObject, IDurable, IDamageable, IRestorable
    {
        [SerializeField] private int lives;
        private float meters;

        public float CurrentMeters => meters;

        public int CurrentDurability => lives;
        public int MaxDurability => Constants.Player.MaxLives;
        public int InitialDurability => Constants.Player.InitialLives; 

        public int ReceiveDamage(int damage)
        {
            if(damage <= 0)
            {
                return 0;
            }

            if(damage > CurrentDurability)
            {
                lives = 0;
                return CurrentDurability;
            }

            lives -= damage;
            return damage;
        }

        public int ReceiveRestauration(int restauration)
        {
            if(restauration <= 0)
            {
                return 0;
            }

            if(restauration + CurrentDurability > MaxDurability)
            {

                lives = MaxDurability;
                return restauration + CurrentDurability - MaxDurability - 1;
            }

            lives += restauration;
            return restauration;
        }

        public void AddMeters(float ScrollingSpeed)
        {
            meters += Mathf.Abs(ScrollingSpeed) * Time.deltaTime/2;
        }

        public void Initialize()
        {
            lives = Constants.Player.InitialLives;
            meters = 0;
        }
    }
}
