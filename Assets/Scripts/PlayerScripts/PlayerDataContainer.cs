using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using UnityEngine;

namespace LimboOfCeres.Scripts.PlayerScritps
{
    public class PlayerDataContainer : MonoBehaviour
    {
        [SerializeField]
        private PlayerScriptable playerData;

        public PlayerScriptable PlayerData { get { return playerData; } }
    }
}
