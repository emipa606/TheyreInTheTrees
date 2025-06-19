using Mlie;
using UnityEngine;
using Verse;

namespace TITT;

[StaticConstructorOnStartup]
internal class TITTMod : Mod
{
    /// <summary>
    ///     The instance of the settings to be read by the mod
    /// </summary>
    public static TITTMod Instance;

    private static string currentVersion;

    /// <summary>
    ///     The private settings
    /// </summary>
    public readonly TITTSettings Settings;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="content"></param>
    public TITTMod(ModContentPack content) : base(content)
    {
        Instance = this;
        currentVersion =
            VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
        Settings = GetSettings<TITTSettings>();
    }

    /// <summary>
    ///     The title for the mod-settings
    /// </summary>
    /// <returns></returns>
    public override string SettingsCategory()
    {
        return "Theyre In The Trees";
    }

    /// <summary>
    ///     The settings-window
    ///     For more info: https://rimworldwiki.com/wiki/Modding_Tutorials/ModSettings
    /// </summary>
    /// <param name="rect"></param>
    public override void DoSettingsWindowContents(Rect rect)
    {
        var listingStandard = new Listing_Standard();
        listingStandard.Begin(rect);
        listingStandard.Gap();
        listingStandard.Label("InterceptPercent_Title_New".Translate(Settings.InterceptPercent.ToStringPercent()), -1,
            "InterceptPercent_Desc".Translate());
        Settings.InterceptPercent = Widgets.HorizontalSlider(listingStandard.GetRect(20),
            Settings.InterceptPercent, 0,
            1f,
            false, Settings.InterceptPercent.ToStringPercent());
        listingStandard.Gap();
        listingStandard.Label("TreeCoverEff_Title_New".Translate(Settings.TreeCoverEff.ToStringPercent()), -1,
            "TreeCoverEff_Desc".Translate());
        Settings.TreeCoverEff = Widgets.HorizontalSlider(listingStandard.GetRect(20), Settings.TreeCoverEff, 0,
            1f,
            false, Settings.TreeCoverEff.ToStringPercent());
        listingStandard.Gap();
        listingStandard.Label("TreeCoverEffType_title".Translate(), -1, "TreeCoverEffType_desc".Translate());
        if (listingStandard.RadioButton("enumSetting_LessThan".Translate(),
                Settings.TreeCoverEfficencyType == ModMain.TreeCoverEffEnum.LessThan))
        {
            Settings.TreeCoverEfficencyType = ModMain.TreeCoverEffEnum.LessThan;
        }

        if (listingStandard.RadioButton("enumSetting_All".Translate(),
                Settings.TreeCoverEfficencyType == ModMain.TreeCoverEffEnum.All))
        {
            Settings.TreeCoverEfficencyType = ModMain.TreeCoverEffEnum.All;
        }

        if (listingStandard.RadioButton("enumSetting_Addition".Translate(),
                Settings.TreeCoverEfficencyType == ModMain.TreeCoverEffEnum.Addition))
        {
            Settings.TreeCoverEfficencyType = ModMain.TreeCoverEffEnum.Addition;
        }

        if (listingStandard.RadioButton("enumSetting_None".Translate(),
                Settings.TreeCoverEfficencyType == ModMain.TreeCoverEffEnum.None))
        {
            Settings.TreeCoverEfficencyType = ModMain.TreeCoverEffEnum.None;
        }

        if (currentVersion != null)
        {
            listingStandard.Gap();
            GUI.contentColor = Color.gray;
            listingStandard.Label("TheyreInTheTreesVersion_title".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listingStandard.End();
    }

    public override void WriteSettings()
    {
        base.WriteSettings();
        PatchApply.Apply();
    }
}