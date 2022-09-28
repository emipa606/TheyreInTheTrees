using System;
using System.IO;
using System.Xml.Linq;
using Verse;

namespace TITT;

[StaticConstructorOnStartup]
public static class ModMain
{
    public enum TreeCoverEffEnum
    {
        LessThan,
        All,
        Addition,
        None
    }

    static ModMain()
    {
        PatchApply.Apply();
        var hugsLibConfig = Path.Combine(GenFilePaths.SaveDataFolderPath, Path.Combine("HugsLib", "ModSettings.xml"));
        if (!new FileInfo(hugsLibConfig).Exists)
        {
            return;
        }

        var xml = XDocument.Load(hugsLibConfig);

        var modSettings = xml.Root?.Element("TheyreInTheTrees");
        if (modSettings == null)
        {
            return;
        }

        foreach (var modSetting in modSettings.Elements())
        {
            if (modSetting.Name == "Input_InterceptPercent")
            {
                TITTMod.instance.Settings.InterceptPercent = float.Parse(modSetting.Value);
            }

            if (modSetting.Name == "Input_TreeCoverEff")
            {
                TITTMod.instance.Settings.TreeCoverEff = int.Parse(modSetting.Value) / 100f;
            }

            if (modSetting.Name == "Input_TreeCoverEffType")
            {
                TITTMod.instance.Settings.TreeCoverEfficencyType =
                    (TreeCoverEffEnum)Enum.Parse(typeof(TreeCoverEffEnum), modSetting.Value);
            }
        }

        xml.Root.Element("TheyreInTheTrees")?.Remove();
        xml.Save(hugsLibConfig);

        Log.Message("[TheyreInTheTrees]: Imported old HugLib-settings");
        PatchApply.Apply();
    }
}