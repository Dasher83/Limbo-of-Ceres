using LimboOfCeres.Scripts.Difficulty.Upgraders.CompositeCore;
using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders.LeafUpgraders
{
    public class FireRateMinimumUpgrader : LeafUpgrader
    {
        [SerializeField]
        private JackolanternScriptable _jackolanternData;

        public override bool IsAtLimit => Mathf.Approximately(
            _jackolanternData.FireRateMinimum.LimitedValue,
            Constants.Enemies.Jackolanterns.FireRateMinimum.Minimum);

        protected override void OnUpgradeHook()
        {
            _jackolanternData.FireRateMinimum.LimitedValue *= Constants.Difficulty.DefaultInverseLevelUpFactor;
        }
    }
}
