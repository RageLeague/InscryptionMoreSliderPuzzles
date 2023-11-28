using System;
using System.Collections.Generic;
using System.Text;
using GBC;
using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;
using Pixelplacement;
using MoreSliderPuzzles.Util;

namespace MoreSliderPuzzles.Patches
{
    [HarmonyPatch(typeof(ContainerVolume), "SetOpen")]
    public class ContainerVolume_MultiOpen
    {
        public static bool Prefix(bool open, bool immediate, ContainerVolume __instance)
        {
            if (open == __instance.Open)
            {
                return true;
            }
            if (open)
            {
                string sceneName = SceneManager.GetActiveScene().name;
                int saveId = __instance.saveState.saveId;
                if (ContainersMod.MaxOpenTimes(sceneName, saveId) != 1)
                {
                    Plugin.Log.LogDebug($"Found entry for: {sceneName}/{__instance.saveState.saveId}");
                    int max_val = ContainersMod.MaxOpenTimes(sceneName, saveId);
                    Plugin.Log.LogDebug($"Max open times: {max_val}");
                    var SaveState = __instance.saveState.State;
                    if (max_val == -1 || SaveState.intVal < max_val - 1)
                    {
                        SaveState.intVal++;
                        Plugin.Log.LogDebug($"Current open times: {SaveState.intVal}");
                        if (!immediate)
                        {
                            AudioController.Instance.PlaySound2D("crunch_short#1", MixerGroup.None, 0.35f);
                            Tween.Shake(__instance.containerRenderer.transform, Vector3.zero, __instance.shakeIntensity, __instance.shakeDuration, 0f);
                        }
                        return false;
                    }
                    else
                    {
                        Plugin.Log.LogDebug($"Open as normal");
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            } 
            else
            {
                return true;
            }
        }
    }
}
