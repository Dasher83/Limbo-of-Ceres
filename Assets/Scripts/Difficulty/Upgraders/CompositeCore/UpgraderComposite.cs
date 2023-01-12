using LimboOfCeres.Scripts.Shared.Enums;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders.CompositeCore
{
    public sealed class UpgraderComposite : Upgrader
    {
        private List<Upgrader> children;
        private List<int> shuffledIndexes;

        protected override bool IsComposite => true;

        public override bool IsAtLimit => children.All(child => child.IsAtLimit);

        public override UpgradeStatus Upgrade()
        {
            if (IsAtLimit) {
                gameObject.SetActive(false);
                return UpgradeStatus.FAILED;
            }

            shuffledIndexes = Enumerable.Range(0, children.Count).OrderBy(_ => Random.value).ToList<int>();

            foreach (int index in shuffledIndexes)
            {
                if (children[index].Upgrade() == UpgradeStatus.SUCCESSFUL)
                {
                    return UpgradeStatus.SUCCESSFUL;
                }
            }

            return UpgradeStatus.FAILED;
        }

        protected override void Start()
        {
            base.Start();
            children = new List<Upgrader>();
            for(int i = 0; i < transform.childCount; i++)
            {
                children.Add(transform.GetChild(i).GetComponent<Upgrader>());
            }
        }
    }
}
