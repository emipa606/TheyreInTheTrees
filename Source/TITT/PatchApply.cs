using System;
using HarmonyLib;
using TITT.Tools;
using Verse;

namespace TITT.Main
{
    public class PatchApply
    {
        internal static void Apply()
        {
            Log.Message("CB84.TheyreInTheTrees: Begin.");
            if (ObjGets.TreeList == null)
            {
                ObjGets.Reset();
            }

            if (ModMain.TreeCoverEffType != null &&
                ModMain.TreeCoverEffType != ModMain.TreeCoverEffEnum.None)
            {
                foreach (var item in ObjGets.GetListAndTruncate(ObjGets.TreeList))
                {
                    if (item == null)
                    {
                        continue;
                    }

                    if (!ObjGets.OrigCover.ContainsKey(item))
                    {
                        continue;
                    }

                    //Log.Message(item.defName);
                    if (ModMain.TreeCoverEffType == ModMain.TreeCoverEffEnum.Addition)
                    {
                        item.fillPercent =
                            Math.Max(Math.Min(ObjGets.OrigCover[item] + (ModMain.TreeCoverEff / 100f), 0.7f),
                                0.05f);
                        continue;
                    }

                    if (!(ObjGets.OrigCover[item] < ModMain.TreeCoverEff / 100f) &&
                        ModMain.TreeCoverEffType != ModMain.TreeCoverEffEnum.All)
                    {
                        continue;
                    }

                    item.fillPercent = Math.Max(Math.Min(ModMain.TreeCoverEff / 100f, 0.7f), 0.05f);
                }

                Log.Message("CB84.TheyreInTheTrees: Done.");
                return;
            }

            if (ModMain.TreeCoverEffType == null ||
                ModMain.TreeCoverEffType != ModMain.TreeCoverEffEnum.None)
            {
                return;
            }

            foreach (var item2 in ObjGets.GetListAndTruncate(ObjGets.TreeList))
            {
                if (item2 != null)
                {
                    item2.fillPercent = ObjGets.OrigCover[item2];
                }
            }

            Log.Message("CB84.TheyreInTheTrees: Done.");
        }

        internal static void HarmonyPatch()
        {
            new Harmony("com.cb84.titt.patch").PatchAll();
        }
    }
}