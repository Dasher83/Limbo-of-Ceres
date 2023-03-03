using LimboOfCeres.Scripts.Difficulty.Upgraders.CompositeCore;
using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders.LeafUpgraders.Bullets
{
    public class BouncinessUpgrader : LeafUpgrader
    {
        [SerializeField] private BulletsScriptable _bulletsData;

        protected override void OnUpgradeHook()
        {
            _bulletsData.Bounciness.LimitedValue *= 1.8f;
        }

        public override bool IsAtLimit => Mathf.Approximately(
            _bulletsData.Bounciness.Maximum,
            _bulletsData.Bounciness.LimitedValue);
    }
}
