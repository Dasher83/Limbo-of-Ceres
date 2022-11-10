using QuarkAcademyJam1Team1.Scripts.Shared.ScriptableObjectsDefinitions;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.PlayerScritps
{
    public class PlayerDataContainer : MonoBehaviour
    {
        [SerializeField]
        private PlayerData playerData;

        public PlayerData PlayerData { get { return playerData; } }
    }
}
