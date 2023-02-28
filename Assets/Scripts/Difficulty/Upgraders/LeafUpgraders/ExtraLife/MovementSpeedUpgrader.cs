using LimboOfCeres.Scripts.Difficulty.Upgraders.CompositeCore;
using LimboOfCeres.Scripts.Shared;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders.LeafUpgraders.ExtraLife
{
    public class MovementSpeedUpgrader : LeafUpgrader
    {
        [SerializeField] private ExtraLifeScriptable _extraLifeData;

        public override bool IsAtLimit => Mathf.Approximately(
            _extraLifeData.MovementSpeed.LimitedValue,
            _extraLifeData.MovementSpeed.Maximum);

        protected override void OnUpgradeHook()
        {
            _extraLifeData.MovementSpeed.LimitedValue *= Constants.Difficulty.DefaultLevelUpFactor;
        }
    }
}
