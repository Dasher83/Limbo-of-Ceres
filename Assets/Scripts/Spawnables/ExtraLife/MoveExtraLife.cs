using LimboOfCeres.Scripts.Shared;
using UnityEngine;

namespace LimboOfCeres.Scripts.Spawnables.ExtraLife
{
    public class MoveExtraLife : MonoBehaviour
    {
        private void Update()
        {
            gameObject.transform.Translate(Vector3.left * Constants.ExtraLife.MovementSpeed * Time.deltaTime);
        }
    }
}
