using HarmonyLib;
using NoMissText.UI;

namespace NoMissText.HarmonyPatches
{
    [HarmonyPatch(typeof(FlyingSpriteSpawner), "SpawnFlyingSprite")]
    internal class FlyingSpriteSpawnerPatch
    {
        [HarmonyPrefix]
        public static bool Prefix(FlyingSpriteSpawner __instance) => !NoMissTextConfig.Instance.HideMissText;
    }
}
