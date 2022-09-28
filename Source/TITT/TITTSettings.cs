using Verse;

namespace TITT;

/// <summary>
///     Definition of the settings for the mod
/// </summary>
internal class TITTSettings : ModSettings
{
    public float InterceptPercent = 0.15f;
    public float TreeCoverEff = 0.35f;
    public ModMain.TreeCoverEffEnum TreeCoverEfficencyType = ModMain.TreeCoverEffEnum.LessThan;

    /// <summary>
    ///     Saving and loading the values
    /// </summary>
    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref TreeCoverEff, "TreeCoverEff", 0.35f);
        Scribe_Values.Look(ref InterceptPercent, "InterceptPercent", 0.15f);
        Scribe_Values.Look(ref TreeCoverEfficencyType, "TreeCoverEfficencyType");
    }
}