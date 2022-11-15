using QuarkAcademyJam1Team1.Scripts.Shared;
using System.IO;
using System.Linq;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.HighScores
{
    public class HighScoresReadWriter
    {
        private static readonly HighScoresReadWriter instance = new HighScoresReadWriter();
        private HighScoreCollection highScoreCollection = new HighScoreCollection();

        public HighScoreItem[] HighScores
        {
            get
            {
                ReadFile();
                return highScoreCollection.HighScores.ToArray();
            }
        }

        static HighScoresReadWriter() { }
        private HighScoresReadWriter() { }

        public static HighScoresReadWriter Instance
        {
            get
            {
                return instance;
            }
        }


        private static string TargetFilePath 
        {
            get
            {
                return Application.persistentDataPath + Constants.HighScores.FileName;
            }
        }

        private void ReadFile()
        {
            if (File.Exists(TargetFilePath))
            {
                string fileContents = File.ReadAllText(TargetFilePath);
                HighScoreCollection unlimitedHighScores = new HighScoreCollection();
                unlimitedHighScores = JsonUtility.FromJson<HighScoreCollection>(fileContents);
                instance.highScoreCollection.HighScores = unlimitedHighScores.HighScores.Where(item => item.points > 0).OrderByDescending(item => item.points).Take(
                    Constants.HighScores.Seats).OrderBy(item => item.points).ToList();
            }
        }

        private void WriteFile()
        {
            instance.highScoreCollection.HighScores = instance.highScoreCollection.HighScores.OrderByDescending(
                item => item.points).Take(Constants.HighScores.Seats).ToList();
            string jsonString = JsonUtility.ToJson(instance.highScoreCollection);
            File.WriteAllText(TargetFilePath, jsonString);
        }

        public void AddHighScore(HighScoreItem highScore)
        {
            ReadFile();
            if (highScore.points <= 0) return;
            instance.highScoreCollection.HighScores.Add(highScore);
            WriteFile();
            ReadFile();
        }
    }
}
