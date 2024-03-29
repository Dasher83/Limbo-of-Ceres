using LimboOfCeres.Scripts.Difficulty.Upgraders.CompositeCore;
using LimboOfCeres.Scripts.Shared;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders.LeafUpgraders.ExtraLifeSpawner
{
    public class SpawnRateMinimumUpgrader : LeafUpgrader
    {
        [SerializeField] private ExtraLifeScriptable _extraLifeData;

        protected override void OnUpgradeHook()
        {
            _extraLifeData.SpawnRateMinimum.LimitedValue *= Constants.Difficulty.DefaultLevelUpFactor;
        }

        public override bool IsAtLimit => Mathf.Approximately(
            _extraLifeData.SpawnRateMinimum.Maximum,
            _extraLifeData.SpawnRateMinimum.LimitedValue);
    }
}
