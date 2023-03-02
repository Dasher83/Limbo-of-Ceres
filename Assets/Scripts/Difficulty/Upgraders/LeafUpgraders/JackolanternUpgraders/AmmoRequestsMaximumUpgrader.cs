using LimboOfCeres.Scripts.Difficulty.Upgraders.CompositeCore;
using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using LimboOfCeres.Scripts.Shared;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders.LeafUpgraders.JackolanternUpgraders
{
    public class AmmoRequestsMaximumUpgrader : LeafUpgrader
    {
        [SerializeField] private JackolanternScriptable _jackolanternData;

        protected override void OnUpgradeHook()
        {
            _jackolanternData.AmmoRequestsMaximum.LimitedValue += 1;
        }

        public override bool IsAtLimit => Mathf.Approximately(
            Constants.Enemies.Jackolanterns.AmmoRequestsMaximum.Maximum, _jackolanternData.AmmoRequestsMaximum.LimitedValue);
    }
}
