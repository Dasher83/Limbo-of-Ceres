using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.Shared.ScriptableObjectsDefinitions
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 2)]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private int lifes = Constants.Player.InitialLifes;
        private float meters;

        public int Lifes { get { return lifes; } }

        public void AddLives()
        {
            lifes++;
            Debug.Log("la vida actual es: " + lifes);
        }

       public void RemoveLife()
       {
            lifes--;
            Debug.Log("la vida actual es: " + lifes);
       }
    }
}
