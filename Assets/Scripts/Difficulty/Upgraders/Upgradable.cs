using LimboOfCeres.Scripts.Shared.Interfaces;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders
{
    public abstract class Upgradable : MonoBehaviour, IUpgradable
    {
        public abstract bool Upgrade();
    }
}
