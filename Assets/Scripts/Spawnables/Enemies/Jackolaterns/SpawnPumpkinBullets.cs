using System.Collections.Generic;
using UnityEngine;

namespace LimboOfCeres.Scripts.Spawnables.Enemies.Jackolanterns
{
    public class SpawnPumpkinBullets : MonoBehaviour
    {
        [SerializeField]
        private GameObject pumpkinBulletPrefab;
        private List<GameObject> pool;
        private GameObject newSpawn;

        private void Awake()
        {
            pool = new List<GameObject>();
        }

        public GameObject Spawn(Vector3 spawnPosition)
        {
            newSpawn = GetInactivePumkinBullet();
            if(newSpawn != null)
            {
                newSpawn.transform.position = spawnPosition;
                newSpawn.SetActive(true);
            }
            else
            {
                newSpawn = Instantiate(pumpkinBulletPrefab, spawnPosition, Quaternion.identity);
                newSpawn.transform.parent = gameObject.transform;
                pool.Add(newSpawn);
            }

            return newSpawn;
        }

        private GameObject GetInactivePumkinBullet()
        {
            foreach (GameObject pumpkinBullet in pool)
            {
                if (!pumpkinBullet.activeSelf)
                {
                    return pumpkinBullet;
                }
            }
            return null;
        }
    }
}
