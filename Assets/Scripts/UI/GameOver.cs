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
        [SerializeField] private GameObject gameOvermenu;
        [SerializeField] private GameObject inputNewHighScoreMenu;
        [SerializeField] private GameObject HighScore;
        [SerializeField] private PlayerData playerData;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI inputText;

        private string nameText;
        private TouchScreenKeyboard keyboard;
        private int currentScore;

        void Update()
        {
            if (TouchScreenKeyboard.visible == false && keyboard != null)
            {
                if (inputText.text.Length == 4)
                {
                    Debug.Log("prueba");
                    // buscar como cerrar teclado
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
            gameOvermenu.SetActive(false);
            inputNewHighScoreMenu.SetActive(true);
        }

        public void OpenKeyboard()
        {
            keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, true, false, false, false, "\"\"", 3);
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
