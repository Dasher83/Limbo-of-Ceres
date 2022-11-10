using QuarkAcademyJam1Team1.Scripts.Shared;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.Enemies.Jackolaterns
{
    public class PumkinDestruction : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(Constants.Tags.Player))
            {
                // TODO AFTER REBASE: add a recieveDamage statement
            }
            Destroy(gameObject);
        }
    }
}
