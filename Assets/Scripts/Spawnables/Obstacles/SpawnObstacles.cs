using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Spawnables.Shared;
using LimboOfCeres.Scripts.TimeScripts;
using LimboOfCeres.Scripts.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace LimboOfCeres.Scripts.Spawnables.Obstacles
{
    public class SpawnObstacles : ContinuousObjectSpawner
    {
        [SerializeField]
        private SpriteRenderer floorSpriteRenderer;
        [SerializeField]
        private SpriteRenderer ceilingSpriteRenderer;
        [SerializeField]
        private List<Sprite> sprites;
        private Vector3 newPosition;

        protected override void Start()
        {
            base.Start();
            newPosition = Vector3.zero;
        }

        protected override void InitializeNewSpawnable()
        {
            newlyCreatedSpwanable.GetComponent<SpriteRenderer>().sprite = RandomSprite;
        }

        private Sprite RandomSprite => sprites[Random.Range(0, sprites.Count)];

        protected override void PositionSpawnable()
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
