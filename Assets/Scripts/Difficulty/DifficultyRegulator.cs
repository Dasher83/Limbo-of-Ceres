using LimboOfCeres.Scripts.Difficulty.Upgraders.CompositeCore;
using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Shared.Enums;
using LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions;
using System.Collections.Generic;
using UnityEngine;


namespace LimboOfCeres.Scripts.Difficulty.Upgraders
{
    public class DifficultyRegulator : MonoBehaviour
    {
        [SerializeField]
        private PlayerScriptable playerData;
        [SerializeField]
        private GameObject upgradersGameObject;

        private List<Upgrader> upgraders;
        private float metersUntilNextLevelUp;
        private int upgradersIndex;

        private bool IsAtLimit => upgraders.Count == 0;

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
                upgradersGameObject.SetActive(false);
                gameObject.SetActive(false);
                return;
            }
            metersUntilNextLevelUp -= playerData.DeltaMeters;
            if (metersUntilNextLevelUp < 0)
            {
                LevelUp();
                metersUntilNextLevelUp = MetersUntilLevelUp;
            }
        }

        private float MetersUntilLevelUp => Random.Range(
            Constants.Difficulty.MetersUntilLevelUp.Minimum / 8,
            Constants.Difficulty.MetersUntilLevelUp.Maximum / 8);

        private void LevelUp()
        {
            upgradersIndex = Random.Range(0, upgraders.Count);
            if (upgraders[upgradersIndex].Upgrade() == UpgradeStatus.FAILED && upgraders[upgradersIndex].IsAtLimit)
            {
                upgraders[upgradersIndex].transform.gameObject.SetActive(false);
                upgraders.RemoveAt(upgradersIndex);
            }
        }

        private void OnDisable()
        {
            if(IsAtLimit) Debug.LogError("Game reached maximum difficulty!");
        }
    }
}
