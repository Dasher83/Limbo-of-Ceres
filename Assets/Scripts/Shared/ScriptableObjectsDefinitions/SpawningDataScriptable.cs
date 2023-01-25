using LimboOfCeres.Scripts.Shared.Interfaces;
using LimboOfCeres.Scripts.Shared.Structs;
using UnityEngine;


namespace LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions
{
    public abstract class SpawningDataScriptable : ScriptableObject, IInitializable
    {
        [SerializeField]
        protected float spawnTimeMinimum;
        [SerializeField]
        protected float spawnTimeMaximum;

        protected Range<float> spawnTimeMinimumRange;
        protected Range<float> spawnTimeMaximumRange;

        public abstract void Initialize();

        public float SpawnTimeMinimum
        {
            get
            {
                return spawnTimeMinimum;
            }

            set
            {
                if (this.spawnTimeMinimumRange.Maximum.CompareTo(value) < 0)
                {
                    spawnTimeMinimum = this.spawnTimeMinimumRange.Maximum;
                    return;
                }

                if (this.spawnTimeMinimumRange.Minimum.CompareTo(value) > 0)
                {
                    spawnTimeMinimum = this.spawnTimeMinimumRange.Minimum;
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
                if (this.spawnTimeMaximumRange.Maximum.CompareTo(value) < 0)
                {
                    spawnTimeMaximum = this.spawnTimeMaximumRange.Maximum;
                    return;
                }

                if (this.spawnTimeMaximumRange.Minimum.CompareTo(value) > 0)
                {
                    spawnTimeMaximum = this.spawnTimeMaximumRange.Minimum;
                    return;
                }

                spawnTimeMaximum = value;
            }
        }
    }
}
