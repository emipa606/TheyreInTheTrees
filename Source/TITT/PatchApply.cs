using System;
using HarmonyLib;

namespace TITT;

public class PatchApply
{
    internal static void Apply()
    {
        if (ObjGets.TreeList == null)
        {
            ObjGets.Reset();
        }

        if (TITTMod.instance.Settings.TreeCoverEfficencyType != ModMain.TreeCoverEffEnum.None)
        {
            foreach (var item in ObjGets.GetListAndTruncate(ObjGets.TreeList))
            {
                if (item == null)
                {
                    continue;
                }

                if (!ObjGets.OrigCover.TryGetValue(item, out var value))
                {
                    continue;
                }

                if (TITTMod.instance.Settings.TreeCoverEfficencyType == ModMain.TreeCoverEffEnum.Addition)
                {
                    item.fillPercent =
                        Math.Max(Math.Min(value + TITTMod.instance.Settings.TreeCoverEff, 0.7f),
                            0.05f);
                    continue;
                }

                if (!(ObjGets.OrigCover[item] < TITTMod.instance.Settings.TreeCoverEff) &&
                    TITTMod.instance.Settings.TreeCoverEfficencyType != ModMain.TreeCoverEffEnum.All)
                {
                    continue;
                }

                item.fillPercent = Math.Max(Math.Min(TITTMod.instance.Settings.TreeCoverEff, 0.7f), 0.05f);
            }

            return;
        }

        foreach (var item2 in ObjGets.GetListAndTruncate(ObjGets.TreeList))
        {
            if (item2 != null)
            {
                item2.fillPercent = ObjGets.OrigCover[item2];
            }
        }
    }

    internal static void HarmonyPatch()
    {
        new Harmony("com.cb84.titt.patch").PatchAll();
    }
}