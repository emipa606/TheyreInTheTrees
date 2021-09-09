using TITT.Main;
using Verse;

namespace TITT.Tools
{
    public class DynamVal
    {
        internal static double InterceptPercent
        {
            get
            {
                if (ModMain.InterceptPercent != null)
                {
                    Log.Message(ModMain.InterceptPercent.ToString());
                    return ModMain.InterceptPercent;
                }

                Log.Message("00.15");
                return 0.15;
            }
        }

        internal static double Test { get; set; }

        internal static double GetInterceptPercent()
        {
            if (ModMain.InterceptPercent != null)
            {
                Log.Message("GIntPer:" + ModMain.InterceptPercent);
                return ModMain.InterceptPercent;
            }

            Log.Message("GIntPer:00.15");
            return 0.15;
        }
    }
}