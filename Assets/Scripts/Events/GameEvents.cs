using UnityEngine;

namespace Events
{
    public class GameEvents
    {
        public delegate void GameState();

        /// <summary>
        /// Calls functions for when the level is finished.
        /// </summary>
        public static GameState LevelFinished;
    }
}
