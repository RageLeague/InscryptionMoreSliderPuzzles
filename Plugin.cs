using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine.SceneManagement;

#pragma warning disable 169

namespace MoreSliderPuzzles
{
  [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
  public partial class Plugin : BaseUnityPlugin
  {
    private const string PluginGuid = "rageleague.inscryption.moresliderpuzzles";
    private const string PluginName = "MoreSliderPuzzles";
    private const string PluginVersion = "1.0.0.0";

    internal static ManualLogSource Log;

    private void Awake()
    {
      Logger.LogInfo($"Loaded {PluginName}! ");
      Plugin.Log = base.Logger;

      Harmony harmony = new Harmony(PluginGuid);
      harmony.PatchAll();
    }

    private void Start()
    {
      Log.LogDebug($"APIPlugin Start() begin");
      Log.LogDebug($"APIPlugin Start() end");
    }

    private void OnEnable()
    {
      SceneManager.sceneLoaded += this.OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
    }
  }
}
