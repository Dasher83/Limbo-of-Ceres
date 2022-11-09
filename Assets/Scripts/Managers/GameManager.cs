using QuarkAcademyJam1Team1.Scripts.Shared.ScriptableObjectsDefinitions;
using QuarkAcademyJam1Team1.Scripts.Shared.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData;
        [SerializeField] private GameObject GameOverMenu;

        void Start()
        {
            SetState(GameState.STARTING);
        }
        
        void Update()
        {
            // Debugger
            if (Input.GetKeyDown(KeyCode.H))
            {
                playerData.AddLifes();
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                playerData.RemoveLife();
            }
            // Debugger

            if (playerData.Lifes == 0)
            {
                SetState(GameState.GAMEOVER);
            }
        }

        public void SetState(GameState state)
        {
            switch (state)
            {
                case GameState.STARTING:
                    playerData.SetInitialLifes();
                    SetState(GameState.PLAYING);
                    break;
                case GameState.PLAYING:
                    break;
                case GameState.GAMEOVER:
                    // TODO: if we not use this manager eny more, but steel have this logic here is where the animation need to be
                    GameOverMenu.SetActive(true);
                    Time.timeScale = 0f;
                    break;
            }
        }
    }
}
