using QuarkAcademyJam1Team1.Scripts.Shared.ScriptableObjectsDefinitions;
using QuarkAcademyJam1Team1.Scripts.HighScores;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace QuarkAcademyJam1Team1.Scripts.UI
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData;
        [SerializeField] private TextMeshProUGUI scoreText;

        private TextMeshProUGUI nameText;
        private TouchScreenKeyboard keyboard;
        private int currentScore;

        void Update()
        {
            if (TouchScreenKeyboard.visible == false && keyboard != null)
            {
                if (keyboard.status == TouchScreenKeyboard.Status.Done)
                {
                    nameText.text = keyboard.text;
                    keyboard = null;
                }
            }
        }

        public void StartGameOver()
        {
            scoreText.text = playerData.CurrentMeters.ToString("0") + "M";
            currentScore = (int)playerData.CurrentMeters;
            gameObject.SetActive(true);
        }

        public void ContinueGameOver()
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
        }

        public void OpenKeyboard()
        {
            keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        }

        public void Retry()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);            
        }

        public void Quit()
        {
            Debug.Log("referencia a la escena de inicio");
        }
    }
}
