using UnityEngine;


namespace LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions
{
    [CreateAssetMenu(fileName = "JackolanternSpawningData", menuName = "ScriptableObjects/JackolanternSpawningData", order = 4)]
    public class JackolanternSpawningDataScriptable : SpawningDataScriptable
    {
        public override void Initialize()
        {
            this.spawnTimeMinimum = Constants.Spawners.Jackolanterns.SpawnTimeMinimum.Maximum;
            this.spawnTimeMaximum = Constants.Spawners.Jackolanterns.SpawnTimeMaximum.Maximum;
            this.spawnTimeMinimumMinimum = Constants.Spawners.Jackolanterns.SpawnTimeMinimum.Minimum;
            this.spawnTimeMinimumMaximum = Constants.Spawners.Jackolanterns.SpawnTimeMinimum.Maximum;
            this.spawnTimeMaximumMinimum = Constants.Spawners.Jackolanterns.SpawnTimeMaximum.Minimum;
            this.spawnTimeMaximumMaximum = Constants.Spawners.Jackolanterns.SpawnTimeMaximum.Maximum;
        }
    }
}
