using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using UnityEngine; 

namespace BugattiRob.Valheim.BugattiBoys
{
    [BepInPlugin("BugattiRob.Valheim.BugattiBoys", "BugattiBoys", "1.0.0")]
    [BepInProcess("valheim.exe")]
    
    public class Main: BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony("BugattiRob.Valheim.BugattiBoys");

        void Awake()
        {
            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(Character), nameof(Character.Jump))]
        class Jump_Patch
        {
            static void Prefix(ref float ___m_jumpForce)
            {
                Debug.Log($"Jump force: {___m_jumpForce}");
                ___m_jumpForce = 15;
                Debug.Log($"Jump force: {___m_jumpForce}");
            }
        }
    }
}