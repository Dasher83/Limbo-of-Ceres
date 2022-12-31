using System.Collections.Generic;
using UnityEngine;

namespace LimboOfCeres.Scripts.Spawnables.Shared
{
    public class OnDemandObjectSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject prefabToSpawn;

        private List<GameObject> pool;
        private Vector3 spawnPosition;
        protected GameObject nextToBeSpawn;
        protected GameObject newlyCreatedSpwanable;

        protected virtual void Start()
        {
            pool = new List<GameObject>();
            nextToBeSpawn = null;
            newlyCreatedSpwanable = null;
        }

        public GameObject RequestObject(Vector3 spawnPosition)
        {
            this.spawnPosition = spawnPosition;
            Spawn();
            return nextToBeSpawn;
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

        protected virtual void RePositionSpawnable()
        {
            nextToBeSpawn.transform.position = spawnPosition;                
        }
    }
}
