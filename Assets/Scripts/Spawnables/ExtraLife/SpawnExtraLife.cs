using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.TimeScripts;
using LimboOfCeres.Scripts.Utils;
using UnityEngine;

namespace LimboOfCeres.Scripts.Spawnables.ExtraLife
{
    public class SpawnExtraLife : MonoBehaviour
    {
        private SpriteRenderer floorSpriteRenderer = null;
        private SpriteRenderer ceilingSpriteRenderer = null;
        private ResettableTimer spawnTimer;
        private GameObject extraLife;
        private SpriteRenderer extraLifeRenderer;

        private Vector3 NewPosition
        {
            get
            {
                Vector3 newPosition = new Vector3();
                newPosition.x = CameraUtils.OrthographicBounds.max.x + extraLifeRenderer.size.x;
                newPosition.y = Random.Range(
                    CameraUtils.OrthographicBounds.min.y + floorSpriteRenderer.size.y + Constants.ExtraLife.VerticalSpawnOffset,
                    CameraUtils.OrthographicBounds.max.y - ceilingSpriteRenderer.size.y - Constants.ExtraLife.VerticalSpawnOffset);
                return newPosition;
            }
        }

        private void Spawn()
        {
            extraLife.transform.position = NewPosition;
            extraLife.SetActive(true);
        }

        private void Start()
        {
            spawnTimer = new ResettableTimer(Random.Range(Constants.ExtraLife.MinimumRespawnTime, Constants.ExtraLife.MaximumRespawnTime));
            extraLife = gameObject.transform.GetChild(0).gameObject;
            extraLifeRenderer = extraLife.GetComponent<SpriteRenderer>();
            floorSpriteRenderer = GameObject.Find(Constants.GameObjects.MainFloor).GetComponent<SpriteRenderer>();
            ceilingSpriteRenderer = GameObject.Find(Constants.GameObjects.MainCeiling).GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            spawnTimer.Countdown(Time.deltaTime);

            if (spawnTimer.OutOfTime && !extraLife.activeSelf)
            {
                Spawn();
                spawnTimer.Reset();
            }
        }

        private void OnDrawGizmosSelected()
        {
            if(floorSpriteRenderer == null || ceilingSpriteRenderer == null)
            {
                return;
            }
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(
                new Vector3(
                    CameraUtils.OrthographicBounds.min.x, 
                    CameraUtils.OrthographicBounds.min.y + floorSpriteRenderer.size.y + Constants.ExtraLife.VerticalSpawnOffset, 0),
                new Vector3(
                    CameraUtils.OrthographicBounds.max.x,
                    CameraUtils.OrthographicBounds.min.y + floorSpriteRenderer.size.y + Constants.ExtraLife.VerticalSpawnOffset, 0));
            Gizmos.DrawLine(
                new Vector3(
                    CameraUtils.OrthographicBounds.min.x,
                    CameraUtils.OrthographicBounds.max.y - ceilingSpriteRenderer.size.y - Constants.ExtraLife.VerticalSpawnOffset, 0),
                new Vector3(
                    CameraUtils.OrthographicBounds.max.x,
                    CameraUtils.OrthographicBounds.max.y - ceilingSpriteRenderer.size.y - Constants.ExtraLife.VerticalSpawnOffset, 0));
        }
    }
}
