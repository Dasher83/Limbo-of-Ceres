using LimboOfCeres.Scripts.Shared.Enums;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders.CompositeCore
{
    public sealed class CompositeUpgrader : Upgrader
    {
        private List<Upgrader> children;
        private List<int> shuffledIndexes;

        public override bool IsAtLimit => children.All(child => child.IsAtLimit);

        protected override void OnUpgradeHook()
        {
            shuffledIndexes = Enumerable.Range(0, children.Count).OrderBy(_ => Random.value).ToList<int>();

            foreach (int index in shuffledIndexes)
            {
                if (children[index].Upgrade() == UpgradeStatus.SUCCESSFUL)
                {
                    return;
                }
            }
        }

        private void Start()
        {
            children = new List<Upgrader>();
            for(int i = 0; i < transform.childCount; i++)
            {
                children.Add(transform.GetChild(i).GetComponent<Upgrader>());
            }
        }
    }
}
