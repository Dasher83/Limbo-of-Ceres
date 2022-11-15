using QuarkAcademyJam1Team1.Scripts.Shared.ScriptableObjectsDefinitions;
using QuarkAcademyJam1Team1.Scripts.HighScores;
using QuarkAcademyJam1Team1.Scripts.Shared;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using TMPro;

namespace QuarkAcademyJam1Team1.Scripts.UI
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private GameObject gameOvermenu;
        [SerializeField] private GameObject inputNewHighScoreMenu;
        [SerializeField] private HighScoreTable highScore;
        [SerializeField] private Transform Seats;
        [SerializeField] private PlayerData playerData;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI inputText;
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private GameObject errorText;

        private string nameText;
        private TouchScreenKeyboard keyboard;
        private int currentScore;

        void Start()
        {
            inputField.characterLimit = Constants.HighScores.NameLimitCharacters;
            inputField.onValidateInput += delegate (string s, int i, char c) 
            {
                c = char.ToUpper(c);
                return char.IsLetter(c) ? c : '\0';
            };
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
            if (HighScoresReadWriter.Instance.HighScores.Length < Constants.HighScores.Seats)
            {
                inputNewHighScoreMenu.SetActive(true);
                return;
            }
            for (int i = 0; i < HighScoresReadWriter.Instance.HighScores.Length; i++)
            {
                if (currentScore > HighScoresReadWriter.Instance.HighScores[i].points)
                {
                    inputNewHighScoreMenu.SetActive(true);
                    return;
                }
            }
            highScore.Setup();
            highScore.gameObject.SetActive(true);
        }

        public void ContinueToHighScore()
        {
            if(inputText.text.Length <= 1)
            {
                errorText.SetActive(true);
                return;
            }
            HighScoreItem score = new HighScoreItem(inputText.text, currentScore);
            HighScoresReadWriter.Instance.AddHighScore(score);
            inputNewHighScoreMenu.SetActive(false);
            highScore.Setup();
            highScore.gameObject.SetActive(true);
        }

        public void OpenKeyboard()
        {
            if (errorText.activeSelf)
            {
                errorText.SetActive(false);
            }
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
