using HarmonyLib;
using System;
using Object = UnityEngine.Object;

namespace MyFirstPlugin
{
    public static class PlayerPatcher
    {
        private static Player player;

        [HarmonyPatch(typeof(Player), "OnExitDropPod")]
        [HarmonyPrefix] // Prefix makes sure the patch is ran before the original method
        public static void OnExitDropPodLogger()
        {
            player = Object.FindObjectOfType<Player>(); // Find the player object
            
            Plugin.Log.LogInfo($"{DateTime.Now} - {player.CurrentClass.DisplayName} Exited Droppod!");
        }

        [HarmonyPatch(typeof(Player), "OnEnterDropPod")]
        [HarmonyPrefix]
        public static void OnEnterDropPodLogger()
        {
            Plugin.Log.LogInfo($"{DateTime.Now} - {player.CurrentClass.DisplayName} Entered Droppod!");
        }
    }
}
