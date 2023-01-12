using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Utils;
using UnityEngine;
using LimboOfCeres.Scripts.Spawnables.Enemies.Shared;
using LimboOfCeres.Scripts.PlayerScritps;
using LimboOfCeres.Scripts.Spawnables.Shared;
using LimboOfCeres.Scripts.Difficulty.Upgraders;

namespace LimboOfCeres.Scripts.Spawnables.Enemies.Jackolanterns
{
    public class JackolanternSpawner : ContinuousObjectSpawner
    {
        [SerializeField]
        private BulletSpawner bulletsSpawner;
        private Transform target = null;
        private SpriteRenderer floorSpriteRenderer = null;
        private SpriteRenderer ceilingSpriteRenderer = null;
        private Vector3 newPosition;
        private PlayerRespawnSafely playerRespawnSafely = null;

        protected override void Start()
        {
            base.Start();
            GameObject player = GameObject.FindGameObjectWithTag(Constants.Tags.Player);
            target = player.transform;
            playerRespawnSafely = player.GetComponent<PlayerRespawnSafely>();
            floorSpriteRenderer = GameObject.Find(Constants.GameObjects.MainFloor).GetComponent<SpriteRenderer>();
            ceilingSpriteRenderer = GameObject.Find(Constants.GameObjects.MainCeiling).GetComponent<SpriteRenderer>();
            newPosition = Vector3.zero;
        }

        protected override void InitializeNewSpawnable()
        {
            this.newlyCreatedSpwanable.GetComponent<ShootBullet>().BulletSpawner = bulletsSpawner;
            this.newlyCreatedSpwanable.GetComponent<ShootBullet>().PlayerRespawnSafely = playerRespawnSafely;
            this.newlyCreatedSpwanable.GetComponent<ShootBullet>().LockedOnTarget = target;
            this.newlyCreatedSpwanable.GetComponent<FaceTarget>().LockedOnTarget = target;
        }

        protected override void PositionSpawnable()
        {
            newPosition.x = CameraUtils.OrthographicBounds.max.x + this.nextToBeSpawn.GetComponent<SpriteRenderer>().bounds.size.x;
            this.nextToBeSpawn.GetComponent<Rigidbody2D>().gravityScale = Constants.Enemies.Jackolanterns.DefaultGravityScale;

            if (Random.value >= Constants.Enemies.Jackolanterns.CeilingSpawnProbability)
            {
                newPosition.y = CameraUtils.OrthographicBounds.max.y - this.nextToBeSpawn.GetComponent<SpriteRenderer>().bounds.size.y;
                newPosition.y -= ceilingSpriteRenderer.bounds.size.y;
                this.nextToBeSpawn.GetComponent<SpriteRenderer>().flipY = true;
                this.nextToBeSpawn.GetComponent<Rigidbody2D>().gravityScale *= -1;
            }
            else
            {
                newPosition.y = CameraUtils.OrthographicBounds.min.y + this.nextToBeSpawn.GetComponent<SpriteRenderer>().bounds.size.y;
                newPosition.y += floorSpriteRenderer.bounds.size.y;
                this.nextToBeSpawn.GetComponent<SpriteRenderer>().flipY = false;
            }

            this.nextToBeSpawn.transform.position = newPosition;
        }
    }
}
