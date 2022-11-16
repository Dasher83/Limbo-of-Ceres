using QuarkAcademyJam1Team1.Scripts.HighScores;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

namespace QuarkAcademyJam1Team1.Scripts.UI
{
    public class HighScoreTable : MonoBehaviour
    {
        [SerializeField] private List<GameObject> seats;

        public void Setup()
        {
            HighScoreItem[] highScores= HighScoresReadWriter.Instance.HighScores;
            Array.Reverse(highScores);
            for (int i = 0; i < highScores.Length; i++)
            {
                seats[i].SetActive(true);
                seats[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = highScores[i].name;
                seats[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = highScores[i].points.ToString();
            }
        }
    }
}
