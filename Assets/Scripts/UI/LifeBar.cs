using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Shared.Interfaces;
using TMPro;
using UnityEngine;

namespace LimboOfCeres.Scripts.UI
{
    public class LifeBar : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI livesCounterText;
        private IDurable durable;

        public IDurable Durable { set { durable = value; } }


        private void Start()
        {
            livesCounterText.text = Constants.Player.InitialLives.ToString();
        }

        private void Update()
        {
            if (durable == null) return;

            if (durable.CurrentDurability == 0)
            {
                gameObject.SetActive(false);
                return;
            }

            livesCounterText.text = durable.CurrentDurability.ToString();
        }
    }
}
