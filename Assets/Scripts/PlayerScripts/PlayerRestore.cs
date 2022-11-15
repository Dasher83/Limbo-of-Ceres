using QuarkAcademyJam1Team1.Scripts.Shared.Interfaces;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.PlayerScritps
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
