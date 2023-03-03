using LimboOfCeres.Scripts.Difficulty.Upgraders.CompositeCore;
using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using LimboOfCeres.Scripts.Shared;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders.LeafUpgraders.JackolanternSpawner
{
    public class SpawnTimeMinimumUpgrader : LeafUpgrader
    {
        [SerializeField] private JackolanternSpawnerScriptable _spawnerData;

        protected override void OnUpgradeHook()
        {
            _spawnerData.SpawnRateMinimum.LimitedValue *= Constants.Difficulty.DefaultInverseLevelUpFactor;
        }

        public override bool IsAtLimit => Mathf.Approximately(
            _spawnerData.SpawnRateMinimum.Minimum,
            _spawnerData.SpawnRateMinimum.LimitedValue);
    }
}
