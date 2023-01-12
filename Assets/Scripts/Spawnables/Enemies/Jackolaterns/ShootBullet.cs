using LimboOfCeres.Scripts.Difficulty.Upgraders;
using LimboOfCeres.Scripts.PlayerScritps;
using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.TimeScripts;
using UnityEngine;


namespace LimboOfCeres.Scripts.Spawnables.Enemies.Jackolanterns
{
    public class ShootBullet : MonoBehaviour
    {
        [SerializeField]
        private LayerMask IgnoreMe;
        [SerializeField]
        private float range;
        [SerializeField]
        private float fireForceMinimum;
        [SerializeField]
        private float fireForceMaximum;
        [SerializeField]
        private Color cooldownColor;
        [SerializeField]
        private GameObject pumpkinPrefab;
        private UpgradeBulletData bulletDataUpgrader;
        private Transform lockedOnTarget;
        private ResettableTimer aimTimer;
        private ResettableTimer fireTimer;
        private Vector2 directionToAim;
        private bool clearShot;
        private BulletSpawner bulletSpawner = null;
        private PlayerRespawnSafely playerRespawnSafely;
        private Color originalColor;
        private SpriteRenderer spriteRender;
        private int ammoRequests;
        private Rigidbody2D rb;
        private Rigidbody2D pumpkinRigidBody2D;
        private GameObject pumpkinInstance;
        private RaycastHit2D rayInfo;
        private PhysicsMaterial2D newPhysicsMaterial2D;

        public Transform LockedOnTarget { set { lockedOnTarget = value; } }
        public BulletSpawner BulletSpawner { set { bulletSpawner = value; } }

        public PlayerRespawnSafely PlayerRespawnSafely { set { playerRespawnSafely = value; } }

        public UpgradeBulletData BulletDataUpgrader { set { bulletDataUpgrader = value; } }

        private float FireForce
        {
            get
            {
                return Random.Range(fireForceMinimum, fireForceMaximum);
            }
        }

        private float AimRate
        {
            get
            {
                if(rb.gravityScale > 0)
                {
                    return Random.Range(
                        Constants.Enemies.Jackolanterns.AimRateMinimum,
                        Constants.Enemies.Jackolanterns.AimRateMaximum) * Constants.Enemies.Jackolanterns.FloorSpeedBoost;
                }
                return Random.Range(Constants.Enemies.Jackolanterns.AimRateMinimum, Constants.Enemies.Jackolanterns.AimRateMaximum);
            }
        }

        private float FireRate
        {
            get
            {
                if (rb.gravityScale > 0)
                {
                    return Random.Range(
                        Constants.Enemies.Jackolanterns.FireRateMinimum,
                        Constants.Enemies.Jackolanterns.FireRateMaximum) * Constants.Enemies.Jackolanterns.FloorSpeedBoost;
                }
                return Random.Range(Constants.Enemies.Jackolanterns.FireRateMinimum, Constants.Enemies.Jackolanterns.FireRateMaximum);
            }
        }

        private int NextAmmoRequests
        {
            get
            {
                return Random.Range(Constants.Enemies.Jackolanterns.AmmoRequestsMinimum, Constants.Enemies.Jackolanterns.AmmoRequestsMaximum + 1);
            }
        }

        private float BulletGravityScale => Random.Range(bulletDataUpgrader.GravityScaleMinimum, bulletDataUpgrader.GravityScaleMinimum);

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
            rb = gameObject.GetComponent<Rigidbody2D>();
            spriteRender = gameObject.GetComponent<SpriteRenderer>();
            aimTimer = new ResettableTimer(AimRate);
            fireTimer = new ResettableTimer(FireRate);
            originalColor = spriteRender.color;
            ammoRequests = NextAmmoRequests;
        }

        private void Update()
        {
            if (lockedOnTarget == null || bulletSpawner == null || playerRespawnSafely == null) return;

            if (playerRespawnSafely.IsPlayerProtected)
            {
                if (aimTimer.OutOfTime) aimTimer.Reset(AimRate);
                if (fireTimer.OutOfTime) fireTimer.Reset(FireRate);
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
                aimTimer.Reset(AimRate);
            }

            if (fireTimer.OutOfTime && clearShot && OutsideDiplomaticThreshold)
            {
                Fire();
                fireTimer.Reset(FireRate);
                clearShot = false;
            }
        }

        private void Aim()
        {
            directionToAim = (Vector2)lockedOnTarget.position - (Vector2)ShootPosition;
            directionToAim.Normalize();
            rayInfo = Physics2D.Raycast(transform.position, directionToAim, range, ~IgnoreMe);
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
            if (ammoRequests > 0)
            {
                ammoRequests--;
                pumpkinInstance = bulletSpawner.RequestObject(ShootPosition);
                pumpkinRigidBody2D = pumpkinInstance.GetComponent<Rigidbody2D>();
                pumpkinRigidBody2D.gravityScale = BulletGravityScale;
                if(rb.gravityScale < 0)
                {
                    pumpkinRigidBody2D.gravityScale *= -1;
                }
                if(pumpkinRigidBody2D.sharedMaterial.bounciness != bulletDataUpgrader.Bounciness)
                {
                    newPhysicsMaterial2D = new PhysicsMaterial2D();
                    newPhysicsMaterial2D.bounciness = bulletDataUpgrader.Bounciness;
                    pumpkinRigidBody2D.sharedMaterial = newPhysicsMaterial2D;
                }
                pumpkinRigidBody2D.AddForce(FireForce * Random.Range(0.75f, 1.00f) * directionToAim);
            }
        }

        void OnDisable()
        {
            ammoRequests = NextAmmoRequests;
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
