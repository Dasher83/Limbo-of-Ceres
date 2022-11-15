namespace QuarkAcademyJam1Team1.Scripts.Shared
{
    public static class Constants
    {
        public static class Player
        {
            public const float InitialMovementSpeed = 50f;
            public const float DecelerationSpeed = 0.3f;
            public const float GravityScale = 1.2f;
            public const float HorizontalPositionOffsetFactor = 0.2f;
            public const int InitialLives = 3;
            public const int MaxLives = 5;
            public const float RecoveryTime = 3f;

            public static class SafetyBubble
            {
                public const float TravelDistance = 3.8f;
            }
        }

        public static class FloorAndCeiling
        {
            public const float OffsetWidth = 0.001f;
            public const float HeightProportion = 0.1f;
            public const float CollidersExtraWidth = 1f;
        }

        public static class Obstacles
        {
            public const float DefaultGravityScale = 10f;
            public const float CeilingSpawnProbability = 0.6f;
        }

        public static class Enemies
        {
            public static class Jackolanterns
            {
                public const float DefaultGravityScale = 10f;
                public const float CeilingSpawnProbability = 0.6f;
                public const float DiplomaticThreshold = 3f;
                public const int AmmoRequestsMinimum = 1;
                public const int AmmoRequestsMaximum = 3;
                public const float AimRateMinimum = 1;
                public const float AimRateMaximum = 2;
                public const float FireRateMinimum = 1;
                public const float FireRateMaximum = 2;
            }
        }

        public static class Tags
        {
            public const string Obstacle = "Obstacle";
            public const string Player = "Player";
            public const string Enemy = "Enemy";
            public const string Projectile = "Projectile";
            public const string Menu = "Menu";
        }

        public static class HighScores
        {
            public const string FileName = "/highScores.json";
            public const int Seats = 10;
            public const int NameLimitCharacters = 3;
        }

        public static class AudioPlayer 
        {
            public const float InBetweenSongsPauseLength = 0.3f;
        }

        public static class Animations
        {
            public const float HeartAnimTime = 0.22f;
            public const float ShakeAnim = 0.1f;
            public const float VanishAnimTime = 0.02f;
            public const float AppearAnimTime = 0.08f;
        }

        public static class ExtraLife
        {
            public const float HorizontalPositionOffsetFactor = 0.8f;
            public const float MinimumRespawnTime = 20f;
            public const float MaximumRespawnTime = 30f;
            public const float VerticalSpawnOffset = 1.7f;
            public const float MovementSpeed = 3.5f;
        }

        public static class GameObjects
        {
            public const string MainFloor = "MainFloor";
            public const string MainCeiling = "MainCeiling";
            public const string PumpkinBulletsSpawner = "PumpkinBulletsSpawner";
            public const string PauseMenu = "PauseMenu";
        }
    }
}

