using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.Shared.ScriptableObjectsDefinitions
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 2)]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private int lifes;
        private float meters;

        public int Lifes { get { return lifes; } }

        public void AddLifes()
        {
            if (lifes == Constants.Player.MaxLifes)
            {
                return;
            }
            lifes++;
            Debug.Log("la vida actual es: " + lifes);
        }

       public void RemoveLife()
       {
            lifes--;
            Debug.Log("la vida actual es: " + lifes);
       }

       public void SetInitialLifes()
       {
            lifes = Constants.Player.InitialLifes;
       }
    }
}
