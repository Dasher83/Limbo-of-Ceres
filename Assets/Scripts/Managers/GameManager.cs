using LimboOfCeres.Scripts.AudioScripts;
using LimboOfCeres.Scripts.Shared.Enums;
using LimboOfCeres.Scripts.Shared.Interfaces;
using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using LimboOfCeres.Scripts.UI;
using System.Collections.Generic;
using UnityEngine;


namespace LimboOfCeres.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerScriptable playerData;
        [SerializeField] private List<ScriptableObject> initializables;
        [SerializeField] private GameOver gameOverMenu;
        [SerializeField] private LifeBar lifeBar;
        [SerializeField] private MetersCounter metersCounter;
        [SerializeField] private List<GameObject> toDeactivateOnGameOver;

        private GameState currentState;

        void Awake()
        {
            SetState(GameState.STARTING);
        }
        
        void Update()
        {
            if (currentState == GameState.STARTING)
            {
                SetState(GameState.PLAYING);
            }

            if (playerData.CurrentDurability == 0  && currentState != GameState.GAMEOVER)
            {
                SetState(GameState.GAMEOVER);
            }

            if (currentState == GameState.PLAYING)
            {
                metersCounter.MetersUpdate();
            }
        }

        public void SetState(GameState state)
        {
            currentState = state;

            switch (state)
            {
                case GameState.STARTING:
                    foreach(IInitializable initializable in initializables)
                    {
                        initializable.Initialize();
                    }
                    lifeBar.Durable = (IDurable)playerData;
                    break;
                case GameState.PLAYING:
                    AudioPlayer.instance.PlaySong(SongsEnum.MAIN_GAME_AMBIENT_SONG, delay: 3.8f);
                    AudioPlayer.instance.PlaySoundEffect(SoundEffectsEnum.MALE_HAPPY_HALLOWEEN_WARNING);
                    break;
                case GameState.GAMEOVER:
                    // TODO : fall animation
                    AudioPlayer.instance.StopSong();
                    Time.timeScale = 0f;
                    DeactivateOnGameOver();
                    gameOverMenu.StartGameOver();
                    break;
            }
        }

        private void DeactivateOnGameOver()
        {
            metersCounter.gameObject.SetActive(false);
            foreach(GameObject toBeDeactivated in toDeactivateOnGameOver)
            {
                toBeDeactivated.SetActive(false);
            }
        }
    }
}
