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
            public const int InitialLifes = 3;
            public const int MaxLifes = 5;
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

        public static class Tags
        {
            public const string Obstacle = "Obstacle";
        }
    }
}

