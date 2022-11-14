using QuarkAcademyJam1Team1.Scripts.Shared;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.ExtraLife
{
    public class MoveExtraLife : MonoBehaviour
    {
        private void Update()
        {
            gameObject.transform.Translate(Vector3.left * Constants.ExtraLife.MovementSpeed * Time.deltaTime);
        }
    }
}
