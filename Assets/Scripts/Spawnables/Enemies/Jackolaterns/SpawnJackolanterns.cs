using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.TimeScripts;
using LimboOfCeres.Scripts.Utils;
using UnityEngine;
using LimboOfCeres.Scripts.Spawnables.Enemies.Shared;
using LimboOfCeres.Scripts.PlayerScritps;

namespace LimboOfCeres.Scripts.Spawnables.Enemies.Jackolanterns
{
    public class SpawnJackolanterns : MonoBehaviour
    {
        [SerializeField]
        private JackolanternDataScriptableObject jackolanternData;
        private Transform target = null;
        private SpriteRenderer floorSpriteRenderer = null;
        private SpriteRenderer ceilingSpriteRenderer = null;
        private ResettableTimer spawnTimer;
        private Vector3 newPosition;
        private SpawnPumpkinBullets pumpkinBulletsSpawner = null;
        private PlayerRespawnSafely playerRespawnSafely = null;

        private void SpawnJackolantern(GameObject jackolantern)
        {
            newPosition.x = CameraUtils.OrthographicBounds.max.x + jackolantern.GetComponent<SpriteRenderer>().bounds.size.x;
            jackolantern.GetComponent<Rigidbody2D>().gravityScale = Constants.Enemies.Jackolanterns.DefaultGravityScale;

            if (Random.value >= Constants.Enemies.Jackolanterns.CeilingSpawnProbability)
            {
                newPosition.y = CameraUtils.OrthographicBounds.max.y - jackolantern.GetComponent<SpriteRenderer>().bounds.size.y;
                newPosition.y -= ceilingSpriteRenderer.bounds.size.y;
                jackolantern.GetComponent<SpriteRenderer>().flipY = true;
                jackolantern.GetComponent<Rigidbody2D>().gravityScale *= -1;
            }
            else
            {
                newPosition.y = CameraUtils.OrthographicBounds.min.y + jackolantern.GetComponent<SpriteRenderer>().bounds.size.y;
                newPosition.y += floorSpriteRenderer.bounds.size.y;
                jackolantern.GetComponent<SpriteRenderer>().flipY = false;
            }

            jackolantern.transform.position = newPosition;
            jackolantern.GetComponent<ShootPumpkin>().PumpkinBulletSpawner = pumpkinBulletsSpawner;
            jackolantern.GetComponent<ShootPumpkin>().PlayerRespawnSafely = playerRespawnSafely;
            jackolantern.SetActive(true);
        }

        private void Start()
        {
            GameObject player = GameObject.FindGameObjectWithTag(Constants.Tags.Player);
            target = player.transform;
            playerRespawnSafely = player.GetComponent<PlayerRespawnSafely>();
            floorSpriteRenderer = GameObject.Find(Constants.GameObjects.MainFloor).GetComponent<SpriteRenderer>();
            ceilingSpriteRenderer = GameObject.Find(Constants.GameObjects.MainCeiling).GetComponent<SpriteRenderer>();
            pumpkinBulletsSpawner = GameObject.Find(Constants.GameObjects.PumpkinBulletsSpawner).GetComponent<SpawnPumpkinBullets>();
            newPosition = Vector3.zero;
            spawnTimer = new ResettableTimer(time: Random.Range(jackolanternData.MinimumRespawnTime, jackolanternData.MaximumRespawnTime));
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                gameObject.transform.GetChild(i).gameObject.GetComponent<FaceTarget>().LockedOnTarget = target;
                gameObject.transform.GetChild(i).gameObject.GetComponent<ShootPumpkin>().LockedOnTarget = target;
            }
        }

        private void Update()
        {
            spawnTimer.Countdown(Time.deltaTime);

            if (!spawnTimer.OutOfTime)
            {
                return;
            }

            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                if (gameObject.transform.GetChild(i).gameObject.activeSelf) continue;
                SpawnJackolantern(gameObject.transform.GetChild(i).gameObject);
                spawnTimer.Reset(time: Random.Range(jackolanternData.MinimumRespawnTime, jackolanternData.MaximumRespawnTime));
                break;
            }
        }
    }
}
