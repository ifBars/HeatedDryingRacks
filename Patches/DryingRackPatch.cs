#if MONO
using ScheduleOne.ObjectScripts;
using ScheduleOne.Persistence.Datas;
#else
using Il2CppScheduleOne.ObjectScripts;
using Il2CppScheduleOne.Persistence.Datas;
#endif
using HarmonyLib;
using UnityEngine;
using HeatedDryingRacks;

namespace HeatedDryingRacks.Patches
{
    [HarmonyPatch(typeof(DryingRack), "MinPass")]
    public static class DryingRackPatch
    {
        public static void Postfix(DryingRack __instance)
        {
            if (__instance.DryingOperations == null || __instance.DryingOperations.Count == 0) return;

            // Get temperature using GridItem's built-in method
            float temperature = __instance.GetAverageTileTemperature();

            int minutesToAdd = 0;

            // Logic:
            // > HeatThreshold: Speed up (Heat)
            // < ColdThreshold: Slow down/Pause (Cold)
            
            if (Core.PrefsCategory == null) return; // Safety check

            if (Core.EnableHeatEntry.Value && temperature > Core.HeatThresholdEntry.Value)
            {
                // Heat: Add bonus minutes
                minutesToAdd = Core.HeatBonusEntry.Value;
            }
            else if (Core.EnableColdEntry.Value && temperature < Core.ColdThresholdEntry.Value)
            {
                // Cold: Subtract penalty minutes
                minutesToAdd = -Core.ColdPenaltyEntry.Value;
            }

            if (minutesToAdd != 0)
            {
                foreach (DryingOperation op in __instance.DryingOperations)
                {
                    // Check bounds to prevent weirdness, though DryingRack handles Time++ simply.
                    // If we subtract, we just want to make sure we don't go below 0 if it was just started, 
                    // though vanilla just added 1 so it should be fine.
                    
                   // Vanilla just did op.Time++
                   if (minutesToAdd > 0)
                   {
                        // Heat: Bonus progress
                        op.Time += minutesToAdd;
                   }
                   else
                   {
                        // Cold: Revert progress
                        // Ensure we don't go negative if for some reason vanilla didn't run or logic changed
                        // but generally we are undoing the vanilla ++
                        op.Time += minutesToAdd; 
                   }
                   
                   // Ensure it doesn't auto-complete if we just pushed it over 720 in this postfix (vanilla handles the check in the loop we just finished)
                   // But actually, vanilla checks `if (dryingOperation.Time < 720) continue;` inside the loop.
                   // Since we are modifiying it AFTER the check, our extra time won't be processed for completion until Next tick.
                   // That is acceptable behavior.
                }
            }
        }
    }
}
