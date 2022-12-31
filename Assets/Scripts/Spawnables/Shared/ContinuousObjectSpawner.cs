using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using LimboOfCeres.Scripts.TimeScripts;
using UnityEngine;

namespace LimboOfCeres.Scripts.Spawnables.Shared
{
    public class ContinuousObjectSpawner : ObjectSpawner
    {
        [SerializeField]
        private SpawningDataScriptable spawningData;
        private ResettableTimer spawnTimer;

        protected override void Start()
        {
            base.Start();
            spawnTimer = new ResettableTimer(time: Random.Range(spawningData.MinimumRespawnTime, spawningData.MaximumRespawnTime));
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
            spawnTimer.Reset(time: Random.Range(spawningData.MinimumRespawnTime, spawningData.MaximumRespawnTime));
        }

        protected override void InitializeNewSpawnable() { }

        protected override void PositionSpawnable() { }
    }
}
