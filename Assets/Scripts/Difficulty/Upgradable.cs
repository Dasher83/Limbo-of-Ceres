using LimboOfCeres.Scripts.Shared.Interfaces;
using UnityEngine;

namespace LimboOfCeres.Scripts.Difficulty
{
    public abstract class Upgradable : MonoBehaviour, IUpgradable
    {
        public abstract void Upgrade();
    }
}
