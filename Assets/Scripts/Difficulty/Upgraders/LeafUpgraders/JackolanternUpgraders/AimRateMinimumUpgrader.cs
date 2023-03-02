using LimboOfCeres.Scripts.Difficulty.Upgraders.CompositeCore;
using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders.LeafUpgraders
{
    public class AimRateMinimumUpgrader : LeafUpgrader
    {
        [SerializeField] private JackolanternScriptable _jackolanternData;

        protected override void OnUpgradeHook()
        {
            _jackolanternData.AimRateMinimum.LimitedValue *= Constants.Difficulty.DefaultInverseLevelUpFactor;
        }

        public override bool IsAtLimit => Mathf.Approximately(
            _jackolanternData.AimRateMinimum.Minimum,
            _jackolanternData.AimRateMinimum.LimitedValue);
    }
}
