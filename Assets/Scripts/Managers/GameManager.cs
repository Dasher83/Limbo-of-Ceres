using QuarkAcademyJam1Team1.Scripts.UI;
using QuarkAcademyJam1Team1.Scripts.Shared.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private LifeBar lifeBar;

        private GameState gameState;

        void Update()
        {
            // Debugger
            if (Input.GetKeyDown(KeyCode.H))
            {
                lifeBar.Addlife();
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                lifeBar.RemoveLife();
            }
        }

        public void SetState(GameState state)
        {
            gameState = state;

            switch (state)
            {
                case GameState.PLAYING:
                break;
                case GameState.PAUSE:
                    // TODO: pausar todos los sistemas, ui que puedas salir del juego o reanudar
                break;
                case GameState.GAMEOVER:
                    Debug.Log("GAMEOVER");
                break;
            }
        }

        public GameState GetState()
        {
            return gameState;
        }
    }
}
