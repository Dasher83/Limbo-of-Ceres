using LimboOfCeres.Scripts.Shared.Interfaces;
using UnityEngine;

namespace LimboOfCeres.Scripts.PlayerScritps
{
    public class PlayerRestore : MonoBehaviour, IRestorable
    {
        private IRestorable restorable;

        private void Start()
        {
            restorable = gameObject.GetComponent<PlayerDataContainer>().PlayerData;
        }

        public int ReceiveRestauration(int restauration)
        {
            return restorable.ReceiveRestauration(restauration);
        }
    }
}
