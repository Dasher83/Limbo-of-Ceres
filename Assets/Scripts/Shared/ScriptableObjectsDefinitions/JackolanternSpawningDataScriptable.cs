using LimboOfCeres.Scripts.Shared.Structs;
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

            this.spawnTimeMinimumRange = new Range<float>(
                minimum: Constants.Spawners.Jackolanterns.SpawnTimeMinimum.Minimum,
                maximum: Constants.Spawners.Jackolanterns.SpawnTimeMinimum.Maximum);

            this.spawnTimeMaximumRange = new Range<float>(
                minimum: Constants.Spawners.Jackolanterns.SpawnTimeMaximum.Minimum,
                maximum: Constants.Spawners.Jackolanterns.SpawnTimeMaximum.Maximum);
        }
    }
}
