using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Difficulty.Upgraders.CompositeCore;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders.LeafUpgraders.JackolanternUpgraders
{
    public class FireForceMinimumUpgrader : LeafUpgrader
    {
        [SerializeField] private JackolanternScriptable jackolanternData;

        protected override void OnUpgradeHook()
        {
            jackolanternData.FireForceMinimum.LimitedValue *= Constants.Difficulty.DefaultLevelUpFactor;
        }

        public override bool IsAtLimit => Mathf.Approximately(
            Constants.Enemies.Jackolanterns.FireForceMinimum.Maximum, jackolanternData.FireForceMinimum.LimitedValue);
    }
}
