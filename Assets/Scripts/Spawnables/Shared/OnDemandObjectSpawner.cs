using UnityEngine;

namespace LimboOfCeres.Scripts.Spawnables.Shared
{
    public class OnDemandObjectSpawner : ObjectSpawner
    {
        private Vector3 spawnPosition;

        protected override void Start()
        {
            base.Start();
        }

        public GameObject RequestObject(Vector3 spawnPosition)
        {
            this.spawnPosition = spawnPosition;
            Spawn();
            return nextToBeSpawn;
        }

        protected override void PositionSpawnable()
        {
            nextToBeSpawn.transform.position = spawnPosition;                
        }
    }
}
