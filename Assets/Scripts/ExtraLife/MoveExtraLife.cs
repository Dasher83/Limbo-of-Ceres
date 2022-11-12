using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.ExtraLife
{
    public class MoveExtraLife : MonoBehaviour
    {
        [SerializeField]
        private float movementSpeed;

        private void Update()
        {
            gameObject.transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
        }
    }
}
