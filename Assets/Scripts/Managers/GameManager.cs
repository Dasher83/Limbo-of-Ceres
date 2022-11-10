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

            if (playerData.CurrentDurability == 0)
            {
                SetState(GameState.GAMEOVER);
            }
        }

        public void SetState(GameState state)
        {
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
                    // TODO: if we not use this manager eny more, but steel have this logic here is where the animation need to be
                    GameOverMenu.SetActive(true);
                    Time.timeScale = 0f;
                    break;
            }
        }
    }
}
