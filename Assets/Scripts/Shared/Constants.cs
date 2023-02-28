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

        public static class Spawners
        {
            public static class Jackolanterns
            {
                public static class SpawnTimeMinimum
                {
                    public const float Minimum = 1.2f;
                    public const float Maximum = 1.8f;
                }

                public static class SpawnTimeMaximum
                {
                    public const float Minimum = 2.2f;
                    public const float Maximum = 3.3f;
                }
            }

            public static class Obstacles
            {
                public static class SpawnTimeMinimum
                {
                    public const float Minimum = 1f;
                    public const float Maximum = 1.3f;
                }

                public static class SpawnTimeMaximum
                {
                    public const float Minimum = 1.9f;
                    public const float Maximum = 3.8f;
                }
            }
        }

        public static class Enemies
        {
            public static class Jackolanterns
            {
                public const float DefaultGravityScale = 10f;
                public const float CeilingSpawnProbability = 0.6f;
                public const float DiplomaticThreshold = 3.8f;
                public const float FloorSpeedBoost = 0.75f;
                public static class FireForceMinimum
                {
                    public const float Minimum = 200f;
                    public const float Maximum = 400f;
                }
                public static class FireForceMaximum
                {
                    public const float Minimum = 350f;
                    public const float Maximum = 700f;
                }

                public static class AmmoRequestsMinimum
                {
                    public const int Minimum = 2;
                    public const int Maximum = 4;
                }

                public static class AmmoRequestsMaximum
                {
                    public const int Minimum = 4;
                    public const int Maximum = 8;
                }

                public static class AimRateMinimum
                {
                    public const float Minimum = 0.25f;
                    public const float Maximum = 1.00f;
                }

                public static class AimRateMaximum
                {
                    public const float Minimum = 0.375f;
                    public const float Maximum = 1.5f;
                }

                public static class FireRateMinimum
                {
                    public const float Minimum = 0.25f;
                    public const float Maximum = 1f;
                }

                public static class FireRateMaximum
                {
                    public const float Minimum = 0.375f;
                    public const float Maximum = 1.5f;
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

                public static class Bounciness
                {
                    public const float Minimum = 0.1f;
                    public const float Maximum = 8f;
                }

                public static class GravityScaleMinimum
                {
                    public const float Minimum = -0.1f;
                    public const float Maximum = -0.3f;
                }

                public static class GravityScaleMaximum
                {
                    public const float Minimum = 0.1f;
                    public const float Maximum = 0.30f;
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
            public const float MaximumRespawnTime = 30f;
            public const float VerticalSpawnOffset = 1.7f;
            public const float MovementSpeed = 3.5f;

            public static class SpawnRateMinimum
            {
                public const float Minimum = 10f;
                public const float Maximum = 20f;
            }
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

            public const float DefaultLevelUpFactor = 1.1f;
            public const float DefaultInverseLevelUpFactor = 0.9f;
        }
    }
}

