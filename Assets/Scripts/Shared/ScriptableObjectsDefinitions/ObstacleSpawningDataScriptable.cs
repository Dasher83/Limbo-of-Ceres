using UnityEngine;


namespace LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions
{
    [CreateAssetMenu(fileName = "ObstacleSpawningData", menuName = "ScriptableObjects/ObstacleSpawningData", order = 5)]
    public class ObstacleSpawningDataScriptable : SpawningDataScriptable
    {
        public override void Initialize()
        {
            this.spawnTimeMinimum = Constants.Spawners.Obstacles.SpawnTimeMinimum.Maximum;
            this.spawnTimeMaximum = Constants.Spawners.Obstacles.SpawnTimeMaximum.Maximum;
            this.spawnTimeMinimumMinimum = Constants.Spawners.Obstacles.SpawnTimeMinimum.Minimum;
            this.spawnTimeMinimumMaximum = Constants.Spawners.Obstacles.SpawnTimeMinimum.Maximum;
            this.spawnTimeMaximumMinimum = Constants.Spawners.Obstacles.SpawnTimeMaximum.Minimum;
            this.spawnTimeMaximumMaximum = Constants.Spawners.Obstacles.SpawnTimeMaximum.Maximum;
        }
    }
}
