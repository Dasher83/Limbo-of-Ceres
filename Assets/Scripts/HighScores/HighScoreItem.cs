namespace LimboOfCeres.Scripts.HighScores
{
    [System.Serializable]
    public class HighScoreItem
    {
        public string name;
        public int points;

        public HighScoreItem(string name, int points)
        {
            this.name = name;
            this.points = points;
        }
    }
}
