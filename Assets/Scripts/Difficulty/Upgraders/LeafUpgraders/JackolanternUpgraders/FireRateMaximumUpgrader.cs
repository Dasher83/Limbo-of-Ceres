using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Difficulty.Upgraders.CompositeCore;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders.LeafUpgraders
{
    public class FireRateMaximumUpgrader : LeafUpgrader
    {
        [SerializeField]
        private JackolanternScriptable _jackolanternData;

        public override bool IsAtLimit => Mathf.Approximately(
            _jackolanternData.FireRateMaximum.LimitedValue,
            Constants.Enemies.Jackolanterns.FireRateMaximum.Minimum);

        protected override void OnUpgradeHook()
        {
            _jackolanternData.FireRateMaximum.LimitedValue *= Constants.Difficulty.DefaultInverseLevelUpFactor;
        }
    }
}
