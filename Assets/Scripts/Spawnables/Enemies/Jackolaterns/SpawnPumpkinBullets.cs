using System.Collections.Generic;
using UnityEngine;

namespace LimboOfCeres.Scripts.Spawnables.Enemies.Jackolanterns
{
    public class SpawnPumpkinBullets : MonoBehaviour
    {
        [SerializeField]
        private GameObject pumpkinBulletPrefab;
        private List<GameObject> pumpkinBullets;
        private GameObject newSpawn;

        private void Awake()
        {
            pumpkinBullets = new List<GameObject>();
            for(int i = 0; i < gameObject.transform.childCount; i++)
            {
                pumpkinBullets.Add(gameObject.transform.GetChild(i).gameObject);
            }    
        }

        public GameObject Spawn(Vector3 spawnPosition)
        {
            foreach(GameObject pumpkinBullet in pumpkinBullets)
            {
                if (pumpkinBullet.activeSelf)
                {
                    continue;
                }
                pumpkinBullet.transform.position = spawnPosition;
                pumpkinBullet.SetActive(true);
                return pumpkinBullet;
            }
            newSpawn = Instantiate(pumpkinBulletPrefab, spawnPosition, Quaternion.identity);
            newSpawn.transform.parent = gameObject.transform;
            pumpkinBullets.Add(newSpawn);
            return newSpawn;
        }
    }
}
