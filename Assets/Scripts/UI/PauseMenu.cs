using LimboOfCeres.Scripts.Shared;
using UnityEngine.SceneManagement;
using UnityEngine;


namespace LimboOfCeres.Scripts.UI
{
    public class PauseMenu : MonoBehaviour
    {
        private GameObject pauseMenu;

        private void Start()
        {
            foreach (GameObject menu in GameObject.FindGameObjectsWithTag(Constants.Tags.Menu))
            {
                if(menu.name == Constants.GameObjects.PauseMenu)
                {
                    pauseMenu = menu;
                    break;
                }
            }
            pauseMenu.SetActive(false);
        }

        public void Pause()
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }

        public void Resume()
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }

        public void Restart()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void Quit()
        {
            Debug.Log("TO DO");
        }
    }
}
