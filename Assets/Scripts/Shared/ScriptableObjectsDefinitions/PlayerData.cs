using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.Shared.ScriptableObjectsDefinitions
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 2)]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private int lives = /*Constants.Player.InitialLife*/3;
        private float meters;

        public int Lives { get { return lives; } }

        public void AddLives()
        {
            lives++;
            Debug.Log("la vida actual es: " + Lives);
        }

       public void RemoveLife()
       {
            lives--;
            Debug.Log("la vida actual es: " + Lives);
       }
    }
}
