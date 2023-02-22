using LimboOfCeres.Scripts.Difficulty.Upgraders.CompositeCore;
using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders.LeafUpgraders
{
    public class AimRateMaximumUpgrader : LeafUpgrader
    {
        [SerializeField] private JackolanternScriptable _jackolanternData;

        public override bool IsAtLimit => Mathf.Approximately(
            _jackolanternData.AimRateMaximum,
            Constants.Enemies.Jackolanterns.AimRateMaximum.Minimum);

        protected override void OnUpgradeHook()
        {
            _jackolanternData.AimRateMaximum *= Constants.Difficulty.DefaultInverseLevelUpFactor;
        }
    }
}
