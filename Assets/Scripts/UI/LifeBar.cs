using QuarkAcademyJam1Team1.Scripts.Shared.ScriptableObjectsDefinitions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


namespace QuarkAcademyJam1Team1.Scripts.UI
{
    public class LifeBar : MonoBehaviour
    {
        [SerializeField] private int lifes;
        [SerializeField] private int numbersOfHearts;

        [SerializeField]
        private PlayerData playerData;
    }
}
