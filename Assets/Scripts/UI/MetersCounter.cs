using QuarkAcademyJam1Team1.Scripts.Shared.ScriptableObjectsDefinitions;
using UnityEngine;
using TMPro;

namespace QuarkAcademyJam1Team1.Scripts.UI
{
    public class MetersCounter : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData;
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
