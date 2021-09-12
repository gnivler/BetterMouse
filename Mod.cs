using System.IO;
using BBI;
using BepInEx;
using HarmonyLib;

namespace BetterMouse
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    public class Mod : BaseUnityPlugin
    {
        private const string PluginGUID = "ca.gnivler.shipbreaker.BetterMouse";
        private const string PluginName = "BetterMouse";
        private const string PluginVersion = "1.0.0";
         
        private void Awake()
        {
            Harmony harmony = new("ca.gnivler.shipbreaker.BetterMouse");
            Log("BetterMouse Startup");
            harmony.PatchAll(typeof(Patches));
        }

        internal static void Log(object input)
        {
            //File.AppendAllText("log.txt",$"{input ?? "null"}\n");
        }
    }
}
