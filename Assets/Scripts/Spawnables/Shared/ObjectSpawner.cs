using System.Collections.Generic;
using UnityEngine;

namespace LimboOfCeres.Scripts.Spawnables.Shared
{
    public abstract class ObjectSpawner : MonoBehaviour
    {
        [SerializeField]
        protected GameObject prefabToSpawn;
        protected List<GameObject> pool;
        protected GameObject nextToBeSpawn;
        protected GameObject newlyCreatedSpwanable;

        protected virtual void Start()
        {
            pool = new List<GameObject>();
            nextToBeSpawn = null;
            newlyCreatedSpwanable = null;
        }

        protected void Spawn()
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

            PositionSpawnable();
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

        protected virtual void PositionSpawnable() { }
    }
}
