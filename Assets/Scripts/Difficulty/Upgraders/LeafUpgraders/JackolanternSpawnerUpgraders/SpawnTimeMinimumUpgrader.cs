using LimboOfCeres.Scripts.Difficulty.Upgraders.CompositeCore;
using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using LimboOfCeres.Scripts.Shared;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders.LeafUpgraders.JackolanternSpawnerUpgraders
{
    public class SpawnTimeMinimumUpgrader : LeafUpgrader
    {
        [SerializeField]
        private JackolanternSpawningDataScriptable spawningData;

        protected override void UpgradeHook()
        {
            spawningData.SpawnTimeMinimum *= this.LevelUpFactor;
        }

        public override bool IsAtLimit => Mathf.Approximately(
            Constants.Spawners.Jackolanterns.SpawnTimeMinimum.Minimum, spawningData.SpawnTimeMinimum);

        protected override void Start()
        {
            base.Start();
            this.LevelUpFactor = 0.9f;
        }
    }
}
