using IPA;
using IPA.Config.Stores;
using NoMissText.UI;
using IPALogger = IPA.Logging.Logger;
using HarmonyLib;
using BeatSaberMarkupLanguage.GameplaySetup;
using BeatSaberMarkupLanguage.Util;

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
        async public void OnApplicationStart()
        {
            await MainMenuAwaiter.WaitForMainMenuAsync();
            MainMenuAwaiter.MainMenuInitializing += reinitializeSettings;

            harmony.PatchAll(System.Reflection.Assembly.GetExecutingAssembly());
            
            reinitializeSettings();
        }

        private void reinitializeSettings()
        {
            GameplaySetup.Instance.AddTab("No Miss Text", "NoMissText.UI.settings.bsml", new NoMissTextUI());
        }

        [OnExit]
        public void OnApplicationQuit()
        {
            harmony.UnpatchSelf();
            GameplaySetup.Instance.RemoveTab("No Miss Text");
        }

    }
}
