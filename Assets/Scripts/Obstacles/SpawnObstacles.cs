using QuarkAcademyJam1Team1.Scripts.Shared;
using QuarkAcademyJam1Team1.Scripts.Shared.ScriptableObjectsDefinitions;
using QuarkAcademyJam1Team1.Scripts.TimeScripts;
using QuarkAcademyJam1Team1.Scripts.Utils;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.Obstacles
{
    public class SpawnObstacles : MonoBehaviour
    {
        [SerializeField]
        private ObstacleDataScriptableObject obstacleData;
        [SerializeField]
        private SpriteRenderer floorSpriteRenderer;
        [SerializeField]
        private SpriteRenderer ceilingSpriteRenderer;
        private ResettableTimer spawnTimer;
        private Vector3 newPosition;

        private void SpawnObstacle(GameObject obstacle)
        {
            newPosition.x = CameraUtils.OrthographicBounds.max.x + obstacle.GetComponent<SpriteRenderer>().bounds.size.x;
            obstacle.GetComponent<Rigidbody2D>().gravityScale = Constants.Obstacles.DefaultGravityScale;

            if (Random.value >= Constants.Obstacles.CeilingSpawnProbability)
            {
                newPosition.y = CameraUtils.OrthographicBounds.max.y - obstacle.GetComponent<SpriteRenderer>().bounds.size.y;
                newPosition.y -= ceilingSpriteRenderer.bounds.size.y;
                obstacle.GetComponent<SpriteRenderer>().flipY = true;
                obstacle.GetComponent<Rigidbody2D>().gravityScale *= -1;
            }
            else
            {
                newPosition.y = CameraUtils.OrthographicBounds.min.y + obstacle.GetComponent<SpriteRenderer>().bounds.size.y;
                newPosition.y += floorSpriteRenderer.bounds.size.y;
                obstacle.GetComponent<SpriteRenderer>().flipY = false;
            }

            obstacle.transform.position = newPosition;
            obstacle.SetActive(true);
        }

        private void Start()
        {
            newPosition = Vector3.zero;
            spawnTimer = new ResettableTimer(time: Random.Range(obstacleData.MinimumRespawnTime, obstacleData.MaximumRespawnTime));
        }

        private void Update()
        {
            spawnTimer.Countdown(Time.deltaTime);

            if (!spawnTimer.OutOfTime)
            {
                return;
            }

            for(int i=0; i < gameObject.transform.childCount; i++)
            {
                if (gameObject.transform.GetChild(i).gameObject.activeSelf) continue;
                SpawnObstacle(gameObject.transform.GetChild(i).gameObject);
                spawnTimer.Reset(time: Random.Range(obstacleData.MinimumRespawnTime, obstacleData.MaximumRespawnTime));
                break;
            }
        }
    }
}
