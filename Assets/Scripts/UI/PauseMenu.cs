using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.UI
{
    public class PauseMenu : MonoBehaviour
    {   
        [SerializeField] private GameObject pauseMenu;

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
    }
}
