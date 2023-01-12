using LimboOfCeres.Scripts.Difficulty.Upgraders.CompositeCore;
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
        private PlayerDataScriptable playerData;
        [SerializeField]
        private GameObject upgradersGameObject;

        private List<UpgraderComposite> upgraders;
        private float metersUntilNextLevelUp;
        private int upgradersIndex;

        private bool IsAtLimit => upgraders.Count == 0;

        private void Start()
        {
            upgraders = new List<UpgraderComposite>();
            for(int i = 0; i < upgradersGameObject.transform.childCount; i++)
            {
                upgraders.Add(upgradersGameObject.transform.GetChild(i).gameObject.GetComponent<UpgraderComposite>());
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
            if (upgraders[upgradersIndex].Upgrade() == UpgradeStatus.FAILED && upgraders[upgradersIndex].IsAtLimit)
            {
                upgraders[upgradersIndex].transform.gameObject.SetActive(false);
                upgraders.RemoveAt(upgradersIndex);
            }
        }

        private void OnDisable()
        {
            Debug.LogError("Game reached maximum difficulty!");
        }
    }
}
