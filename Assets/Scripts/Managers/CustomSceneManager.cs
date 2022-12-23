using UnityEngine;
using UnityEngine.SceneManagement;

namespace LimboOfCeres.Scripts.Managers
{
    public class CustomSceneManager : MonoBehaviour
    {
        public static CustomSceneManager instance;

        private void Awake()
        {
            if (instance != null)
            {
                return;
            }
            else
            {
                instance = this;
            }
        }

        public void ChangeToGameScene()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("MainGameScene");
        }

        public void ChangeToMainMenuScene()
        {
            SceneManager.LoadScene("MainMenuScene");
        }
    }
}
