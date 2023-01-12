using LimboOfCeres.Scripts.Difficulty.Upgraders;
using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Shared.Enums;
using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using System.Collections.Generic;
using UnityEngine;


namespace LimboOfCeres
{
    public class DifficultyRegulator : MonoBehaviour
    {
        [SerializeField]
        private PlayerData playerData;
        [SerializeField]
        private GameObject upgradersGameObject;
        private List<Upgrader> upgraders;
        private float metersUntilNextLevelUp;
        private int upgradersIndex;

        private bool IsAtLimit => upgraders.Count == 0 && !shownLimit;
        private bool shownLimit = false; // delete this when it outlives it debbuging usefulness

        private void Start()
        {
            upgraders = new List<Upgrader>();
            for(int i = 0; i < upgradersGameObject.transform.childCount; i++)
            {
                upgraders.Add(upgradersGameObject.transform.GetChild(i).gameObject.GetComponent<Upgrader>());
            }
            metersUntilNextLevelUp = MetersUntilLevelUp;
        }

        private void Update()
        {
            if (IsAtLimit)
            {
                shownLimit = true;
                gameObject.SetActive(false);
                return;
            }
            metersUntilNextLevelUp -= playerData.DeltaMeters;
            Debug.Log($"Meters until {metersUntilNextLevelUp}");
            if (metersUntilNextLevelUp < 0)
            {
                LevelUp();
                metersUntilNextLevelUp = MetersUntilLevelUp;
            }
        }

        private float MetersUntilLevelUp => Random.Range(
            Constants.Difficulty.MetersUntilLevelUp.Minimum,
            Constants.Difficulty.MetersUntilLevelUp.Maximum);

        private void LevelUp()
        {
            upgradersIndex = Random.Range(0, upgraders.Count);
            if (upgraders[upgradersIndex].Upgrade() == UpgradeStatus.FAILED &&
                upgraders[upgradersIndex] is ILimited limited && limited.IsAtLimit)
            {
                upgraders.RemoveAt(upgradersIndex);
            }
        }
    }
}
