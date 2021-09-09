using HugsLib;
using HugsLib.Settings;
using TITT.Tools;
using Verse;

namespace TITT.Main
{
    public class ModMain : ModBase
    {
        internal static SettingHandle<double> InterceptPercent;

        internal static SettingHandle<int> TreeCoverEff;

        internal static SettingHandle<TreeCoverEffEnum> TreeCoverEffType;

        public override string ModIdentifier => "TheyreInTheTrees";

        public override void DefsLoaded()
        {
            InterceptPercent = Settings.GetHandle("Input_InterceptPercent", "InterceptPercent_Title".Translate(),
                "InterceptPercent_Desc".Translate(), 0.15);
            TreeCoverEff = Settings.GetHandle("Input_TreeCoverEff", "TreeCoverEff_Title".Translate(),
                "TreeCoverEff_Desc".Translate(), 35);
            TreeCoverEffType = Settings.GetHandle("Input_TreeCoverEffType", "TreeCoverEffType_title".Translate(),
                "TreeCoverEffType_desc".Translate(), TreeCoverEffEnum.LessThan, null, "enumSetting_");
            PatchApply.Apply();
        }

        public override void SettingsChanged()
        {
            Log.Message("CB84.TheyreInTheTrees: Settings Changed.");
            Log.Message(DynamVal.InterceptPercent.ToString());
            base.SettingsChanged();
            PatchApply.Apply();
        }

        internal enum TreeCoverEffEnum
        {
            LessThan,
            All,
            Addition,
            None
        }
    }
}