using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Difficulty.Upgraders.CompositeCore;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders.LeafUpgraders.JackolanternUpgraders
{
    public class FireForceMinimumUpgrader : LeafUpgrader
    {
        [SerializeField] private JackolanternScriptable _jackolanternData;

        protected override void OnUpgradeHook()
        {
            _jackolanternData.FireForceMinimum.LimitedValue *= Constants.Difficulty.DefaultLevelUpFactor;
        }

        public override bool IsAtLimit => Mathf.Approximately(
            _jackolanternData.FireForceMinimum.Maximum,
            _jackolanternData.FireForceMinimum.LimitedValue);
    }
}
