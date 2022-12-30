using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using LimboOfCeres.Scripts.TimeScripts;
using LimboOfCeres.Scripts.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace LimboOfCeres.Scripts.Spawnables.Obstacles
{
    public class SpawnObstacles : MonoBehaviour
    {
        [SerializeField]
        private ObstacleDataScriptableObject obstacleData;
        [SerializeField]
        private SpriteRenderer floorSpriteRenderer;
        [SerializeField]
        private SpriteRenderer ceilingSpriteRenderer;
        [SerializeField]
        private GameObject prefabToSpawn;
        private ResettableTimer spawnTimer;
        private Vector3 newPosition;
        private List<GameObject> pool;
        private GameObject newlyCreatedSpwanable;
        private GameObject nextToBeSpawn;
        [SerializeField]
        private List<Sprite> sprites;

        private void Start()
        {
            newPosition = Vector3.zero;
            spawnTimer = new ResettableTimer(time: Random.Range(obstacleData.MinimumRespawnTime, obstacleData.MaximumRespawnTime));
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
            spawnTimer.Reset(time: Random.Range(obstacleData.MinimumRespawnTime, obstacleData.MaximumRespawnTime));
        }

        private void Spawn()
        {
            nextToBeSpawn = InactiveSpawnable;
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

        private GameObject InactiveSpawnable
        {
            get
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
        }

        private GameObject CreateNewSpawnable()
        {
            newlyCreatedSpwanable = Instantiate(prefabToSpawn, gameObject.transform);
            InitializeNewSpawnable();
            pool.Add(newlyCreatedSpwanable);
            return newlyCreatedSpwanable;
        }

        private void InitializeNewSpawnable()
        {
            newlyCreatedSpwanable.GetComponent<SpriteRenderer>().sprite = RandomSprite;
        }

        private Sprite RandomSprite => sprites[Random.Range(0, sprites.Count)];

        private void RePositionSpawnable()
        {
            newPosition.x = CameraUtils.OrthographicBounds.max.x + nextToBeSpawn.GetComponent<SpriteRenderer>().bounds.size.x;
            nextToBeSpawn.GetComponent<Rigidbody2D>().gravityScale = Constants.Obstacles.DefaultGravityScale;

            if (Random.value >= Constants.Obstacles.CeilingSpawnProbability)
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
