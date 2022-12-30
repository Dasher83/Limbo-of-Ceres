using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.TimeScripts;
using LimboOfCeres.Scripts.Utils;
using UnityEngine;
using LimboOfCeres.Scripts.Spawnables.Enemies.Shared;
using LimboOfCeres.Scripts.PlayerScritps;
using System.Collections.Generic;

namespace LimboOfCeres.Scripts.Spawnables.Enemies.Jackolanterns
{
    public class SpawnJackolanterns : MonoBehaviour
    {
        [SerializeField]
        private JackolanternDataScriptableObject jackolanternData;
        [SerializeField]
        private SpawnPumpkinBullets pumpkinBulletsSpawner;
        [SerializeField]
        private GameObject prefabToSpawn;
        private Transform target = null;
        private SpriteRenderer floorSpriteRenderer = null;
        private SpriteRenderer ceilingSpriteRenderer = null;
        private ResettableTimer spawnTimer;
        private Vector3 newPosition;
        private PlayerRespawnSafely playerRespawnSafely = null;
        private GameObject nextToBeSpawn;
        private List<GameObject> pool;
        GameObject newlyCreatedSpwanable;

        private void Start()
        {
            GameObject player = GameObject.FindGameObjectWithTag(Constants.Tags.Player);
            target = player.transform;
            playerRespawnSafely = player.GetComponent<PlayerRespawnSafely>();
            floorSpriteRenderer = GameObject.Find(Constants.GameObjects.MainFloor).GetComponent<SpriteRenderer>();
            ceilingSpriteRenderer = GameObject.Find(Constants.GameObjects.MainCeiling).GetComponent<SpriteRenderer>();
            newPosition = Vector3.zero;
            spawnTimer = new ResettableTimer(time: Random.Range(jackolanternData.MinimumRespawnTime, jackolanternData.MaximumRespawnTime));
            nextToBeSpawn = null;
            pool = new List<GameObject>();
            newlyCreatedSpwanable = null;
        }

        private void Update()
        {
            spawnTimer.Countdown(Time.deltaTime);

            if (!spawnTimer.OutOfTime)
            {
                return;
            }

            Spawn();
            nextToBeSpawn = null;
            spawnTimer.Reset(time: Random.Range(jackolanternData.MinimumRespawnTime, jackolanternData.MaximumRespawnTime));
        }

        private void Spawn()
        {
            nextToBeSpawn = GetInactiveSpawnable();
            if (nextToBeSpawn == null)
            {
                nextToBeSpawn = CreateNewSpawnable();
                newlyCreatedSpwanable = null;
            }
            else
            {
                nextToBeSpawn.SetActive(true);
            }

            RePositionSpawnable();
        }

        private GameObject GetInactiveSpawnable()
        {
            foreach (GameObject spawnable in pool)
            {
                if (!spawnable.activeSelf)
                {
                    return spawnable;
                }
            }
            return null;
        }

        private GameObject CreateNewSpawnable()
        {
            newlyCreatedSpwanable = Instantiate(prefabToSpawn, gameObject.transform);
            newlyCreatedSpwanable.GetComponent<ShootPumpkin>().PumpkinBulletSpawner = pumpkinBulletsSpawner;
            newlyCreatedSpwanable.GetComponent<ShootPumpkin>().PlayerRespawnSafely = playerRespawnSafely;
            newlyCreatedSpwanable.GetComponent<FaceTarget>().LockedOnTarget = target;
            newlyCreatedSpwanable.GetComponent<ShootPumpkin>().LockedOnTarget = target;
            pool.Add(newlyCreatedSpwanable);
            return newlyCreatedSpwanable;
        }

        private void RePositionSpawnable()
        {
            newPosition.x = CameraUtils.OrthographicBounds.max.x + nextToBeSpawn.GetComponent<SpriteRenderer>().bounds.size.x;
            nextToBeSpawn.GetComponent<Rigidbody2D>().gravityScale = Constants.Enemies.Jackolanterns.DefaultGravityScale;

            if (Random.value >= Constants.Enemies.Jackolanterns.CeilingSpawnProbability)
            {
                newPosition.y = CameraUtils.OrthographicBounds.max.y - nextToBeSpawn.GetComponent<SpriteRenderer>().bounds.size.y;
                newPosition.y -= ceilingSpriteRenderer.bounds.size.y;
                nextToBeSpawn.GetComponent<SpriteRenderer>().flipY = true;
                nextToBeSpawn.GetComponent<Rigidbody2D>().gravityScale *= -1;
            }
            else
            {
                newPosition.y = CameraUtils.OrthographicBounds.min.y + nextToBeSpawn.GetComponent<SpriteRenderer>().bounds.size.y;
                newPosition.y += floorSpriteRenderer.bounds.size.y;
                nextToBeSpawn.GetComponent<SpriteRenderer>().flipY = false;
            }

            nextToBeSpawn.transform.position = newPosition;
        }
    }
}
