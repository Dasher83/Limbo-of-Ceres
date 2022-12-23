using UnityEngine;

namespace LimboOfCeres.Scripts.Spawnables.Enemies.Shared
{
    public class FaceTarget : MonoBehaviour
    {
        private Transform lockedOnTarget;

        public Transform LockedOnTarget { set { lockedOnTarget = value; } }

        private void Update()
        {
            if (lockedOnTarget == null) return;
            if(gameObject.transform.position.x < lockedOnTarget.position.x)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }
}
