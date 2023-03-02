using LimboOfCeres.Scripts.Utils;
using UnityEngine;


namespace LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions
{
    [CreateAssetMenu(fileName = "JackolanternSpawnerData", menuName = "ScriptableObjects/JackolanternSpawnerScriptable", order = 4)]
    public class JackolanternSpawnerScriptable : SpawnerScriptable
    {
        public override void Initialize()
        {
            this.SpawnRateMinimum = new LimitedNumericProperty<float>(
                initialValue: Constants.Spawners.Jackolanterns.SpawnTimeMinimum.Maximum,
                minimum: Constants.Spawners.Jackolanterns.SpawnTimeMinimum.Minimum,
                maximum: Constants.Spawners.Jackolanterns.SpawnTimeMinimum.Maximum);

            this.SpawnRateMaximum = new LimitedNumericProperty<float>(
                initialValue: Constants.Spawners.Jackolanterns.SpawnTimeMaximum.Maximum,
                minimum: Constants.Spawners.Jackolanterns.SpawnTimeMaximum.Minimum,
                maximum: Constants.Spawners.Jackolanterns.SpawnTimeMaximum.Maximum);
        }
    }
}
