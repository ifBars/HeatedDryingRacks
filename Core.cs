using HeatedDryingRacks.Utils;
using MelonLoader;

[assembly: MelonInfo(typeof(HeatedDryingRacks.Core), Constants.MOD_NAME, Constants.MOD_VERSION, Constants.MOD_AUTHOR)]
[assembly: MelonGame(Constants.Game.GAME_STUDIO, Constants.Game.GAME_NAME)]

namespace HeatedDryingRacks
{
    public class Core : MelonMod
    {
        public static MelonPreferences_Category PrefsCategory;
        public static MelonPreferences_Entry<bool> EnableHeatEntry;
        public static MelonPreferences_Entry<bool> EnableColdEntry;
        public static MelonPreferences_Entry<int> HeatBonusEntry;
        public static MelonPreferences_Entry<int> ColdPenaltyEntry;
        public static MelonPreferences_Entry<float> HeatThresholdEntry;
        public static MelonPreferences_Entry<float> ColdThresholdEntry;

        public override void OnInitializeMelon()
        {
            PrefsCategory = MelonPreferences.CreateCategory(Constants.PREFERENCES_CATEGORY);
            
            EnableHeatEntry = PrefsCategory.CreateEntry(Constants.Keys.ENABLE_HEAT, Constants.Defaults.ENABLE_HEAT_DEFAULT, "Enable Heat Effect", "If true, heat speeds up drying.");
            EnableColdEntry = PrefsCategory.CreateEntry(Constants.Keys.ENABLE_COLD, Constants.Defaults.ENABLE_COLD_DEFAULT, "Enable Cold Effect", "If true, cold slows/pauses drying.");
            
            HeatBonusEntry = PrefsCategory.CreateEntry(Constants.Keys.HEAT_BONUS, Constants.Defaults.HEAT_BONUS_DEFAULT, "Heat Bonus Minutes", "Extra minutes added per tick when hot.");
            ColdPenaltyEntry = PrefsCategory.CreateEntry(Constants.Keys.COLD_PENALTY, Constants.Defaults.COLD_PENALTY_DEFAULT, "Cold Penalty Minutes", "Minutes removed per tick when cold.");
            
            HeatThresholdEntry = PrefsCategory.CreateEntry(Constants.Keys.HEAT_THRESHOLD, Constants.Defaults.HEAT_THRESHOLD_DEFAULT, "Heat Threshold (°C)", "Temperature above which heat bonus applies.");
            ColdThresholdEntry = PrefsCategory.CreateEntry(Constants.Keys.COLD_THRESHOLD, Constants.Defaults.COLD_THRESHOLD_DEFAULT, "Cold Threshold (°C)", "Temperature below which cold penalty applies.");

            PrefsCategory.SaveToFile(false);
            LoggerInstance.Msg("Heated Drying Racks Initialized w/ Preferences!");
        }
    }
}