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
        public const string PluginGuid = "rageleague.inscryption.moresliderpuzzles";
        public const string PluginName = "MoreSliderPuzzles";
        public const string PluginVersion = "1.0.1.0";

        internal static ManualLogSource Log;

        public static ConfigEntry<bool> Randomized;
        public void ConfigDefinitions()
        {
            Randomized = Config.Bind<bool>("RageLeague.SliderPuzzlesAPI",
                    "Should Puzzles Be Randomized?",
                    true,
                    "Should the Loaded Puzzles order in game be Randomized?");
        }

        public void Awake()
        {

            Logger.LogInfo($"Loaded {PluginName}! ");
            Plugin.Log = base.Logger;

            Harmony harmony = new Harmony(PluginGuid);
            harmony.PatchAll();
        }

        public void Start()
        {
            Log.LogDebug($"APIPlugin Start() begin");
            Log.LogDebug($"APIPlugin Start() end");
        }

        public void OnEnable()
        {
            SceneManager.sceneLoaded += this.OnSceneLoaded;
        }

        public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
        }
    }
}
