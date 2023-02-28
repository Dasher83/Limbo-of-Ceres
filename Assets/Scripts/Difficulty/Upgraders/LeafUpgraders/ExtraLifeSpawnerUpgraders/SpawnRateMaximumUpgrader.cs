using LimboOfCeres.Scripts.Difficulty.Upgraders.CompositeCore;
using LimboOfCeres.Scripts.Shared;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders.LeafUpgraders.ExtraLifeSpawner
{
    public class SpawnRateMaximumUpgrader : LeafUpgrader
    {
        [SerializeField] private ExtraLifeScriptable _extraLifeData;

        protected override void OnUpgradeHook()
        {
            _extraLifeData.SpawnRateMaximum.LimitedValue *= Constants.Difficulty.DefaultLevelUpFactor;
        }

        public override bool IsAtLimit => Mathf.Approximately(
            _extraLifeData.SpawnRateMaximum.LimitedValue,
            _extraLifeData.SpawnRateMaximum.Maximum);
    }
}
