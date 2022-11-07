using QuarkAcademyJam1Team1.Scripts.Shared.ScriptableObjectsDefinitions;
using QuarkAcademyJam1Team1.Scripts.Shared.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.GameManager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData;

        private GameState gameState;

        void Update()
        {
            // Debugger
            if (Input.GetKeyDown(KeyCode.H))
            {
                playerData.AddLives();
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                playerData.RemoveLife();
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
                    // TODO : se tropiesa, cartel de game over que muestre los metros totales y menu que te deje volve, repetir, y 10 mejores.
                break;
            }
        }

        public GameState GetState()
        {
            return gameState;
        }
    }
}
