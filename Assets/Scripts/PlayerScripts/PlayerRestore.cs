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

        public void ReceiveRestauration(int restauration)
        {
            restorable.ReceiveRestauration(restauration);
        }
    }
}
