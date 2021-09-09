using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using TITT.Tools;
using Verse;

[HarmonyPatch(typeof(Projectile))]
[HarmonyPatch("CheckForFreeIntercept")]
public static class MyPatches
{
	private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
	{
		Log.Message("CB84.TheyreInTheTrees: Transpile", ignoreStopLoggingLimit: false);
		List<CodeInstruction> list = new List<CodeInstruction>(instructions);
		MethodInfo operand = AccessTools.Method(typeof(DynamVal), "GetInterceptPercent");
		for (int i = 0; i < list.Count; i++)
		{
			_ = list[i].opcode;
			int num = 1 & ((list[i].operand != null) ? 1 : 0);
			_ = list[i + 1].opcode;
			if (((uint)num & (true ? 1u : 0u) & ((list[i + 1].operand != null) ? 1u : 0u)) != 0 && ((i > 10) & (list[i].opcode == OpCodes.Ldfld) & (list[i].operand.ToString() == "System.Single fillPercent") & (list[i + 1].opcode == OpCodes.Ldc_R4) & (list[i + 1].operand.ToString() == "0.15")))
			{
				Log.Message(list[i + 1].ToString(), ignoreStopLoggingLimit: false);
				list[i + 1].opcode = OpCodes.Call;
				list[i + 1].operand = operand;
				break;
			}
		}
		Log.Message("CB84.TheyreInTheTrees: Transpile Returned", ignoreStopLoggingLimit: false);
		return list.AsEnumerable();
	}
}
