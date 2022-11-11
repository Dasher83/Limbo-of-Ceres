using QuarkAcademyJam1Team1.Scripts.Shared.ScriptableObjectsDefinitions;
using QuarkAcademyJam1Team1.Scripts.Shared;
using QuarkAcademyJam1Team1.Scripts.TimeScripts;
using QuarkAcademyJam1Team1.Scripts.Utils;
using UnityEngine;
using QuarkAcademyJam1Team1.Scripts.Enemies.Shared;

namespace QuarkAcademyJam1Team1.Scripts.Enemies.Jackolanterns
{
    public class SpawnJackolanterns : MonoBehaviour
    {
        [SerializeField]
        private JackolanternDataScriptableObject jackolanternData;
        [SerializeField]
        private Transform target;
        [SerializeField]
        private SpriteRenderer floorSpriteRenderer;
        [SerializeField]
        private SpriteRenderer ceilingSpriteRenderer;
        private ResettableTimer spawnTimer;
        private Vector3 newPosition;

        private void SpawnJackolantern(GameObject obstacle)
        {
            newPosition.x = CameraUtils.OrthographicBounds.max.x + obstacle.GetComponent<SpriteRenderer>().bounds.size.x;
            obstacle.GetComponent<Rigidbody2D>().gravityScale = Constants.Enemies.Jackolanterns.DefaultGravityScale;
            newPosition.y = CameraUtils.OrthographicBounds.min.y + obstacle.GetComponent<SpriteRenderer>().bounds.size.y;
            newPosition.y += floorSpriteRenderer.bounds.size.y;
            obstacle.GetComponent<SpriteRenderer>().flipY = false;
            obstacle.transform.position = newPosition;
            obstacle.SetActive(true);
        }

        private void Start()
        {
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
