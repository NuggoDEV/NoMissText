using HarmonyLib;
using IPA.Utilities;
using NoMissText.UI;
using System.Runtime.CompilerServices;

namespace NoMissText.HarmonyPatches
{
    [HarmonyPatch(typeof(ComboUIController), "HandleComboBreakingEventHappened")]
    internal class ComboUIControllerPatch
    {
        [HarmonyPrefix]
        public static bool Prefix(ComboUIController __instance)
        {
            if (NoMissTextConfig.Instance.HideDumbFCBreakLines && !__instance.GetField<bool, ComboUIController>("_fullComboLost"))
            {
                __instance.SetField("_fullComboLost", true);
                __instance.transform.Find("Line0").gameObject.SetActive(false);
                __instance.transform.Find("Line1").gameObject.SetActive(false);
                return false;
            }
            return true;
        }
    }
}
