using QuarkAcademyJam1Team1.Scripts.Shared;
using QuarkAcademyJam1Team1.Scripts.TimeScripts;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.Enemies.Jackolaterns
{
    public class ShootPumpkin : MonoBehaviour
    {
        [SerializeField]
        private LayerMask IgnoreMe;
        [SerializeField]
        private float aimRate;
        [SerializeField]
        private float fireRate;
        [SerializeField]
        private float range;
        [SerializeField]
        private float fireForce;
        [SerializeField]
        private GameObject pumpkinPrefab;
        [SerializeField]
        private Transform lockedOnTarget;

        private ResettableTimer aimTimer;
        private ResettableTimer fireTimer;
        private Vector2 directionToAim;
        private bool clearShot;

        private Vector3 ShootPosition { 
            get {
                Vector3 spawnPosition = transform.position;
                spawnPosition.y += GetComponent<SpriteRenderer>().bounds.extents.y + Mathf.Epsilon;
                if(gameObject.transform.position.x > lockedOnTarget.transform.position.x)
                {
                    spawnPosition.x -= GetComponent<SpriteRenderer>().bounds.extents.x + Mathf.Epsilon;
                }
                else
                {
                    spawnPosition.x += GetComponent<SpriteRenderer>().bounds.extents.x + Mathf.Epsilon;
                }

                return spawnPosition;
            }
        }

        private void Start()
        {
            aimTimer = new ResettableTimer(aimRate);
            fireTimer = new ResettableTimer(fireRate);
        }

        private void Update()
        {
            if (lockedOnTarget == null) return;

            aimTimer.Countdown(Time.deltaTime);
            fireTimer.Countdown(Time.deltaTime);

            if (aimTimer.OutOfTime)
            {
                Aim();
                if (!Mathf.Approximately(aimRate, aimTimer.InitialSettime))
                {
                    aimTimer = new ResettableTimer(aimRate);
                }
                else
                {
                    aimTimer.Reset();
                }
            }

            if (fireTimer.OutOfTime && clearShot)
            {
                Fire();
                if (!Mathf.Approximately(fireRate, fireTimer.InitialSettime))
                {
                    fireTimer = new ResettableTimer(fireRate);
                } 
                else
                {
                    fireTimer.Reset();
                }
                clearShot = false;
            }
        }

        private void Aim()
        {
            directionToAim = (Vector2)lockedOnTarget.position - (Vector2)gameObject.transform.position;
            RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, directionToAim, range, ~IgnoreMe);
            if (rayInfo)
            {
                if (rayInfo.collider.gameObject.CompareTag(Constants.Tags.Player))
                {
                    clearShot = true;
                }
                else
                {
                    clearShot = false;
                }
            }
        }

        private void Fire()
        {
            GameObject pumpkinInstance = Instantiate(pumpkinPrefab, ShootPosition, Quaternion.identity);
            pumpkinInstance.GetComponent<Rigidbody2D>().AddForce(directionToAim * fireForce);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(gameObject.transform.position, range);
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(gameObject.transform.position, lockedOnTarget.position);
        }
    }
}
