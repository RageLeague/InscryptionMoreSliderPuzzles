using System;
using System.Collections.Generic;
using System.Text;
using GBC;
using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;
using DiskCardGame;
using MoreSliderPuzzles.Util;

namespace MoreSliderPuzzles.Patches
{
    [HarmonyPatch(typeof(SliderPuzzleContainer), "OnPlayerInput")]
    public class SliderPuzzleContainer_OnPlayerInput
    {
        public static List<SliderPuzzleInfo> loadedPuzzles;
        public static string overrideSceneId = "GBC_Temple_Nature";
        public static int overrideSaveId = 34565083;

        public static void Prefix(SliderPuzzleContainer __instance, out SliderPuzzleInfo __state)
        {
            string sceneName = SceneManager.GetActiveScene().name;
            int saveId = __instance.saveState.saveId;
            __state = __instance.puzzleInfo;
            if (sceneName == overrideSceneId && saveId == overrideSaveId)
            {
                if (loadedPuzzles == null)
                {
                    loadedPuzzles = SliderPuzzleLoader.LoadAllPuzzles();
                    if (loadedPuzzles.Count > 0)
                    {
                        ContainersMod.AddOpenTimes(overrideSceneId, overrideSaveId, loadedPuzzles.Count);
                    }
                }
                if (loadedPuzzles.Count > 0)
                {
                    __instance.puzzleInfo = loadedPuzzles[__instance.saveState.State.intVal % loadedPuzzles.Count];
                }
                return;
            }
        }

        public static void Postfix(SliderPuzzleContainer __instance, SliderPuzzleInfo __state)
		{
            __instance.puzzleInfo = __state;
            Plugin.Log.LogDebug($"Source object: {__instance.gameObject}");
            // IDs are:
            // Tech Right: GBC_Temple_Tech, 34565082
            // Tech Left: GBC_Temple_Tech, 34565083
            // Shack Box: GBC_Temple_Nature, 34565083
            Plugin.Log.LogDebug($"Save ID: {__instance.saveState.saveId}");
        }
	}
}
