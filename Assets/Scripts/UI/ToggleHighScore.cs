using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LimboOfCeres.Scripts.UI
{
    public class ToggleHighScore : MonoBehaviour
    {
        [SerializeField] private HighScoreTable highScoreTable;
        [SerializeField] private GameObject verticalBoundaries;
        
        public void Toggle()
        {
            verticalBoundaries.SetActive(!verticalBoundaries.activeSelf);
            gameObject.SetActive(!gameObject.activeSelf);
            highScoreTable.gameObject.SetActive(!highScoreTable.gameObject.activeSelf);
            if (highScoreTable.gameObject.activeSelf)
            {
                highScoreTable.Setup();
            }
            
        }
    }
}
