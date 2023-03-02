using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using LimboOfCeres.Scripts.TimeScripts;
using UnityEngine;


namespace LimboOfCeres.Scripts.Spawnables.Shared
{
    public class ContinuousObjectSpawner : ObjectSpawner
    {
        [SerializeField]
        private SpawnerScriptable spawnerData;
        private ResettableTimer spawnTimer;

        protected override void Start()
        {
            base.Start();
            spawnTimer = new ResettableTimer(time: spawnerData.SpawnTime);
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
            spawnTimer.Reset(time: spawnerData.SpawnTime);
        }
    }
}
