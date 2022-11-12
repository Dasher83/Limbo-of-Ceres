using QuarkAcademyJam1Team1.Scripts.Shared.ScriptableObjectsDefinitions;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace QuarkAcademyJam1Team1.Scripts.UI
{
    public class MetersCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI metersText;
        [SerializeField] private PlayerData playerData;
        [SerializeField] private ScrollingSpeedScriptableObject scrollingSpeedFloor;

        public void MetersUpdate()
        {
            playerData.AddMeters(scrollingSpeedFloor.ScrollingSpeed);
            metersText.text = playerData.CurrentMeters.ToString("0") + "M";
        }
    }
}
