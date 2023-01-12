using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using UnityEngine;

namespace LimboOfCeres.Scripts.PlayerScritps
{
    public class PlayerDataContainer : MonoBehaviour
    {
        [SerializeField]
        private PlayerDataScriptable playerData;

        public PlayerDataScriptable PlayerData { get { return playerData; } }
    }
}
