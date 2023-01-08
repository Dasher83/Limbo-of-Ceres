namespace LimboOfCeres.Scripts.Shared
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
            public const int MaxLives = 999;
            public const float RecoveryTime = 3f;

            public static class SafetyBubble
            {
                public const float TravelDistance = 3.8f;
            }
        }

        public static class FloorAndCeiling
        {
            public const float OffsetWidth = 5f;
            public const float HeightProportion = 0.1f;
            public const float CollidersExtraWidth = 5f;
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
                public const float DiplomaticThreshold = 3.8f;
                public const int AmmoRequestsMinimum = 4;
                public const int AmmoRequestsMaximum = 8;
                public const float AimRateMinimum = 0.25f;
                public const float AimRateMaximum = 0.375f;
                public const float FireRateMinimum = 0.25f;
                public const float FireRateMaximum = 0.375f;
                public const float FloorSpeedBoost = 0.75f;

                public static class Pumpkin
                {
                    public const float GravityScaleMinimum = -0.30f;
                    public const float GravityScaleMaximum = 0.30f;
                }
            }
        }

        public static class Projectiles
        {
            public static class Bullet
            {
                public static class CurvedProbability
                {
                    public const float Minimum = 0.38f;
                    public const float Maximum = 0.69f;
                }
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

        public static class Difficulty
        {
            public static class MetersUntilLevelUp
            {
                public const float Minimum = 10f;
                public const float Maximum = 100f;
            }

            public const float LevelUpFactor = 1.1f;
        }
    }
}

