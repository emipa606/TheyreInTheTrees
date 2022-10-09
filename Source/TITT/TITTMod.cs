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
    public static TITTMod instance;

    private static string currentVersion;

    /// <summary>
    ///     The private settings
    /// </summary>
    private TITTSettings settings;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="content"></param>
    public TITTMod(ModContentPack content) : base(content)
    {
        instance = this;
        currentVersion =
            VersionFromManifest.GetVersionFromModMetaData(
                ModLister.GetActiveModWithIdentifier("Mlie.TheyreInTheTrees"));
    }

    /// <summary>
    ///     The instance-settings for the mod
    /// </summary>
    internal TITTSettings Settings
    {
        get
        {
            if (settings == null)
            {
                settings = GetSettings<TITTSettings>();
            }

            return settings;
        }
        set => settings = value;
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
        var listing_Standard = new Listing_Standard();
        listing_Standard.Begin(rect);
        listing_Standard.Gap();
        listing_Standard.Label("InterceptPercent_Title_New".Translate(Settings.InterceptPercent.ToStringPercent()), -1,
            "InterceptPercent_Desc".Translate());
        Settings.InterceptPercent = Widgets.HorizontalSlider(listing_Standard.GetRect(20), Settings.InterceptPercent, 0,
            1f,
            false, Settings.InterceptPercent.ToStringPercent());
        listing_Standard.Gap();
        listing_Standard.Label("TreeCoverEff_Title_New".Translate(Settings.TreeCoverEff.ToStringPercent()), -1,
            "TreeCoverEff_Desc".Translate());
        Settings.TreeCoverEff = Widgets.HorizontalSlider(listing_Standard.GetRect(20), Settings.TreeCoverEff, 0,
            1f,
            false, Settings.TreeCoverEff.ToStringPercent());
        listing_Standard.Gap();
        listing_Standard.Label("TreeCoverEffType_title".Translate(), -1, "TreeCoverEffType_desc".Translate());
        if (listing_Standard.RadioButton("enumSetting_LessThan".Translate(),
                Settings.TreeCoverEfficencyType == ModMain.TreeCoverEffEnum.LessThan))
        {
            Settings.TreeCoverEfficencyType = ModMain.TreeCoverEffEnum.LessThan;
        }

        if (listing_Standard.RadioButton("enumSetting_All".Translate(),
                Settings.TreeCoverEfficencyType == ModMain.TreeCoverEffEnum.All))
        {
            Settings.TreeCoverEfficencyType = ModMain.TreeCoverEffEnum.All;
        }

        if (listing_Standard.RadioButton("enumSetting_Addition".Translate(),
                Settings.TreeCoverEfficencyType == ModMain.TreeCoverEffEnum.Addition))
        {
            Settings.TreeCoverEfficencyType = ModMain.TreeCoverEffEnum.Addition;
        }

        if (listing_Standard.RadioButton("enumSetting_None".Translate(),
                Settings.TreeCoverEfficencyType == ModMain.TreeCoverEffEnum.None))
        {
            Settings.TreeCoverEfficencyType = ModMain.TreeCoverEffEnum.None;
        }

        if (currentVersion != null)
        {
            listing_Standard.Gap();
            GUI.contentColor = Color.gray;
            listing_Standard.Label("TheyreInTheTreesVersion_title".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listing_Standard.End();
    }

    public override void WriteSettings()
    {
        base.WriteSettings();
        PatchApply.Apply();
    }
}