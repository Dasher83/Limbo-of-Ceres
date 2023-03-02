using LimboOfCeres.Scripts.Difficulty.Upgraders.CompositeCore;
using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using LimboOfCeres.Scripts.Shared;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders.LeafUpgraders.JackolanternSpawnerUpgraders
{
    public class SpawnTimeMinimumUpgrader : LeafUpgrader
    {
        [SerializeField] private JackolanternSpawnerScriptable _spawnerData;

        protected override void OnUpgradeHook()
        {
            _spawnerData.SpawnTimeMinimum.LimitedValue *= Constants.Difficulty.DefaultInverseLevelUpFactor;
        }

        public override bool IsAtLimit => Mathf.Approximately(
            _spawnerData.SpawnTimeMinimum.Minimum,
            _spawnerData.SpawnTimeMinimum.LimitedValue);
    }
}
