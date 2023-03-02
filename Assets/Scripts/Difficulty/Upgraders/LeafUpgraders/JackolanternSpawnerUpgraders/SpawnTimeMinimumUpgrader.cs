using LimboOfCeres.Scripts.Difficulty.Upgraders.CompositeCore;
using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using LimboOfCeres.Scripts.Shared;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders.LeafUpgraders.JackolanternSpawnerUpgraders
{
    public class SpawnTimeMinimumUpgrader : LeafUpgrader
    {
        [SerializeField]
        private JackolanternSpawnerScriptable spawnerData;
        private const float LevelUpFactor = 0.9f;

        protected override void OnUpgradeHook()
        {
            spawnerData.SpawnTimeMinimum.LimitedValue *= LevelUpFactor;
        }

        public override bool IsAtLimit => Mathf.Approximately(
            Constants.Spawners.Jackolanterns.SpawnTimeMinimum.Minimum, spawnerData.SpawnTimeMinimum.LimitedValue);
    }
}
