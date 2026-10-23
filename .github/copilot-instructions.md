# GitHub Copilot Instructions for They're in the Trees! (Continued) Mod

## Mod Overview and Purpose

**Mod Name:** They're in the Trees! (Continued)  
**Display Name:** They're in the Trees! (Continued)  
**Author:** ChickenBites84  
**PackageId:** Mlie.TheyreInTheTrees  

The "They're in the Trees! (Continued)" mod is an update to ChickenBites84's original mod. It enhances the forest environment in RimWorld by making it more challenging and tactical for players. The mod allows for adjustable cover effectiveness of trees and intercept percentages for projectiles, which significantly benefits raider cover in forests. Additionally, it ensures that ToWild projectiles face interception across several objects, demanding more precise firing angle placement.

## Key Features and Systems

- **Adjustable Cover Effectiveness:** Allows players to set the cover effectiveness of trees in the forest.
- **Adjustable Intercept Percent:** Adjusts the interception percentage based on the cover effectiveness.
- **ToWild Projectile Interception:** Ensures ToWild projectiles face interception across several objects, requiring more precise firing.
- **Settings Migrated from HugsLib:** Updated from the old HugsLib settings to ensure compatibility and ease of use.

## Coding Patterns and Conventions

1. **Namespaces:** Use `TITT` as the primary namespace for all classes within the mod.
2. **ModMain Class:** Acts as the entry point for the mod. It includes initialization code and settings handling.
3. **Transpilers:** Utilize transpilers for modifying existing game code behavior. Ensure that transpilers are well-documented and maintainable.
4. **Settings Management:** Use the `SettingsCategory` and `DoSettingsWindowContents` methods in the `ModMain` class to handle mod settings.
5. **XML Configuration:** Use XML files for mod metadata and dependencies.

## XML Integration

The mod uses an XML file (`About.xml`) for metadata and dependencies. Ensure that the XML file is correctly formatted and includes all necessary dependencies:

xml
<About>
    <PackageId>Mlie.TheyreInTheTrees</PackageId>
    <Name>They're in the Trees! (Continued)</Name>
    <Author>ChickenBites84</Author>
    <Description>
        Update of ChickenBites84s mod. Enhances forest environment with adjustable cover effectiveness and projectile interception.
    </Description>
    <Version>1.0</Version>
    <Dependencies>
        <Dependency>brrainz.harmony</Dependency>
        <Dependency>UnlimitedHugs.HugsLib</Dependency>
    </Dependencies>
</About>


## Harmony Patching

The mod uses Harmony for patching existing game code. Ensure that all Harmony patches are correctly applied and maintainable. The `HarmonyPatch` attribute is used to specify the target method for patching. Example:

csharp
[HarmonyPatch(typeof(SomeTargetClass), nameof(SomeTargetClass.SomeTargetMethod))]
public static class MyPatches
{
    [HarmonyTranspiler]
    public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        // Transpiler code here
    }
}


## Suggestions for Copilot

1. **ModMain Class:** When generating code for the `ModMain` class, include methods for initializing the mod, handling settings, and any other necessary setup.
2. **Transpilers:** When generating transpiler code, ensure that the code is well-documented and maintains the integrity of the original method.
3. **Settings Management:** When generating code for settings management, ensure that the settings are correctly displayed in the RimWorld settings window and that the settings are saved and loaded properly.
4. **XML Configuration:** When generating XML configuration files, ensure that the files are correctly formatted and include all necessary dependencies.

By following these guidelines, you can help ensure that the "They're in the Trees! (Continued)" mod remains functional, efficient, and easy to maintain.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

