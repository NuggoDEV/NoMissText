using IPA;
using IPA.Config.Stores;
using NoMissText.UI;
using IPALogger = IPA.Logging.Logger;
using HarmonyLib;
using BeatSaberMarkupLanguage.GameplaySetup;

namespace NoMissText
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        internal static IPALogger Log { get; private set; }
        internal static Harmony harmony { get; private set; }

        [Init]
        public Plugin(IPALogger logger, IPA.Config.Config conf)
        {
            Log = logger;
            NoMissTextConfig.Instance = conf.Generated<NoMissTextConfig>();
            harmony = new Harmony("com.CyanSnow.BeatSaber.NoMissText");
        }

        [OnStart]
        public void OnApplicationStart()
        {
            harmony.PatchAll(System.Reflection.Assembly.GetExecutingAssembly());
            GameplaySetup.instance.AddTab("No Miss Text", "NoMissText.UI.settings.bsml", new NoMissTextUI());
        }

        [OnExit]
        public void OnApplicationQuit()
        {
            harmony.UnpatchSelf();
            GameplaySetup.instance.RemoveTab("No Miss Text");
        }

    }
}
