using QuarkAcademyJam1Team1.Scripts.AudioScripts;
using QuarkAcademyJam1Team1.Scripts.Shared.Enums;
using QuarkAcademyJam1Team1.Scripts.Shared.Interfaces;
using QuarkAcademyJam1Team1.Scripts.Shared.ScriptableObjectsDefinitions;
using QuarkAcademyJam1Team1.Scripts.UI;
using UnityEngine;


namespace QuarkAcademyJam1Team1.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData;
        [SerializeField] private GameObject GameOverMenu;
        [SerializeField] private LifeBar lifeBar;
        [SerializeField] private MetersCounter metersCounter;

        private GameState currentState;

        void Awake()
        {
            SetState(GameState.STARTING);
        }
        
        void Update()
        {
            // Debugger
            if (Input.GetKeyDown(KeyCode.H))
            {
                playerData.ReceiveRestauration(1);
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                playerData.ReceiveDamage(1);
            }
            // Debugger

            if (currentState == GameState.STARTING)
            {
                SetState(GameState.PLAYING);
            }

            if (playerData.CurrentDurability == 0)
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
                    playerData.Initialize();
                    lifeBar.Durable = (IDurable)playerData;
                    break;
                case GameState.PLAYING:
                    AudioPlayer.instance.PlaySong(SongsEnum.MAIN_GAME_AMBIENT_SONG, delay: 3.8f);
                    AudioPlayer.instance.PlaySoundEffect(SoundEffectsEnum.MALE_HAPPY_HALLOWEEN_WARNING);
                    break;
                case GameState.GAMEOVER:
                    // TODO : fall animation
                    AudioPlayer.instance.StopSong();
                    GameOverMenu.SetActive(true);
                    Time.timeScale = 0f;
                    break;
            }
        }
    }
}
