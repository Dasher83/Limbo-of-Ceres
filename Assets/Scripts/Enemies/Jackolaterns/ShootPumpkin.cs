using QuarkAcademyJam1Team1.Scripts.PlayerScritps;
using QuarkAcademyJam1Team1.Scripts.Shared;
using QuarkAcademyJam1Team1.Scripts.TimeScripts;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.Enemies.Jackolanterns
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
        private Color cooldownColor;
        [SerializeField]
        private GameObject pumpkinPrefab;
        private Transform lockedOnTarget;
        private ResettableTimer aimTimer;
        private ResettableTimer fireTimer;
        private Vector2 directionToAim;
        private bool clearShot;
        private SpawnPumpkinBullets pumpkinBulletSpawner;
        private PlayerRespawnSafely playerRespawnSafely;
        private Color originalColor;
        private SpriteRenderer spriteRender;

        public Transform LockedOnTarget { set { lockedOnTarget = value; } }
        public SpawnPumpkinBullets PumpkinBulletSpawner { set { pumpkinBulletSpawner = value; } }

        public PlayerRespawnSafely PlayerRespawnSafely { set { playerRespawnSafely = value; } }

        private Vector3 ShootPosition { 
            get {
                Vector3 spawnPosition = transform.position;
                if(gameObject.transform.position.x > lockedOnTarget.transform.position.x)
                {
                    spawnPosition.x -= GetComponent<SpriteRenderer>().bounds.extents.x + Mathf.Epsilon;
                }
                else
                {
                    spawnPosition.x += GetComponent<SpriteRenderer>().bounds.extents.x + Mathf.Epsilon;
                }
                if(gameObject.GetComponent<Rigidbody2D>().gravityScale > 0)
                {
                    spawnPosition.y += GetComponent<SpriteRenderer>().bounds.extents.y + Mathf.Epsilon;
                }
                else
                {
                    spawnPosition.y -= GetComponent<SpriteRenderer>().bounds.extents.y + Mathf.Epsilon;
                }

                return spawnPosition;
            }
        }

        private bool OutsideDiplomaticThreshold
        {
            get
            {
                return gameObject.transform.position.x > lockedOnTarget.transform.position.x + Constants.Enemies.Jackolanterns.DiplomaticThreshold;
            }
        }

        private void Start()
        {
            aimTimer = new ResettableTimer(aimRate);
            fireTimer = new ResettableTimer(fireRate);
            spriteRender = gameObject.GetComponent<SpriteRenderer>();
            originalColor = spriteRender.color;
        }

        private void Update()
        {
            if (lockedOnTarget == null || pumpkinBulletSpawner == null || playerRespawnSafely == null) return;

            if (playerRespawnSafely.IsPlayerProtected)
            {
                if (aimTimer.OutOfTime) aimTimer.Reset();
                if (fireTimer.OutOfTime) fireTimer.Reset();
            }
            else
            {
                aimTimer.Countdown(Time.deltaTime);
                fireTimer.Countdown(Time.deltaTime);
            }

            if(playerRespawnSafely.IsPlayerProtected && spriteRender.color == originalColor)
            {
                spriteRender.color = cooldownColor;
            }

            if(!playerRespawnSafely.IsPlayerProtected && spriteRender.color == cooldownColor)
            {
                spriteRender.color = originalColor;
            }

            if (aimTimer.OutOfTime)
            {
                Aim();
                if (!Mathf.Approximately(aimRate, aimTimer.NextTimeToCountdown))
                {
                    aimTimer.Reset(aimRate);
                }
                else
                {
                    aimTimer.Reset();
                }
            }

            if (fireTimer.OutOfTime && clearShot && OutsideDiplomaticThreshold)
            {
                Fire();
                if (!Mathf.Approximately(fireRate, fireTimer.NextTimeToCountdown))
                {
                    fireTimer.Reset(fireRate);
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
            directionToAim = (Vector2)lockedOnTarget.position - (Vector2)ShootPosition;
            directionToAim.Normalize();
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
            GameObject pumpkinInstance = pumpkinBulletSpawner.Spawn(spawnPosition: ShootPosition);
            pumpkinInstance.GetComponent<Rigidbody2D>().AddForce(directionToAim * fireForce * Random.Range(0.75f, 1.00f));
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(gameObject.transform.position, range);
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(ShootPosition, lockedOnTarget.position);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(
                new Vector3(lockedOnTarget.transform.position.x + Constants.Enemies.Jackolanterns.DiplomaticThreshold, 1000, 0),
                new Vector3(lockedOnTarget.transform.position.x + Constants.Enemies.Jackolanterns.DiplomaticThreshold, -1000, 0));
        }
    }
}
