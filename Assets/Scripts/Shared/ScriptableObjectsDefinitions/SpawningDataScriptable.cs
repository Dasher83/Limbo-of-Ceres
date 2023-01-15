using LimboOfCeres.Scripts.Shared.Interfaces;
using UnityEngine;


namespace LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions
{
    public abstract class SpawningDataScriptable : ScriptableObject, IInitializable
    {
        [SerializeField]
        protected float spawnTimeMinimum;
        [SerializeField]
        protected float spawnTimeMaximum;

        protected float spawnTimeMinimumMinimum;
        protected float spawnTimeMinimumMaximum;
        protected float spawnTimeMaximumMinimum;
        protected float spawnTimeMaximumMaximum;

        public abstract void Initialize();

        public float SpawnTimeMinimum
        {
            get
            {
                return spawnTimeMinimum;
            }

            set
            {
                if (value > this.spawnTimeMinimumMaximum)
                {
                    spawnTimeMinimum = this.spawnTimeMinimumMinimum;
                    return;
                }

                if (value < this.spawnTimeMinimumMinimum)
                {
                    spawnTimeMinimum = this.spawnTimeMinimumMinimum;
                    return;
                }

                spawnTimeMinimum = value;
            }
        }

        public float SpawnTimeMaximum
        {
            get
            {
                return spawnTimeMaximum;
            }

            set
            {
                if (value > this.spawnTimeMaximumMaximum)
                {
                    spawnTimeMaximum = this.spawnTimeMaximumMaximum;
                }

                if (value < this.spawnTimeMaximumMinimum)
                {
                    spawnTimeMaximum = this.spawnTimeMaximumMinimum;
                }

                spawnTimeMaximum = value;
            }
        }
    }
}
