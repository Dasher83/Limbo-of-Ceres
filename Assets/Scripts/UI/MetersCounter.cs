using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using UnityEngine;
using TMPro;


namespace LimboOfCeres.Scripts.UI
{
    public class MetersCounter : MonoBehaviour
    {
        [SerializeField] private PlayerScriptable playerData;
        [SerializeField] private ScrollingSpeedScriptableObject scrollingSpeedFloor;
        private TextMeshProUGUI metersText;

        private void Start()
        {
            metersText = GetComponent<TextMeshProUGUI>();
        }

        public void MetersUpdate()
        {
            playerData.AddMeters(scrollingSpeedFloor.ScrollingSpeed);
            metersText.text = playerData.CurrentMeters.ToString("0") + "M";
        }
    }
}
