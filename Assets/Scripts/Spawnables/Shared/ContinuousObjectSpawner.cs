using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using LimboOfCeres.Scripts.TimeScripts;
using System.Collections.Generic;
using UnityEngine;

namespace LimboOfCeres.Scripts.Spawnables.Shared
{
    public class ContinuousObjectSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject prefabToSpawn;
        [SerializeField]
        private SpawningDataScriptable spawningData;

        private List<GameObject> pool;
        private ResettableTimer spawnTimer;
        protected GameObject nextToBeSpawn;
        protected GameObject newlyCreatedSpwanable;

        protected virtual void Start()
        {
            pool = new List<GameObject>();
            spawnTimer = new ResettableTimer(time: Random.Range(spawningData.MinimumRespawnTime, spawningData.MaximumRespawnTime));
            nextToBeSpawn = null;
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
            spawnTimer.Reset(time: Random.Range(spawningData.MinimumRespawnTime, spawningData.MaximumRespawnTime));
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

        protected virtual void InitializeNewSpawnable() { }

        protected virtual void RePositionSpawnable() { }
    }
}
