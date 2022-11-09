using System.Collections.Generic;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.HighScores
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
