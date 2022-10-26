namespace Events
{
    public static class GameEvents
    {
        public delegate void GameState();
        public delegate void BallState();
        public delegate void LevelCompleted();

        /// <summary>
        /// Calls functions for when the level is finished.
        /// </summary>
        public static GameState onLevelFinishedEvent;

        public static LevelCompleted onLevelIsCompletedEvent;
        public static BallState onBallPauseEvent;
        public static BallState onBallStartEvent;
    }
}
