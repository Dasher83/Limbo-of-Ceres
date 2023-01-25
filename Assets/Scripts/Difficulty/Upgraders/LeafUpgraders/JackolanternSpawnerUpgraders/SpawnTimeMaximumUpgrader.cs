using LimboOfCeres.Scripts.Difficulty.Upgraders.CompositeCore;
using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using LimboOfCeres.Scripts.Shared;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders.LeafUpgraders.JackolanternSpawnerUpgraders
{
    public class SpawnTimeMaximumUpgrader : LeafUpgrader
    {
        [SerializeField]
        private JackolanternSpawningDataScriptable spawningData;
        private const float LevelUpFactor = 0.9f;

        protected override void OnUpgradeHook()
        {
            spawningData.SpawnTimeMaximum *= LevelUpFactor;
        }

        public override bool IsAtLimit => Mathf.Approximately(
            Constants.Spawners.Jackolanterns.SpawnTimeMaximum.Minimum, spawningData.SpawnTimeMaximum);
    }
}
