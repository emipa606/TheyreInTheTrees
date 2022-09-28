using System;
using System.Collections.Generic;
using System.Linq;
using RimWorld;
using Verse;

namespace TITT;

public static class ObjGets
{
    internal static Dictionary<ThingDef, float> OrigCover = new Dictionary<ThingDef, float>();

    internal static IEnumerable<ThingDef> PlantList;

    internal static IEnumerable<ThingDef> TreeList;

    internal static List<ThingDef> GetListAndTruncate(IEnumerable<ThingDef> TAKE)
    {
        var num = -1;
        var list = TAKE?.ToList();
        var list2 = new List<ThingDef>();
        while (true)
        {
            num++;
            try
            {
                if (list != null)
                {
                    var thingDef = list[num];
                    _ = thingDef.defName;
                    _ = thingDef.IsIngestible;
                    _ = thingDef.ingestible.foodType;
                    list2.Add(thingDef);
                }
            }
            catch (NullReferenceException)
            {
                if (num > 200)
                {
                    throw;
                }
            }
            catch (KeyNotFoundException)
            {
                if (num > 200)
                {
                    throw;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                break;
            }
        }

        return list2;
    }

    internal static void Reset()
    {
        Log.Message("CB84.TheyreInTheTrees: Resetting TreeGets.");
        PlantList = DefDatabase<ThingDef>.AllDefs.Where(x =>
            x is { IsWeapon: false, category: ThingCategory.Plant } && !x.defName.Contains("Base") &&
            x.defName.Length >= 2);
        TreeList = PlantList.Where(x => x.defName.Contains("Tree") || x.defName.Contains("tree"));
        if (OrigCover != null && OrigCover.Any())
        {
            return;
        }

        if (OrigCover == null)
        {
            OrigCover = new Dictionary<ThingDef, float>();
        }

        OrigCover.Clear();
        GetListAndTruncate(PlantList);
        foreach (var item in GetListAndTruncate(PlantList))
        {
            if (item.IsIngestible & (item.ingestible.foodType == FoodTypeFlags.Tree))
            {
                OrigCover[item] = item.fillPercent;
            }
        }
    }
}