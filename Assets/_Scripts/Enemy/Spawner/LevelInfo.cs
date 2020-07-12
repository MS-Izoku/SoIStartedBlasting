using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InfoLevel
{
    public class LevelInfo : MonoBehaviour
    {
        private static float spawners = 4;
        public static float Spawners
        {
            get { return spawners; }
            set { spawners = value; }
        }

        public static bool AdjustSpawners(float amt)
        {
            spawners += amt;
            if (spawners == 0)
                return false;
            else
                return true;
        }

        private static float baseSpawnSpeed = 10f;
        public static float BaseSpawnSpeed
        {
            get { return baseSpawnSpeed; }
            set { baseSpawnSpeed = value; }
        }

        private static float currentLevel = 1f;
        public static float CurrentLevel
        {
            get { return currentLevel; }
            set { currentLevel = value; }
        }

        private static loadLevelTest loader;
        public static loadLevelTest Loader
        {
            get { return loader; }
            set { loader = value; }
        }
    }
}

