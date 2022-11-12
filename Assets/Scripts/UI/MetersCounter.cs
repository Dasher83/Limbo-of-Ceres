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

        public void MetersUpdate()
        {
            playerData.AddMeters();
            metersText.text = playerData.CurrentMeters.ToString("0") + "M";
        }
    }
}
