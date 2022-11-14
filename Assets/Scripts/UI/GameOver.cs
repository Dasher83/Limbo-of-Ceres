using QuarkAcademyJam1Team1.Scripts.HighScores;
using QuarkAcademyJam1Team1.Scripts.Shared.ScriptableObjectsDefinitions;
using TMPro;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.UI
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData;
        [SerializeField] private TextMeshProUGUI scoreText;
        
        private int currentScore;

        public void StartGameOver()
        {
            scoreText.text = playerData.CurrentMeters.ToString("0") + "M";
            currentScore = (int)playerData.CurrentMeters;
            gameObject.SetActive(true);
        }

        public void ContinueGameOver()
        {
            
        }

    }
}
