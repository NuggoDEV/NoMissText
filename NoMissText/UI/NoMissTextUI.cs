using BeatSaberMarkupLanguage.Attributes;

namespace NoMissText.UI
{
    internal class NoMissTextUI
    {
        [UIValue("hidemisstext")]
        public bool HideMissText
        {
            get => NoMissTextConfig.Instance.HideMissText;
            set => NoMissTextConfig.Instance.HideMissText = value;
        }
        [UIValue("hidedumbfcbreaklines")]
        public bool HideDumbFCBreakLines
        {
            get => NoMissTextConfig.Instance.HideDumbFCBreakLines;
            set => NoMissTextConfig.Instance.HideDumbFCBreakLines = value;
        }
    }
}