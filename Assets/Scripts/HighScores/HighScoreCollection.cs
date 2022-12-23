using System.Collections.Generic;
using UnityEngine;

namespace LimboOfCeres.Scripts.HighScores
{
    [System.Serializable]
    public class HighScoreCollection
    {
        [SerializeField]
        private List<HighScoreItem> highScores;

        public List<HighScoreItem> HighScores { get { return highScores; } set { highScores = value; } }

        public HighScoreCollection()
        {
            highScores = new List<HighScoreItem>();
        }
    }
}
