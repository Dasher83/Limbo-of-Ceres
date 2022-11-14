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
        [SerializeField] private GameOver gameOverMenu;
        [SerializeField] private LifeBar lifeBar;
        [SerializeField] private MetersCounter metersCounter;
        [SerializeField] private GameObject pauseButton;

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

            if (playerData.CurrentDurability == 0 && currentState != GameState.GAMEOVER)
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
                    SetState(GameState.PLAYING);
                    break;
                case GameState.PLAYING:
                    break;
                case GameState.GAMEOVER:
                    // TODO : fall animation
                    Time.timeScale = 0f;
                    HideIuInGameOver();
                    gameOverMenu.StartGameOver();
                    break;
            }
        }

        private void HideIuInGameOver()
        {
            metersCounter.gameObject.SetActive(false);
            pauseButton.SetActive(false);
        }
    }
}
