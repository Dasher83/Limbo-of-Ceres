using LimboOfCeres.Scripts.Difficulty.Upgraders.CompositeCore;
using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using LimboOfCeres.Scripts.Shared;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders.LeafUpgraders.JackolanternUpgraders
{
    public class AmmoRequestsMinimumUpgrader : LeafUpgrader
    {
        [SerializeField] private JackolanternScriptable _jackolanternData;

        protected override void OnUpgradeHook()
        {
            _jackolanternData.AmmoRequestsMinimum.LimitedValue += 1;
        }

        public override bool IsAtLimit => Mathf.Approximately(
            Constants.Enemies.Jackolanterns.AmmoRequestsMinimum.Maximum, _jackolanternData.AmmoRequestsMinimum.LimitedValue);
    }
}
