using UnityEngine.SceneManagement;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.UI
{
    public class PauseMenu : MonoBehaviour
    {
        public void Pause()
        {
            gameObject.SetActive(true);
            Time.timeScale = 0f;
        }

        public void Resume()
        {
            gameObject.SetActive(false);
            Time.timeScale = 1f;
        }

        public void Restart()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void Quit()
        {
            Debug.Log("Anejmi dale trabaja y haceme la pantalla de inicio");
        }
    }
}
