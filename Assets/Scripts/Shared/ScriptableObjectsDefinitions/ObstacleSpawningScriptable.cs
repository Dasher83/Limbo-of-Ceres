using LimboOfCeres.Scripts.Utils;
using UnityEngine;


namespace LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions
{
    [CreateAssetMenu(fileName = "ObstacleSpawnerData", menuName = "ScriptableObjects/ObstacleSpawnerScriptable", order = 5)]
    public class ObstacleSpawningScriptable : SpawnerScriptable
    {
        public override void Initialize()
        {
            this.SpawnTimeMinimum = new LimitedNumericProperty<float>(
                initialValue: Constants.Spawners.Obstacles.SpawnTimeMinimum.Maximum,
                minimum: Constants.Spawners.Obstacles.SpawnTimeMinimum.Minimum,
                maximum: Constants.Spawners.Obstacles.SpawnTimeMinimum.Maximum);

            this.SpawnTimeMaximum = new LimitedNumericProperty<float>(
                initialValue: Constants.Spawners.Obstacles.SpawnTimeMaximum.Maximum,
                minimum: Constants.Spawners.Obstacles.SpawnTimeMaximum.Minimum,
                maximum: Constants.Spawners.Obstacles.SpawnTimeMaximum.Maximum);
        }
    }
}
