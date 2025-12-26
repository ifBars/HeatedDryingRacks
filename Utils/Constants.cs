namespace HeatedDryingRacks.Utils
{
    public static class Constants
    {
        /// <summary>
        /// Mod information
        /// </summary>
        public const string MOD_NAME = "HeatedDryingRacks";
        public const string MOD_VERSION = "1.0.0";
        public const string MOD_AUTHOR = "Bars";
        public const string MOD_DESCRIPTION = "Mod description...";

        /// <summary>
        /// MelonPreferences configuration
        /// </summary>
        public const string PREFERENCES_CATEGORY = MOD_NAME;

        public static class Keys 
        {
            public const string ENABLE_HEAT = "EnableHeatEffect";
            public const string ENABLE_COLD = "EnableColdEffect";
            public const string HEAT_BONUS = "HeatBonusMinutes";
            public const string COLD_PENALTY = "ColdPenaltyMinutes";
            public const string HEAT_THRESHOLD = "HeatThresholdTemp";
            public const string COLD_THRESHOLD = "ColdThresholdTemp";
        }

        /// <summary>
        /// Default preference values
        /// </summary>
        public static class Defaults
        {
            public const bool ENABLE_HEAT_DEFAULT = true;
            public const bool ENABLE_COLD_DEFAULT = true;
            public const int HEAT_BONUS_DEFAULT = 1;
            public const int COLD_PENALTY_DEFAULT = 1;
            public const float HEAT_THRESHOLD_DEFAULT = 25f;
            public const float COLD_THRESHOLD_DEFAULT = 10f;
        }

        /// <summary>
        /// Preference value constraints
        /// </summary>
        public static class Constraints
        {
            public const float MIN_CONSTRAINT = 0f;
            public const float MAX_CONSTRAINT = 100f;
        }

        /// <summary>
        /// Game-related constants
        /// </summary>
        public static class Game
        {
            public const string GAME_STUDIO = "TVGS";
            public const string GAME_NAME = "Schedule I";
        }

    }
}
